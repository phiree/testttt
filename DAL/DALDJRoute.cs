using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJRoute:DalBase,IDJRoute
    {
        public IList<Model.DJ_Product> GetPdByTimeandTEId(DateTime time, Guid teid)
        {
            string sql = "select r.DJ_Product from DJ_Route r where r.Enterprise.Id='"+teid+"'";
            sql += " and BeginTime>'"+DateTime.Now.ToString()+"' and EndTime<'"+time+"'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Product>().ToList<Model.DJ_Product>();
        }
    }
}
