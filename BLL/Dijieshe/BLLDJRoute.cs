using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
namespace BLL
{
    public class BLLDJRoute
    {

      public  DALDJ_Route Idjroute = new DAL.DALDJ_Route();
      BLLDJEnterprise bllEnt = new BLLDJEnterprise();
        /// <summary>
        /// 根据预报时间得到当前的团队
        /// </summary>
        /// <param name="time">预报时间</param>
        /// <param name="teid">企业id</param>
        /// <returns>团队列表</returns>
        public IList<Model.DJ_Route> GetTgByTime(DateTime time, int teid)
        {
            List<Model.DJ_TourGroup> ListAllTg = Idjroute.GetNotendGroup().ToList();
            List<Model.DJ_Route> ListRoute = new List<Model.DJ_Route>();
            foreach (Model.DJ_TourGroup tg in ListAllTg)
            {
                foreach (Model.DJ_Route route in tg.Routes)
                {
                    if (DateTime.Parse(tg.BeginDate.AddDays(route.DayNo - 1).ToShortDateString()) <= DateTime.Parse(time.ToShortDateString()) && DateTime.Parse(tg.BeginDate.AddDays(route.DayNo - 1).ToShortDateString())>=DateTime.Parse(DateTime.Now.ToShortDateString()) && DateTime.Parse(tg.EndDate.ToShortDateString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()) && route.Enterprise.Id == teid)
                    {
                        if (new DAL.DALDJ_GroupConsumRecord().GetGroupConsumRecordByRouteId(route.Id)==null)
                            ListRoute.Add(route);
                    }
                }
            }
            return ListRoute;
        }

        public Model.DJ_Route GetById(Guid routeId)
        {
            return Idjroute.GetOne(routeId);
        }

        public IList<Model.DJ_Route> GetRouteByDayNoandGroupid(int dayno, Guid groupid ,int entid)
        {
            return Idjroute.GetRouteByDayNoandGroupid(dayno, groupid,entid);
        }
        public void Save(Model.DJ_Route route)
        {
            Idjroute.Save(route);
        }
        public void SaveOrUpdate(Model.DJ_Route route)
        {
            Idjroute.SaveOrUpdate(route);
        }

        public void Delete(Model.DJ_Route route)
        {
            Idjroute.Delete(route);
        }
        public IList<Model.DJ_Route> GetRouteByAllCondition(string groupname, string EntName, string BeginTime, string EndTime,int enterid)
        {
            IList<Model.DJ_Route> ListRoute= Idjroute.GetRouteByAllCondition(groupname, EntName, BeginTime, EndTime,enterid);
            List<Model.DJ_Route> ListWroute = new List<Model.DJ_Route>();
            if (ListRoute.Count > 1)
            {
                ListWroute.Add(ListRoute[0]);
                for (int i = 1; i < ListRoute.Count; i++)
                {
                    if (ListRoute[i].DJ_TourGroup.Id == ListRoute[i - 1].DJ_TourGroup.Id && (ListRoute[i - 1].DayNo - ListRoute[i].DayNo) <= 1)
                    {
                        continue;
                    }
                    else
                    {
                        ListWroute.Add(ListRoute[i]);
                        break;
                    }
                }

            }
            else
                ListWroute.AddRange(ListRoute);
            //去掉验证过的
            for (int i = 0;; i++)
            {
                if (i < ListWroute.Count)
                {
                    if (new BLLDJConsumRecord().GetGroupConsumRecordByRouteId(ListWroute[i].Id) != null)
                    {
                        ListWroute.Remove(ListWroute[i]);
                    }
                }
                else
                    break;
            }
            return ListWroute;
        }

        public void SaveFromNameList(Model.DJ_TourGroup CurrentGroup, int dayNo, List<string> entNames,out string errMsg)
        {
            errMsg = string.Empty;

            foreach (DJ_Route exsitRoute in CurrentGroup.Routes) {

                Delete(exsitRoute);
            }
            CurrentGroup.Routes.Clear();

            foreach (string entName in entNames)
            {
                DJ_TourEnterprise ent = bllEnt.GetEntByName(entName);
                if (ent == null)
                {
                    errMsg = "企业名称有误:" + entName+Environment.NewLine;
                    continue;
                }
                DJ_Route newRoute = new DJ_Route();
                newRoute.DayNo = dayNo;
                newRoute.DJ_TourGroup = CurrentGroup;
                newRoute.Enterprise = ent;
                Save(newRoute);
            }
        }
    }
}
