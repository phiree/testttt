using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALTicketPrice:DalBase,IDAL.ITicketPrice
    {

        public IList<Model.TicketPrice> GetTicketPriceByScenicId(int scenicid)
        {
            string sql = "select t from TicketPrice t where t.Ticket.Scenic.Id=" + scenicid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.TicketPrice>().ToList<Model.TicketPrice>();
        }

        public void SaveOrUpdateTicketPrice(Model.TicketPrice ticketprice)
        {
            using (var t = session.BeginTransaction())
            {
                session.SaveOrUpdate(ticketprice);
                session.Flush();
                t.Commit();
            }
        }

        public Model.TicketPrice GetTicketPriceByScenicandtypeid(Model.Ticket t, int typeid)
        {
            string sql = "select tp from TicketPrice tp where tp.Ticket.Id=" + t.Id + " and tp.PriceType=" + (int)typeid + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.TicketPrice>().Value;
        }




        public IList<Model.TicketPrice> GetTicketPriceByAreaId(int areaid, int typeid,string level,out int sceniccount,int pageindex,int pagesize)
        {
            string sql="";
            string sqlcount = "";
            if (level == "" || level == "全部")
            {
                if (areaid != 0)
                {
                    sql = "select tp from TicketPrice tp where tp.Ticket.Scenic.Area.Id=" + areaid + " and tp.PriceType=" + typeid + "";
                    sqlcount = "select count(*) from TicketPrice tp where tp.Ticket.Scenic.Area.Id=" + areaid + " and tp.PriceType=" + typeid + "";
                }
                else
                {
                    sql = "select tp from TicketPrice tp where tp.PriceType=" + typeid + "";
                    sqlcount = "select count(*) from TicketPrice tp where tp.PriceType=" + typeid + "";
                }
            }
            else
            {
                if (areaid != 0)
                {
                    sql = "select tp from TicketPrice tp where tp.Ticket.Scenic.Area.Id=" + areaid + " and tp.PriceType=" + typeid + " and tp.Ticket.Scenic.Level='" + level + "'";
                    sqlcount = "select count(*) from TicketPrice tp where tp.Ticket.Scenic.Area.Id=" + areaid + " and tp.PriceType=" + typeid + " and tp.Ticket.Scenic.Level='" + level + "'";
                }
                else
                {
                    sql = "select tp from TicketPrice tp where tp.PriceType=" + typeid + " and tp.Ticket.Scenic.Level='" + level + "'";
                    sqlcount = "select count(*) from TicketPrice tp where tp.PriceType=" + typeid + " and tp.Ticket.Scenic.Level='" + level + "'";
                }
            }
            IQuery query = session.CreateQuery(sql);
            IQuery querycount=session.CreateQuery(sqlcount);
            sceniccount = (int)querycount.FutureValue<long>().Value;
            return query.Future<Model.TicketPrice>().Skip((pageindex-1) * pagesize).Take(pagesize).ToList<Model.TicketPrice>();
        }
    }
}
