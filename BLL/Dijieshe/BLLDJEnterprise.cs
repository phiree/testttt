using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NHibernate;
namespace BLL
{
    public class BLLDJEnterprise
    {
        IDAL.IDJEnterprise daldjs = new DAL.DALDJEnterprise();

        #region DJS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="area"></param>
        /// <param name="cpn">管理人姓名</param>
        /// <param name="cpp">管理人手机</param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int AddDjs(string name, string address, Model.Area area, string cpn, string cpp, string phone)
        {
            Model.DJ_TourEnterprise djs = new Model.DJ_DijiesheInfo()
            {
                Name = name,
                Address = address,
                Area = area,
                ChargePersonName = cpn,
                ChargePersonPhone = cpp,
                Phone = phone,
                Type = Model.EnterpriseType.旅行社
            };
            return daldjs.AddDJS(djs);
        }
        public void Save(DJ_TourEnterprise enterprise)
        {
            if (enterprise.Type == EnterpriseType.旅行社)
            { 
             
            }
            daldjs.AddDJS(enterprise);
        }

        public IList<DJ_TourEnterprise> GetDjs8all()
        {
            return daldjs.GetDJS8All();
        }

        /// <summary>
        /// 查询地接社
        /// </summary>
        /// <param name="areaid">地区id</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8area(int areaid)
        {
            return GetDJS8Muti(areaid, null, null, null);
        }

        /// <summary>
        /// 查询地接社
        /// </summary>
        /// <param name="type">企业类型</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8type(string type)
        {
            return GetDJS8Muti(0, type, null, null);
        }

        /// <summary>
        /// 查询地接社
        /// </summary>
        /// <param name="id">企业id</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8id(string id)
        {
            return GetDJS8Muti(0, null, id, null);
        }

        /// <summary>
        /// 查询地接社
        /// </summary>
        /// <param name="name">名称查询</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8name(string name)
        {
            return GetDJS8Muti(0, null, null, name);
        }

        /// <summary>
        /// 旅游管理部门辖区的旅游企业
        /// </summary> 
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJSForDpt(string areaCode)
        {
            string ids = new BLLArea().GetChildAreaIds(areaCode);

            return daldjs.GetDJSInAreas(ids);
        }

        /// <summary>
        /// 多条件查询地接社
        /// </summary>
        /// <param name="areaid"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="namelike"></param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8Muti(int areaid, string type, string id, string namelike)
        {
            return daldjs.GetDJS8Muti(areaid, type, id, namelike);
        }

        /// <summary>
        /// 获取该地接社下旅游团队的奖励情况
        /// </summary>
        /// <param name="entid"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public IList<DJ_TourGroup> GetDJSRewordGroup(string entid, int day)
        {
            IList<DJ_TourGroup> ListTg=(GetDJS8id(entid)[0] as DJ_DijiesheInfo).Groups;
            List<DJ_TourGroup> List = new List<DJ_TourGroup>();
            foreach (DJ_TourGroup group in ListTg)
            {
                //排除还没结束，和不再指定时间范围内的
                if (DateTime.Parse(group.EndDate.ToShortDateString()) > DateTime.Parse(DateTime.Now.ToShortDateString()) && DateTime.Parse(group.EndDate.AddDays(day).ToShortDateString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    List.Add(group);
                }
            }
            return List;
        }

        /// <summary>
        /// 获取该企业的奖励情况
        /// </summary>
        /// <param name="entid">企业id</param>
        /// <param name="day">天数</param>
        public void GetDJSRewordEnt(string entid, int day,out int groupcount,out int peocount)
        {
            peocount = 0; groupcount = 0;
            List<DJ_Route> ListRoute = new DAL.DALDJ_Route().GetRouteByentid(int.Parse(entid)).ToList();
            List<DJ_TourGroup> ListGroup = new List<DJ_TourGroup>();
            foreach (DJ_Route route in ListRoute)
            {
                Model.DJ_GroupConsumRecord record= new BLLDJConsumRecord().GetGroupConsumRecordByRouteId(route.Id);
                if (record != null && DateTime.Parse(record.ConsumeTime.AddDays(day).ToShortDateString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    peocount += record.AdultsAmount + record.ChildrenAmount;
                    if (ListGroup.Where(x => x.Id == route.DJ_TourGroup.Id).Count() == 0)
                    {
                        ListGroup.Add(route.DJ_TourGroup);
                    }
                }
            }
            groupcount = ListGroup.Count;
        }
        /// <summary>
        /// 企业列表,排除景区
        /// </summary>
        /// <returns></returns>
        /// <param name="areacode">当前用户所管辖的区域</param>
        public IList<Model.DJ_TourEnterprise> GetEntList_ExcludeScenic(string areacode)
        {
            DAL.DALDJEnterprise dalEnt = new DAL.DALDJEnterprise();
            BLLArea bllArea = new BLLArea();
            string ids = bllArea.GetChildAreaIds(areacode);
            return dalEnt.GetEnterpriseWithoutScenic(ids);
        }
        #endregion

        #region group

        /// <summary>
        /// 添加团队基本信息
        /// </summary>
        public Guid AddBasicinfo(DJ_DijiesheInfo djs, string gname, DateTime gbdate, DateTime gedate, int gdays, int adults, int children)
        {
            DJ_TourGroup tg = new DJ_TourGroup();
            tg.DJ_DijiesheInfo = djs;
            tg.Name = gname;
            tg.BeginDate = gbdate;
            tg.EndDate = gedate;
            tg.DaysAmount = gdays;
            tg.AdultsAmount = adults;
            tg.ChildrenAmount = children;
            return daldjs.AddGroup(tg);
        }

        public void UpdateGroup(Model.DJ_TourGroup tg)
        {
            daldjs.UpdateGroup(tg);
        }

        public Model.DJ_TourGroup GetGroup8name(string name)
        {
            return daldjs.GetGroup8name(name);
        }

        public Model.DJ_TourGroup GetGroup8gid(string groupid)
        {
            return daldjs.GetGroup8gid(groupid);
        }

        public IList<Model.DJ_TourGroup> GetGroup8all()
        {
            return daldjs.GetGroup8all();
        }

        #endregion

        #region GroupMem

        /// <summary>
        /// 更新导游信息
        /// </summary>
        /// <param name="gg"></param>
        public void UpdateGuide(Model.DJ_Group_Worker gg)
        {
            daldjs.UpdateGuide(gg);
        }

        /// <summary>
        /// 更新司机信息
        /// </summary>
        /// <param name="gg"></param>
        public void UpdateDriver(Model.DJ_Group_Worker gd)
        {
            daldjs.UpdateDriver(gd);
        }

        /// <summary>
        /// 根据企业id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Model.DJ_Group_Worker> GetGroupmem8epid(string id)
        {
            return daldjs.GetGroupmem8epid(id);
        }
        
        /// <summary>
        /// 根据id获取 导游
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Model.DJ_Group_Worker> GetGuide8id(string id)
        {
            return daldjs.GetGuide8id(id);
        }

        /// <summary>
        /// 根据id获取司机
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Model.DJ_Group_Worker> GetDriver8id(string id)
        {
            return daldjs.GetDriver8id(id);
        }

        #endregion
    }
}
