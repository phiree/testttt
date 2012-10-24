using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJTourGroup:DalBase,IDJTourGroup
    {
        public IList<Model.DJ_TourGroup> GetTourGroupByAll()
        {
            string sql = "select tg from DJ_TourGroup tg ";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().OrderByDescending(x=>x.BeginDate).ToList();
        }

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            string sql = "select tg from DJ_TourGroup tg where tg.GuideIdCardNo='" + idcard + "'";
            sql += " and '"+DateTime.Now.ToString()+"' between begindate and enddate";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }


        public Model.DJ_TourGroup GetTourGroupById(Guid id)
        {
            string sql = "select tg from DJ_TourGroup tg where tg.Id='" + id + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_TourGroup>().Value;
        }


        public IList<Model.DJ_TourGroup> GetTourGroupByTEId(int id)
        {
            List<Model.DJ_Route> list_route = new DALDJ_Route().GetRouteByTEid(id).ToList();
            List<Model.DJ_TourGroup> ListTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_Route route in list_route)
            {
                if (route.DJ_TourGroup.BeginDate.AddDays(route.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    ListTg.Add(route.DJ_TourGroup);
                }
            }
            return ListTg;
        }


        public Model.DJ_TourGroup GetTgByproductid(Guid proid)
        {
            string sql = "select tg from DJ_TourGroup tg where tg.DJ_Product.Id='" + proid + "'";
            sql += " and '" + DateTime.Now.ToString() + "' between begindate and enddate";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_TourGroup>().Value;
        }




        public IList<Model.DJ_TourGroup> GetTgByIdcardAndTE(string idcard, Model.DJ_TourEnterprise TE)
        {
            List<Model.DJ_TourGroup> ListTg = new DAL.DALDJ_Group_Worker().GetTgListByIdcard(idcard).ToList();
            List<Model.DJ_TourGroup> ListSelectTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup Tgitem in ListTg)
            {
                if (Tgitem.Routes.Where(x => x.Enterprise.Id == TE.Id).Count() > 0)
                {
                    ListSelectTg.Add(Tgitem);
                }
            }
            return ListSelectTg;
        }


        public IList<Model.DJ_Group_Worker> GetGuiderWorkerByTE(Model.DJ_TourEnterprise TE)
        {
            DAL.DALDJ_Route route = new DALDJ_Route();
            IList<Model.DJ_Route> ListRoute= route.GetRouteByTEid(TE.Id);
            List<Model.DJ_Group_Worker> Listgw = new List<Model.DJ_Group_Worker>();
            foreach (Model.DJ_Route routeitem in ListRoute)
            {
                if (routeitem.DJ_TourGroup.BeginDate.AddDays(routeitem.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    Listgw.AddRange(routeitem.DJ_TourGroup.Workers);
                }
            }
            return Listgw;
        }
    }
}
