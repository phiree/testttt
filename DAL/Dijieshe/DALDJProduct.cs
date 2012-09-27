using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;

using NHibernate;

namespace DAL
{

    public class DALDJProduct : DalBase, IDAL.IDJProduct
    {

        public Model.DJ_Product GetById(Guid productId)
        {
            return session.Get<Model.DJ_Product>(productId);
        }
        public void Save(Model.DJ_Product product)
        {
            session.Save(product);
            session.Flush();
        }


        public IList<Model.DJ_Product> GetListByTEId(Guid TEId)
        {
            string sql = "select r.DJ_Product  from DJ_Route r where r.Enterprise.Id='" + TEId + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Product>().ToList<Model.DJ_Product>();

        }
    }
}
