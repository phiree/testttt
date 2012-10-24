using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;
namespace DAL
{
    public class DALDJ_Route:DalBase,IDAL.IDJRoute
    {

        public Model.DJ_Route GetById(Guid routeId)
        {
            return session.Get<DJ_Route>(routeId);
        }

        public void SaveOrUpdate(Model.DJ_Route route)
        {
            session.SaveOrUpdate(route);
            session.Flush();
        }

        public void Delete(Model.DJ_Route route)
        {
            session.Delete(route);
        }


        public IList<DJ_Product> GetPdByTimeandTEId(DateTime time, int teid)
        {
            string sql = "select r.DJ_Product from DJ_Route r where r.Enterprise.Id=" + teid + "";
            sql += " and BeginTime>'" + DateTime.Now.ToString() + "' and EndTime<'" + time + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Product>().ToList<Model.DJ_Product>();
        }


        public IList<DJ_Route> GetRouteByTEid(int teid)
        {
            string sql = "select r from DJ_Route r where r.Enterprise.Id=" + teid;
            IQuery query = session.CreateQuery(sql);
            return query.Future<DJ_Route>().ToList<DJ_Route>();
        }


        public IList<DJ_TourGroup> GetNotendGroup()
        {
            string sql = "select tg from DJ_TourGroup tg where tg.EndDate>" + DateTime.Now;
            IQuery query = session.CreateQuery(sql);
            return query.Future<DJ_TourGroup>().ToList<DJ_TourGroup>();
        }


        public IList<DJ_Route> GetRouteByentid(int entid)
        {
            string sql = "select r from DJ_Route r where r.Enterprise.Id=" + entid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<DJ_Route>().ToList<DJ_Route>();
        }


        public IList<DJ_Route> GetRouteByDayNoandGroupid(int dayno, Guid groupid,int entid)
        {
            string sql = "select r from DJ_Route r where r.DayNo=" + dayno + " and DJ_TourGroup.Id='" + groupid + "' and Enterprise.Id="+entid+" ";
            IQuery query = session.CreateQuery(sql);
            return query.Future<DJ_Route>().ToList<DJ_Route>();
        }


        public IList<DJ_Route> GetRouteByAllCondition(string groupname, string EntName, string BeginTime, string EndTime, int enterid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select r from DJ_Route r where 1=1 ");
            sql.Append(" and r.DJ_TourGroup.Name like '%" + groupname + "%'");
            sql.Append(" and r.Enterprise.Id="+enterid+"");
            sql.Append(" and r.DJ_TourGroup.DJ_DijiesheInfo.Name like '%" + EntName + "%'");
            sql.Append(" and r.DJ_TourGroup.EndDate>='" + DateTime.Now.ToShortDateString() + "'");
            sql.Append(" order by r.DJ_TourGroup.BeginDate desc,r.DayNo desc");
            IQuery query = session.CreateQuery(sql.ToString());
            IList<DJ_Route> ListDj_Route = query.Future<DJ_Route>().ToList<DJ_Route>();
            if (BeginTime != "" && EndTime == "")
            {
               ListDj_Route= ListDj_Route.Where(x => DateTime.Parse(x.DJ_TourGroup.BeginDate.AddDays(x.DayNo - 1).ToShortDateString()) >= DateTime.Parse(DateTime.Parse(BeginTime).ToShortDateString())).ToList<DJ_Route>();
            }
            if (EndTime != "" && BeginTime == "")
            {
                ListDj_Route = ListDj_Route.Where(x => DateTime.Parse(x.DJ_TourGroup.BeginDate.AddDays(x.DayNo - 1).ToShortDateString()) <= DateTime.Parse(DateTime.Parse(EndTime).ToShortDateString())).ToList<DJ_Route>();
            }
            if (BeginTime != "" && EndTime != "")
            {
                ListDj_Route = (from r in ListDj_Route
                                where DateTime.Parse(r.DJ_TourGroup.BeginDate.AddDays(r.DayNo - 1).ToShortDateString()) >= DateTime.Parse(DateTime.Parse(BeginTime).ToShortDateString())
                                    && DateTime.Parse(r.DJ_TourGroup.BeginDate.AddDays(r.DayNo - 1).ToShortDateString()) <= DateTime.Parse(DateTime.Parse(EndTime).ToShortDateString())
                                select r).ToList<DJ_Route>();
            }
            return ListDj_Route;
        }
    }
}
