using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJ_GroupConsumRecord:DalBase,IDJGroupConsumRecord
    {

        public void Save(Model.DJ_GroupConsumRecord group)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Save(group);
                x.Commit();
            }
        }


        public Model.DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(Guid RouteId)
        {
            string sql = "select gcr from DJ_GroupConsumRecord gcr where gcr.Route.Id='" + RouteId + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_GroupConsumRecord>().Value;
        }

        public Model.DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(string EnterpName)
        {
            string sql = "select gcr from DJ_GroupConsumRecord gcr where gcr.Enterprise.Name='" + EnterpName + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_GroupConsumRecord>().Value;
        }


        public IList<Model.DJ_TourGroup> GetFeRecordByETId(int etid)
        {
            //在dal中只查询出该旅游单位的记录
            string sql = "select r.Route.DJ_TourGroup from DJ_GroupConsumRecord r where r.Enterprise.Id=" + etid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }

        
    }
}
