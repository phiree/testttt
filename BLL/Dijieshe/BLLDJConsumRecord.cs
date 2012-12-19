using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;
using Model;

namespace BLL
{
    public class BLLDJConsumRecord
    {
        IDJGroupConsumRecord IDjgroup = new DALDJ_GroupConsumRecord();

        DALDJ_GroupConsumRecord dal;
        public DALDJ_GroupConsumRecord DAL
        {

            get
            {
                if (dal == null) { dal = new DALDJ_GroupConsumRecord(); }
                return dal;
            }
            set { dal = value; }
        }

        public void Save(DJ_TourEnterprise Enterprise, DJ_Route route, DateTime consumtime, int AdultsAmount, int ChildrenAmount, int LiveDay, int roomNum, int AppendBed)
        {
            DJ_GroupConsumRecord dj_group = new DJ_GroupConsumRecord();
            dj_group.AdultsAmount = AdultsAmount;
            dj_group.ChildrenAmount = ChildrenAmount;
            dj_group.ConsumeTime = consumtime;
            dj_group.Enterprise = Enterprise;
            dj_group.Route = route;
            dj_group.LiveDay = LiveDay;
            dj_group.RoomNum = roomNum;
            dj_group.No = "Lv" + new Random((int)DateTime.Now.Ticks).Next(100000, 999999);
            dj_group.AppendBed = AppendBed;
            if (IDjgroup.GetGroupConsumRecordByRouteId(route.Id) == null)
                IDjgroup.Save(dj_group);
        }

        public void SaveList(List<DJ_Route> listroute, int AdultsAmount, int ChildrenAmount, int LiveDay, int roomNum, int AppendBed)
        {
            foreach (DJ_Route route in listroute)
            {
                Save(route.Enterprise, route, DateTime.Now, AdultsAmount, ChildrenAmount, LiveDay, roomNum,AppendBed);
            }
        }

        public Model.DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(Guid RouteId)
        {
            return IDjgroup.GetGroupConsumRecordByRouteId(RouteId);
        }

        public Model.DJ_GroupConsumRecord GetGCR8Name(string EnterpName, string groupid)
        {
            return IDjgroup.GetGcr8Name(EnterpName, groupid);
        }

        public IList<Model.DJ_TourGroup> GetFeRecordByETId(int etid, int day, int pageIndex, int pageSize, out int totalRecord)
        {
            List<Model.DJ_TourGroup> ListTg = IDjgroup.GetFeRecordByETId(etid).ToList();
            totalRecord = ListTg.Where(x => x.BeginDate.AddDays(day) <= DateTime.Now).Count();
            ListTg = ListTg.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return ListTg;
        }

        public void GetCountInfoByETid(int etid, out int groupcount, out int adultcount, out int childrencount, List<DJ_GroupConsumRecord> Listrecord)
        {
            adultcount = 0;
            childrencount = 0;
            groupcount = Listrecord.GroupBy(x => x.Route.DJ_TourGroup.Id).Count();
            foreach (DJ_GroupConsumRecord record in Listrecord)
            {
                adultcount += record.AdultsAmount;
                childrencount += record.ChildrenAmount;
            }
        }
        /// <summary>
        /// 获得需求天数的route
        /// </summary>
        /// <param name="MaxLiveDay">最大的天数</param>
        /// <param name="WLiveDay">需求的天数</param>
        /// <param name="ent">住宿企业</param>
        /// <param name="route">行程信息</param>
        /// <returns>route的List</returns>
        public List<Model.DJ_Route> GetLiveRouteByDay(out int MaxLiveDay, int WLiveDay, DJ_TourEnterprise ent, DJ_Route route)
        {
            List<Model.DJ_Route> ListRoute = new List<DJ_Route>();
            MaxLiveDay = 0;
            if (WLiveDay > 0)
            {
                for (int i = route.DayNo; ; i++)
                {
                    List<DJ_Route> list = new BLLDJRoute().GetRouteByDayNoandGroupid(i, route.DJ_TourGroup.Id, route.Enterprise.Id).ToList();
                    if (list.Count > 0)
                    {
                        ListRoute.AddRange(list);
                    }
                    else
                    {
                        MaxLiveDay = i - route.DayNo;
                        break;
                    }
                }
            }
            return ListRoute;
        }

        public List<Model.DJ_GroupConsumRecord> GetRecordByAllCondition(string groupname, string EntName, string BeginTime, string EndTime, int enterid)
        {
            List<Model.DJ_GroupConsumRecord> ListRecord = IDjgroup.GetRecordByAllCondition(groupname, EntName, BeginTime, EndTime, enterid);
            List<Model.DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (Model.DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Count() == 0)
                {
                    List.Add(item);
                }
            }
            return List;
        }

        /// <summary>
        /// 多条件查询消费记录
        /// </summary>
        /// <param name="areacode"></param>
        /// <param name="enterpname"></param>
        /// <param name="groupid"></param>
        /// <param name="routeid"></param>
        /// <param name="djsname"></param>
        /// <param name="b_date">开始时间</param>
        /// <param name="e_date">结束时间</param>
        /// <returns></returns>
        public IList<Model.DJ_GroupConsumRecord> GetGCR8Multi(string areacode, string enterpname, string groupid, string routeid, string djsname)
        {
            return IDjgroup.GetGCR8Multi(areacode, enterpname, groupid, routeid, djsname);
        }

        /// <summary>
        /// 地接社其他企业统计信息
        /// </summary>
        /// <param name="dateyear">查询年份</param>
        /// <param name="EntName">查询企业名称</param>
        /// <param name="EntId">所在地接社id</param>
        /// <returns>查询出的企业列表</returns>
        public IList<DJ_TourEnterprise> GetDJStaticsEnt(string bengintime, string endtime, string EntName, int type, int EntId, bool? IsVerified)
        {
            List<DJ_GroupConsumRecord> ListRecord = GetRecordByCondition(bengintime, endtime, EntName, type, EntId, IsVerified).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Where(x=>x.Enterprise.Id==item.Enterprise.Id).Count() == 0)
                {
                    List.Add(item);
                }
            }
            List<DJ_TourEnterprise> ListTE = new List<DJ_TourEnterprise>();
            foreach (IGrouping<DJ_TourEnterprise, DJ_GroupConsumRecord> item in List.GroupBy(x => x.Enterprise).ToList())
            {
                ListTE.Add(item.Key);
            }
            return ListTE;
        }

        public void GetCountByStatics(string begintime, string endtime, string EntName, int type, int EntId, int Enttype, int Wentid,out int people,out int room,out int appendbed)
        {
            people = room = appendbed = 0;
            List<DJ_GroupConsumRecord> ListRecord = GetRecordByCondition(begintime, endtime, EntName, type, EntId,null).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Where(x => x.Enterprise.Id == item.Enterprise.Id).Count() == 0)
                {
                    List.Add(item);
                }
            }
            List = List.Where(x => x.Enterprise.Id == Wentid).ToList();
            if (Enttype == 1)
            {
                foreach (DJ_GroupConsumRecord item in List)
                {
                    people += item.AdultsAmount + item.ChildrenAmount;
                }
            }
            if (Enttype == 4)
            {
                foreach (DJ_GroupConsumRecord item in List)
                {
                    people += (item.AdultsAmount + item.ChildrenAmount)*item.LiveDay;
                    room += item.RoomNum;
                    appendbed += item.AppendBed;
                }
            }
        }

        public IList<DJ_GroupConsumRecord> GetRecordByCondition(string begintime, string endtime, string EntName, int type, int EntId, bool? IsVerified)
        {
            if (IsVerified != null)
            {
                return IDjgroup.GetRecordByCondition(begintime, endtime, EntName, type, EntId).Where(x=>x.Enterprise.IsVerified==(bool)IsVerified).ToList();
            }
            return IDjgroup.GetRecordByCondition(begintime, endtime, EntName, type, EntId);
        }

        public List<DJ_GroupConsumRecord> GetByDate(int year, int month, int entid, int djsid)
        {
            List<DJ_GroupConsumRecord> ListRecord = IDjgroup.GetByDate(year, month, entid, djsid).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Where(x => x.Enterprise.Id == item.Enterprise.Id).Count() == 0)
                {
                    List.Add(item);
                }
            }
            return List;
        }

        public List<DJ_GovManageDepartment> GetDptRecord(string beginTime, string endTime, string dptname, int entid)
        {
            List<Model.DJ_GroupConsumRecord> ListRecord = IDjgroup.GetDptRecordByCondition(beginTime, endTime, dptname, entid).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Where(x => x.Enterprise.Id == item.Enterprise.Id).Count() == 0)
                {
                    List.Add(item);
                }
            }
            List<DJ_GovManageDepartment> ListGovDpt = new BLLDJ_GovManageDepartment().GetGovDptByName(dptname).ToList();
            List<DJ_GovManageDepartment> ListGovWdpt = new List<DJ_GovManageDepartment>();
            foreach (DJ_GovManageDepartment item in ListGovDpt)
            {
                foreach (DJ_GroupConsumRecord record in List)
                {
                    //省
                    if (item.Area.Code.Substring(2) == "0000")
                    {
                        //省的暂时不做处理
                    }
                    //市
                    else if (item.Area.Code.Substring(4,2) == "00")
                    {
                        if (item.Area.Code.Substring(0, 4) == record.Enterprise.Area.Code.Substring(0, 4))
                        {
                            ListGovWdpt.Add(item);
                            break;
                        }
                    }
                    //县
                    else
                    {
                        if (item.Area.Code.Substring(0, 6) == record.Enterprise.Area.Code.Substring(0, 6))
                        {
                            ListGovWdpt.Add(item);
                            break;
                        }
                    }
                }
            }
           
            return ListGovWdpt;
        }

        public void GetDetailDptCount(string beginTime, string endTime, string code, int entid, out int totalcount, out int livecount, out int visitedcount)
        {
            totalcount = 0;
            livecount = 0;
            visitedcount = 0;
            List<Model.DJ_GroupConsumRecord> ListRecord = IDjgroup.GetDptRecordByCondition(beginTime, endTime, "", entid).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Where(x => x.Enterprise.Id == item.Enterprise.Id).Count() == 0)
                {
                    List.Add(item);
                }
            }
            if (code.Substring(2) == "0000")
            {
                //省的不会出现
            }
            else if (code.Substring(4, 2) == "00")
            {
                foreach (DJ_GroupConsumRecord item in List.Where(x => x.Enterprise.Area.Code.Substring(0, 4) == code.Substring(0, 4)))
                {
                    if (item.Enterprise.CityVeryfyState == RewardType.已纳入)
                    {
                        totalcount += item.AdultsAmount + item.ChildrenAmount;
                        if (item.LiveDay > 0)
                        {
                            livecount += (item.AdultsAmount + item.ChildrenAmount) * (item.LiveDay);
                        }
                        else
                        {
                            visitedcount += item.AdultsAmount + item.ChildrenAmount;
                        }
                    }
                }
            }
            else
            {
                foreach (DJ_GroupConsumRecord item in List.Where(x => x.Enterprise.Area.Code.Substring(0, 6) == code.Substring(0, 6)))
                {
                    if (item.Enterprise.CountryVeryfyState == RewardType.已纳入)
                    {
                        totalcount += item.AdultsAmount + item.ChildrenAmount;
                        if (item.LiveDay > 0)
                        {
                            livecount += (item.AdultsAmount + item.ChildrenAmount) * (item.LiveDay);
                        }
                        else
                        {
                            visitedcount += item.AdultsAmount + item.ChildrenAmount;
                        }
                    }
                }
            }
        }

        public IList<Model.DJ_GroupConsumRecord> GetByDate(int year, int month, string code, int djsid)
        {
            List<DJ_GroupConsumRecord> ListRecord = IDjgroup.GetByDate(year, month, code, djsid).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Where(x => x.ConsumeTime.ToShortDateString() == item.ConsumeTime.ToShortDateString()).Where(x => x.Enterprise.Id == item.Enterprise.Id).Count() == 0)
                {
                    //加入省市县的判断
                    //省
                    if (code.Substring(2) == "0000")
                    {

                    }
                    else if (code.Substring(4, 2) == "00")
                    {
                        if (item.Enterprise.Area.Code.Substring(0,4) == code.Substring(0,4) && item.Enterprise.CityVeryfyState == RewardType.已纳入)
                        {
                            List.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Enterprise.Area.Code == code && item.Enterprise.CountryVeryfyState == RewardType.已纳入)
                        {
                            List.Add(item);
                        }
                    }
                }
            }
            return List;
        }

        /// <summary>
        /// 与groupname部分相同的group的所有消费记录
        /// 用于测试数据的删除
        /// </summary>
        /// <returns></returns>

      
        public void DeleteDemoRecords(string groupNamePrefix)
        {
            IList<DJ_GroupConsumRecord> records = DAL.GetList_DemoRecords(groupNamePrefix);

            foreach (DJ_GroupConsumRecord r in records)
            {
                dal.Delete(r);
            }
        }


        public List<DJ_DijiesheInfo> SelectFromRecord(string groupname, string EntName, string BeginTime, string EndTime, int enterid)
        {
            List<DJ_GroupConsumRecord> ListRecord= IDjgroup.GetRecordByAllCondition(groupname, EntName, BeginTime, EndTime, enterid);
            List<DJ_DijiesheInfo> ListDJS=new List<DJ_DijiesheInfo>();
            foreach (var item in ListRecord.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo))
	        {
                ListDJS.Add(item.Key);
	        }
            return ListDJS;
        }

        
    }
}
