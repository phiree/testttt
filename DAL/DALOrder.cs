using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALOrder : DalBase, IDAL.IOrder
    {
        public IList<Model.Order> GetListForUser(Guid memberId)
        {
            string sql = "select o from Order o where o.TourMembership.Id=:memberId ";
            IQuery query = session.CreateQuery(sql)
                .SetParameter("memberId", memberId);
            return query.Future<Model.Order>().OrderByDescending(x => x.BuyTime).ToList();
        }

        public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID, string dbegin, string dend)
        {
            string sql;
            IQuery query;
            if (!string.IsNullOrWhiteSpace(dbegin) || !string.IsNullOrWhiteSpace(dend))
            {
                if (orderID != 0)
                {
                    sql = " select od from OrderDetail od where od.Order.Id=:orderID and od.Order.BuyTime>=convert(datetime,'"
                        + dbegin + "') and od.Order.BuyTime<=convert(datetime,'" + dend + "')";
                    query = session.CreateQuery(sql);
                    query.SetParameter("orderID", orderID);
                }
                else
                {
                    sql = " select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=:scenicID and od.Order.BuyTime>=convert(datetime,'"
                        + dbegin + "') and od.Order.BuyTime<=convert(datetime,'" + dend + "')";
                    query = session.CreateQuery(sql);
                    query.SetParameter("scenicID", scenicID);
                }
                return query.Future<Model.OrderDetail>().ToList<Model.OrderDetail>();
            }
            else
            {
                if (orderID != 0)
                {
                    sql = " select od from OrderDetail od where od.Order.Id=:orderID ";
                    query = session.CreateQuery(sql);
                    query.SetParameter("orderID", orderID);
                }
                else
                {
                    sql = " select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=:scenicID ";
                    query = session.CreateQuery(sql);
                    query.SetParameter("scenicID", scenicID);
                }
                return query.Future<Model.OrderDetail>().ToList<Model.OrderDetail>();
            }
        }

        public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID, bool? isPaid, string dbegin, string dend)
        {
            if (isPaid == null) return GetListForUser(orderID, scenicID, dbegin, dend);
            string sql;
            IQuery query;
            //
            if (!string.IsNullOrWhiteSpace(dbegin) || !string.IsNullOrWhiteSpace(dend))
            {
                if (orderID != 0)
                {
                    sql = " select od from OrderDetail od where od.Order.Id=:orderID and od.Order.IsPaid=:isPaid  and od.Order.BuyTime>=convert(datetime,'"
                        + dbegin + "') and od.Order.BuyTime<=convert(datetime,'" + dend + "')";
                    query = session.CreateQuery(sql);
                    query.SetParameter("orderID", orderID);
                    query.SetParameter("isPaid", isPaid);
                }
                else
                {
                    sql = " select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=:scenicID and od.Order.IsPaid=:isPaid and od.Order.BuyTime>=convert(datetime,'"
                        + dbegin + "') and od.Order.BuyTime<=convert(datetime,'" + dend + "')";
                    query = session.CreateQuery(sql);
                    query.SetParameter("scenicID", scenicID);
                    query.SetParameter("isPaid", isPaid);
                }
                return query.Future<Model.OrderDetail>().ToList<Model.OrderDetail>();
            }
            else
            {
                if (orderID != 0)
                {
                    sql = " select od from OrderDetail od where od.Order.Id=:orderID and od.Order.IsPaid=:isPaid ";
                    query = session.CreateQuery(sql);
                    query.SetParameter("orderID", orderID);
                    query.SetParameter("isPaid", isPaid);
                }
                else
                {
                    sql = " select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=:scenicID and od.Order.IsPaid=:isPaid ";
                    query = session.CreateQuery(sql);
                    query.SetParameter("scenicID", scenicID);
                    query.SetParameter("isPaid", isPaid);
                }
                return query.Future<Model.OrderDetail>().ToList<Model.OrderDetail>();
            }
        }

        public int SaveOrUpdateOrder(Order order)
        {
            int result = (int)session.Save(order);
            session.Flush();
            return result;
        }

        /// <summary>
        /// 验票
        /// </summary>
        /// <param name="scenicid">景区id</param>
        /// <param name="idcard">身份证号</param>
        /// <returns></returns>
        public IList<TicketAssign> GetListByscidandcardid(int scenicid, string idcard)
        {
            string sql = "select ta from TicketAssign ta where ta.OrderDetail.TicketPrice.Ticket.Scenic.Id=:scenicid" +
                " and ta.IdCard=:idcard and IsUsed=0";
            IQuery query = session.CreateQuery(sql)
                .SetParameter("scenicid", scenicid)
                .SetParameter("idcard", idcard);
            return query.Future<Model.TicketAssign>().ToList<Model.TicketAssign>();
        }

        public Order GetOrderByOrderid(int orderid)
        {
            string sql = "select o from Order o where o.Id=" + orderid + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.Order>().Value;
        }
        /// <summary>
        /// 获取一段时间内的订单详情
        /// </summary>
        /// <param name="scenicid">景区</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">截至时间</param>
        /// <param name="paidstate">是否已付款7</param>
        /// <returns></returns>
        public IList<OrderDetail> GetMonthOrder(int scenicid, string dateBegin, string dateEnd, bool? paidstate)
        {
            string sql = "select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=" + scenicid
                + " and od.Order.PayTime>=convert(datetime,'" + dateBegin
                + "') and od.Order.PayTime<=convert(datetime,'" + dateEnd + "')";
            IQuery query = session.CreateQuery(sql);
            IList<OrderDetail> temp = query.Future<Model.OrderDetail>().ToList();
            return temp;
        }

        public IList<OrderDetail> GetMonthOrder(int scenicid, string dateBegin, string dateEnd)
        {
            string where = " where  od.TicketPrice.Ticket.Scenic.Id=" + scenicid
                + " and od.Order.PayTime>" + dateBegin
                + " and od.Order.PayTime<" + dateEnd
            + " and od.Order.IsPaid=1";


            string sql = "select od from OrderDetail od " + where;
            IQuery query = session.CreateQuery(sql);
            IList<OrderDetail> temp = query.Future<Model.OrderDetail>().ToList();
            return temp;
        }
        //获取某个月份的订单
        public MonthOrder GetPaidstate(string yearmonth, int scenicid, string orderway)
        {
            string sql = "select mo from MonthOrder mo where mo.scenic.Id=:scenicid and mo.date="
                + yearmonth + " and mo.orderway='" + orderway + "'";
            IQuery query = session.CreateQuery(sql)
                .SetParameter("scenicid", scenicid);
            return query.FutureValue<Model.MonthOrder>().Value;
        }

        public void AddMonthBill(string date, Model.Scenic scenic, string orderway, int num, decimal price, bool state)
        {
            MonthOrder mo = new MonthOrder()
            {
                date = date,
                scenic = scenic,
                orderway = orderway,
                num = num,
                totalprice = price,
                paidstate = state
            };
            session.SaveOrUpdate(mo);
        }

        public IList<OrderDetail> GetTotalTickets(DateTime datetime, int ticketid)
        {
            string sql = "select od from OrderDetail od where od.Order.BuyTime >'" + datetime + "' and od.Order.BuyTime<'" + datetime.AddDays(1)
                + "' and od.TicketPrice.Ticket.Id=" + ticketid;
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.OrderDetail>().ToList();
        }

        public IList<object[]> GetDaysOrderTotal()
        {
            string timeUnit = "100";
            string sql = "select CONVERT(VARCHAR(" + timeUnit + "), od.BuyTime, 102) timeUnit,count(*) count " +
"from TicketAssign ta, OrderDetail detail,[Order] od ,DJ_TourEnterprise dj,TicketPrice tp,Ticket t " +
"where ta.OrderDetail_id =detail.Id and detail.Order_id=od.Id " +
"and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id and t.Scenic_id=dj.Id group by CONVERT(VARCHAR(" + timeUnit + "), od.BuyTime, 102)";
            var query = session.CreateSQLQuery(sql)
                .AddScalar("timeUnit", NHibernateUtil.String)
                .AddScalar("count", NHibernateUtil.Int32);
            return query.List<object[]>();
        }

        public IList<object[]> GetDateOrderTotal(string datetime)
        {
            string timeUnit = "100";
            string sql = "select CONVERT(VARCHAR(" + timeUnit + "), od.BuyTime, 102) timeUnit,dj.Name djname,s.ScenicOrder so,COUNT(*) count " +
    "from TicketAssign ta, OrderDetail detail,[Order] od ,DJ_TourEnterprise dj,TicketPrice tp,Ticket t,Scenic s " +
    "where ta.OrderDetail_id =detail.Id and detail.Order_id=od.Id " +
    "and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id and t.Scenic_id=dj.Id and s.DJ_TourEnterprise_id=dj.Id " +
    "group by dj.Name,s.ScenicOrder , CONVERT(VARCHAR(" + timeUnit + "), od.BuyTime, 102) " +
    "order by s.ScenicOrder ";
            var query = session.CreateSQLQuery(sql)
                .AddScalar("timeUnit", NHibernateUtil.String)
                .AddScalar("djname", NHibernateUtil.String)
                .AddScalar("so", NHibernateUtil.Int32)
                .AddScalar("count", NHibernateUtil.Int32);
            var result1 = query.List<object[]>();
            IList<object[]> result2 = new List<object[]>();
            foreach (var item in result1)
            {
                if (item[0].ToString() == datetime)
                {
                    result2.Add(item);
                }
            }
            return result2;
        }

        public IList<object[]> GetDaysScenicOrderTotal(string scenicname)
        {
            string timeUnit = "100";
            string sql = "select CONVERT(VARCHAR(" + timeUnit + "), od.BuyTime, 102) timeUnit,dj.Name djname,s.ScenicOrder so,COUNT(*) count " +
    "from TicketAssign ta, OrderDetail detail,[Order] od ,DJ_TourEnterprise dj,TicketPrice tp,Ticket t,Scenic s " +
    "where ta.OrderDetail_id =detail.Id and detail.Order_id=od.Id " +
    "and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id and t.Scenic_id=dj.Id and s.DJ_TourEnterprise_id=dj.Id " +
    "group by dj.Name,s.ScenicOrder , CONVERT(VARCHAR(" + timeUnit + "), od.BuyTime, 102) " +
    "order by s.ScenicOrder ";
            var query = session.CreateSQLQuery(sql)
                .AddScalar("timeUnit", NHibernateUtil.String)
                .AddScalar("djname", NHibernateUtil.String)
                .AddScalar("so", NHibernateUtil.Int32)
                .AddScalar("count", NHibernateUtil.Int32);
            var result1 = query.List<object[]>();
            IList<object[]> result2 = new List<object[]>();
            foreach (var item in result1)
            {
                if (item[1].ToString() == scenicname)
                {
                    result2.Add(item);
                }
            }
            return result2;
        }

       
       


    }
}
