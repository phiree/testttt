using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;
using NHibernate;

namespace DAL
{
    public class DALContractScenicPrice:DalBase,IContractScenicPrice
    {

        public void SaveOrUpdate(ContractScenicPrice csp)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(csp);
                x.Commit();
            }
        }


        public ContractScenicPrice GetcspByscid(int scid)
        {
            string sql = "select csp from ContractScenicPrice csp where csp.Scenic.Id=" + scid + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<ContractScenicPrice>().Value;
        }
    }
}
