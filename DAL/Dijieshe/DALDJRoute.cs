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
    }
}
