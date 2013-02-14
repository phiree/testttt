using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALTicket:DalBase<Model.Ticket>
    {

        public IList<Model.Ticket> GetTicketByAreaId(int areaid)
        {
            string sql = "select t from Ticket t where t.Scenic.Area.Id=" + areaid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().ToList<Model.Ticket>();
        }


        public IList<Model.Ticket> GetTicketByscId(int scid)
        {
            var ticketList = session.QueryOver<Model.Ticket>().Where(x => x.Scenic.Id == scid && x.IsMain == true).List();
            //string sql = "select t from Ticket t where t.Scenic.Id="+scid+"";
            //IQuery query = session.CreateQuery(sql);
            return ticketList;
        }


        public void SaveOrUpdateTicket(Model.Ticket ticket)
        {
            using (var t=session.BeginTransaction())
            {
                session.SaveOrUpdate(ticket);
                session.Flush();
                t.Commit();
            }
        }

        public void SaveOrUpdateTicket(IList<Model.Ticket> tickets)
        {
            foreach (var item in tickets)
            {
                SaveOrUpdateTicket(item);
            }
        }
        public Model.Ticket Get(int ticketId)
        {
           var t = session.Get<Model.Ticket>(ticketId);
            return t;
        }
        public Model.Ticket GetByScenicSeo(string scenicSeoName)
        {
           var strQuery = "select t from Ticket t where t.Scenic.SeoName ='" + scenicSeoName + "'";
           IQuery qry = session.CreateQuery(strQuery);
           Model.Ticket t= qry.FutureValue<Model.Ticket>().Value;
           return t;
        }


        public IList<Model.Ticket> GetTp(int scid)
        {
            string sql = "select t from Ticket t where t.Scenic.Id=" + scid + " and Lock=false";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().OrderByDescending(x=>x.OrderNumber).ToList();
        }

        public Model.Ticket GetByProductCode(string productCode)
        {
            var strQuery = "select t from Ticket t where t.ProductCode ='" + productCode + "'";
            IQuery qry = session.CreateQuery(strQuery);
            Model.Ticket t =(Model.Ticket)session.GetSessionImplementation().PersistenceContext.Unproxy( qry.FutureValue<Model.Ticket>().Value);
            return t;
        }


       
        public IList<Model.Ticket> GetListByMultitTicketCode(IList<string> ticketCodes)
        {
           return  session.QueryOver<Model.Ticket>()
                .Where(x => ticketCodes.Contains(x.ProductCode)).List();
        }
    }
}
