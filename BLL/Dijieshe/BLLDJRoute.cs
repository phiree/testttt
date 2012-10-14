using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLDJRoute
    {

        IDAL.IDJRoute Idjroute = new DAL.DALDJ_Route();
        /// <summary>
        /// 根据预报时间得到当前的团队
        /// </summary>
        /// <param name="time">预报时间</param>
        /// <param name="teid">企业id</param>
        /// <returns>团队列表</returns>
        public IList<Model.DJ_TourGroup> GetTgByTime(DateTime time, int teid)
        {
            List<Model.DJ_TourGroup> ListAllTg = Idjroute.GetNotendGroup().ToList();
            List<Model.DJ_TourGroup> ListTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup tg in ListAllTg)
            {
                foreach (Model.DJ_Route route in tg.Routes)
                {
                    if (DateTime.Parse(tg.BeginDate.AddDays(route.DayNo - 1).ToShortDateString()) <= DateTime.Parse(time.ToShortDateString()) && DateTime.Parse(tg.BeginDate.AddDays(route.DayNo - 1).ToShortDateString())>=DateTime.Parse(DateTime.Now.ToShortDateString()) && DateTime.Parse(tg.EndDate.ToShortDateString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()) && route.Enterprise.Id == teid)
                    {
                        if (new DAL.DALDJ_GroupConsumRecord().GetGroupConsumRecordByRouteId(route.Id)==null)
                            ListTg.Add(tg);
                    }
                }
            }
            return ListTg;
        }

        public Model.DJ_Route GetById(Guid routeId)
        {
            return Idjroute.GetById(routeId);
        }
    }
}
