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

        public void Save(DJ_TourEnterprise Enterprise, DJ_Route route, DateTime consumtime, int AdultsAmount, int ChildrenAmount,int LiveDay)
        {
            DJ_GroupConsumRecord dj_group = new DJ_GroupConsumRecord();
            dj_group.AdultsAmount = AdultsAmount;
            dj_group.ChildrenAmount = ChildrenAmount;
            dj_group.ConsumeTime = consumtime;
            dj_group.Enterprise = Enterprise;
            dj_group.Route = route;
            dj_group.LiveDay = LiveDay;
            dj_group.No = "Lv" + new Random((int)DateTime.Now.Ticks).Next(100000, 999999);
            if (IDjgroup.GetGroupConsumRecordByRouteId(route.Id)==null)
                IDjgroup.Save(dj_group);
        }

        public void SaveList(List<DJ_Route> listroute,int AdultsAmount, int ChildrenAmount,int LiveDay)
        {
            foreach (DJ_Route route in listroute)
            {
                Save(route.Enterprise, route, DateTime.Now, AdultsAmount, ChildrenAmount, LiveDay);
            }
        }

        public Model.DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(Guid RouteId)
        {
            return IDjgroup.GetGroupConsumRecordByRouteId(RouteId);
        }

        public Model.DJ_GroupConsumRecord GetGCR8Name(string EnterpName,string groupid)
        {
            return IDjgroup.GetGcr8Name(EnterpName,groupid);
        }

        public IList<Model.DJ_TourGroup> GetFeRecordByETId(int etid, int day, int pageIndex, int pageSize, out int totalRecord)
        {
            List<Model.DJ_TourGroup> ListTg = IDjgroup.GetFeRecordByETId(etid).ToList();
            totalRecord = ListTg.Where(x => x.BeginDate.AddDays(day) <= DateTime.Now).Count();
            ListTg = ListTg.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return ListTg;
        }

        public void GetCountInfoByETid(int etid,out int groupcount,out int adultcount,out int childrencount,List<DJ_GroupConsumRecord> Listrecord)
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
        public List<Model.DJ_Route> GetLiveRouteByDay(out int MaxLiveDay, int WLiveDay, DJ_TourEnterprise ent,DJ_Route route)
        {
            List<Model.DJ_Route> ListRoute = new List<DJ_Route>();
            MaxLiveDay = 0;
            if (WLiveDay > 0)
            {
                for (int i = route.DayNo;; i++)
			    {
                    List<DJ_Route> list= new BLLDJRoute().GetRouteByDayNoandGroupid(i, route.DJ_TourGroup.Id,route.Enterprise.Id).ToList();
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

        public List<Model.DJ_GroupConsumRecord> GetRecordByAllCondition(string groupname,string EntName,string BeginTime,string EndTime,int enterid)
        {
            List<Model.DJ_GroupConsumRecord> ListRecord=IDjgroup.GetRecordByAllCondition(groupname, EntName, BeginTime, EndTime, enterid);
            List<Model.DJ_GroupConsumRecord> List=new List<DJ_GroupConsumRecord>();
            foreach (Model.DJ_GroupConsumRecord item in ListRecord)
	        {
		        if(List.Where(x=>x.Route.DJ_TourGroup.Id==item.Route.DJ_TourGroup.Id).Count()==0)
                {
                    List.Add(item);
                }
	        }
            return List;
        }

        public IList<Model.DJ_GroupConsumRecord> GetGCR8Multi(string areacode, string enterpname, string groupid, string routeid, string djsname)
        {
            return IDjgroup.GetGCR8Multi(areacode, enterpname, groupid, routeid,djsname);
        }

        /// <summary>
        /// 地接社其他企业统计信息
        /// </summary>
        /// <param name="dateyear">查询年份</param>
        /// <param name="EntName">查询企业名称</param>
        /// <param name="EntId">所在地接社id</param>
        /// <returns>查询出的企业列表</returns>
        public IList<DJ_TourEnterprise> GetDJStaticsEnt(string dateyear, string EntName, int EntId)
        {
            List<DJ_GroupConsumRecord> ListRecord = GetRecordByCondition(dateyear, EntName, EntId).ToList();
            //过滤掉有相同团队的记录
            List<DJ_GroupConsumRecord> List = new List<DJ_GroupConsumRecord>();
            foreach (DJ_GroupConsumRecord item in ListRecord)
            {
                if (List.Where(x => x.Route.DJ_TourGroup.Id == item.Route.DJ_TourGroup.Id).Count() == 0)
                {
                    List.Add(item);
                }
            }
            List<DJ_TourEnterprise> ListTE=new List<DJ_TourEnterprise>();
            foreach (IGrouping<DJ_TourEnterprise,DJ_GroupConsumRecord> item in List.GroupBy(x => x.Enterprise).ToList())
	        {
                ListTE.Add(item.Key);
	        }
            return ListTE;
        }

        public IList<DJ_GroupConsumRecord> GetRecordByCondition(string dateyear, string EntName, int EntId)
        {
            return IDjgroup.GetRecordByCondition(dateyear, EntName, EntId);
        }
    }
}
