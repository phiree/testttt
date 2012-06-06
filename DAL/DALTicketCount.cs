using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;
using Model;

namespace DAL
{
    public class DALTicketCount:DalBase,ITicketCount
    {
        public  IList<Model.TicketCount> GetTicketCountByScenic(int scenicid)
        {
            string sql = "select tc from TicketCount tc where tc.scenic.Id=" + scenicid + " order by tc.TicketDate asc";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketCount>().ToList<TicketCount>();
        }


        public void SaveTicketCountByScenic(TicketCount tc)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Save(tc);
                x.Commit();
            }
        }
    }
}
