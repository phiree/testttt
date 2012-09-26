using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALDJProduct : DalBase,IDAL.IDJProduct
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
    }
}
