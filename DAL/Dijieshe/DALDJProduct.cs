using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;

using NHibernate;

namespace DAL
{

    public class DALDJProduct : DalBase<Model.DJ_Product>
    {

        public IList<Model.DJ_Product> GetProductListByDjsId(int dijiesheId)
        {
            string query = "select P from DJ_Product as P where P.DJ_DijiesheInfo.Id=" + dijiesheId;
            return GetList(query);
        }
    }
}
