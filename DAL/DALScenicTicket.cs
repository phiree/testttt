using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
namespace DAL
{
    public class DALScenicTicket : DalBase, IDAL.IScenicTicket
    {

        public IList<Model.Scenic> GetScenicsByTicketId(int ticketId)
        {
            string sql = "select t from ScenicTicket st where st.Ticket.Id=" + ticketId;
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Scenic>().ToList();
        }
    }
}
