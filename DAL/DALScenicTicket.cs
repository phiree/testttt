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
            string sql = "select st.Scenic from ScenicTicket st where st.Ticket.Id=" + ticketId;
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Scenic>().ToList();
        }


        public IList<Model.Ticket> GetTicketByScenicId(int scenicId)
        {
            string sql = "select st.Ticket from ScenicTicket st where st.Scenic.Id=" + scenicId;
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().ToList();
        }


        public void Delete(Model.ScenicTicket st)
        {
            session.Delete(st);
            session.Flush();
        }

        public void Add(Model.ScenicTicket st)
        {
            if (Get(st.Ticket.Id, st.Scenic.Id) != null)
                return;
            session.Save(st);
            session.Flush();
        }


        public Model.ScenicTicket Get(int ticketid, int scenicId)
        {
            string sql = "select st from ScenicTicket st where st.Scenic.Id=" + scenicId
                + " and st.Ticket.Id= " + ticketid;
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.ScenicTicket>().Value;
        }
    }
}
