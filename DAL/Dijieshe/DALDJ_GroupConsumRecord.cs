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
    }
}
