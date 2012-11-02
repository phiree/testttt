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
       public DAL.DALDJEnterprise daldjs = new DAL.DALDJEnterprise();
        BLLArea bllArea = new BLLArea();

        #region DJS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="area"></param>
        /// <param name="cpn">管理人姓�/param>
        /// <param name="cpp">管理人手�/param>
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

        public void UpdateDjs(Model.DJ_TourEnterprise obj)
        {
            daldjs.UpdateDJS(obj);
        }

        public IList<DJ_TourEnterprise> GetDjs8all()
        {
            return daldjs.GetDJS8All();
        }

        /// <summary>
        /// 查询地接�
        /// </summary>
        /// <param name="areaid">地区id</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8area(int areaid)
        {
            return GetDJS8Muti(areaid, null, null, null);
        }

        /// <summary>
        /// 查询地接�
        /// </summary>
        /// <param name="type">企业类型</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8type(string type)
        {
            return GetDJS8Muti(0, type, null, null);
        }

        /// <summary>
        /// 查询地接�
        /// </summary>
        /// <param name="id">企业id</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8id(string id)
        {
            return GetDJS8Muti(0, null, id, null);
        }

        /// <summary>
        /// 查询地接�
        /// </summary>
        /// <param name="name">名称查询</param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJS8name(string name)
        {
            return GetDJS8Muti(0, null, null, name);
        }

        /// <summary>
        /// 旅游管理部门辖区的旅游企�
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
        /// <param name="type">Model.EnterpriseType</param>
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
            IList<DJ_TourGroup> ListTg = (GetDJS8id(entid)[0] as DJ_DijiesheInfo).Groups;
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
        public void GetDJSRewordEnt(string entid, int day, out int groupcount, out int peocount)
        {
            peocount = 0; groupcount = 0;
            List<DJ_Route> ListRoute = new DAL.DALDJ_Route().GetRouteByentid(int.Parse(entid)).ToList();
            List<DJ_TourGroup> ListGroup = new List<DJ_TourGroup>();
            foreach (DJ_Route route in ListRoute)
            {
                Model.DJ_GroupConsumRecord record = new BLLDJConsumRecord().GetGroupConsumRecordByRouteId(route.Id);
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
        /// <param name="areacode">当前用户所管辖的区�/param>

        public IList<Model.DJ_TourEnterprise> GetEntList_ExcludeScenic(string areacode)
        {


            return daldjs.GetList(areacode, EnterpriseType.宾馆 | EnterpriseType.饭店 | EnterpriseType.购物点| EnterpriseType.景点
                 , null);

            //DAL.DALDJEnterprise dalEnt = new DAL.DALDJEnterprise();
            //BLLArea bllArea = new BLLArea();
            //string ids = bllArea.GetChildAreaIds(areacode);
            //return dalEnt.GetEnterpriseWithoutScenic(ids);
        }
        /// <summary>
        /// 辖区在奖励范围内的企�
        /// </summary>
        /// <param name="areacode"></param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetRecEnt(string areacode)
        {
            DAL.DALDJEnterprise dalEnt = new DAL.DALDJEnterprise();
            BLLArea bllArea = new BLLArea();
            string ids = bllArea.GetChildAreaIds(areacode);

            return dalEnt.GetEnterpriseList(ids, true, false, true);
        }

        #endregion

        #region 设置企业奖励范围情况
        /// <summary>
        /// 
        /// </summary>
        /// <param name="govLevel">设置的级�省市�/param>
        /// <param name="ent">需要设置的企业</param>
        /// <param name="targetType">目标�/param>
        public void SetVerify(DJ_TourEnterprise ent, RewardType targetType)
        {
            AreaLevel level = ent.Area.Level;
            switch (level)
            {
                case AreaLevel.区县:
                    ent.CountryVeryfyState = GetFinalVeryfyState(ent.CountryVeryfyState, targetType);
                  
                    break;

                case AreaLevel.市:
                    ent.CityVeryfyState = GetFinalVeryfyState(ent.CityVeryfyState, targetType);
                  
                    break;
                case AreaLevel.省:
                    ent.ProvinceVeryfyState = GetFinalVeryfyState(ent.ProvinceVeryfyState, targetType);
                 
                    break;
            }
            ent.LastUpdateTime = DateTime.Now;
            daldjs.Save(ent);
        }

        public void SetVerify(Area area, string entName, RewardType targetType, EnterpriseType entType, out string errMsg)
        {
            errMsg = string.Empty;
            IList<DJ_TourEnterprise> ents = GetDJS8name(entName);
            DJ_TourEnterprise ent = new DJ_TourEnterprise();
            if (ents.Count > 0)
            {
                if (ents.Count > 1)
                {
                    TourLog.LogError(this.GetType() + ":" + ents.Count + "个企�重名:" + entName);
                }
                ent = ents[0];
                ;

            }
            else if (ents.Count == 0)
            {

                ent.Name = entName;
                ent.Area = area;
                ent.Type = entType;
                Save(ent);


            }
            SetVerify(ent, targetType);
        }
        /// <summary>
        /// 根据原有认证状态和目标状�计算 应该设置的状�
        /// </summary>
        /// <param name="original"></param>
        /// <param name="target"></param>
        private RewardType GetFinalVeryfyState(RewardType original, RewardType target)
        {


            RewardType finalType = RewardType.从未纳入;
            switch (original)
            {
                case 0:
                    finalType = target;
                    break;
                case RewardType.从未纳入:
                    switch (target)
                    {
                        case RewardType.从未纳入:
                        case RewardType.纳入后移除:
                            break;
                        case RewardType.已纳入:
                            finalType = RewardType.已纳入;
                            break;
                    }
                    break;

                case RewardType.纳入后移除:
                    switch (target)
                    {
                        case RewardType.从未纳入:
                        case RewardType.纳入后移除:
                            break;
                        case RewardType.已纳入:
                            finalType = RewardType.已纳入;
                            break;
                    }
                    break;
                case RewardType.已纳入:
                    switch (target)
                    {
                        case RewardType.从未纳入:
                        case RewardType.纳入后移除:
                            finalType = RewardType.纳入后移除;
                            break;
                        case RewardType.已纳入:
                            break;
                    }
                    break;
            }
            return finalType;
        }

        public void Save(DJ_TourEnterprise ent)
        {

            daldjs.Save(ent);
        }

        #endregion

        #region group

        /// <summary>
        /// 管理部门辖区的纳�已移�企业列表
        /// </summary>
        /// <param name="gov"></param>
        /// <returns></returns>
        public IList<DJ_TourEnterprise> GetRewardEntList(DJ_GovManageDepartment gov, EnterpriseType? entType, RewardType rewardType)
        {



            IList<DJ_TourEnterprise> entList = daldjs.GetList(gov.Area.Code, entType, rewardType);

            return entList;
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
