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
            string sql = "select o from Order o where o.MemberId=:memberId";
            IQuery query = session.CreateQuery(sql)
                .SetParameter("memberId", memberId);
            return query.Future<Model.Order>().ToList<Model.Order>();
        }

        public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID, string dbegin, string dend)
        {
            string sql;
            IQuery query;
            if (!string.IsNullOrWhiteSpace(dbegin) || !string.IsNullOrWhiteSpace(dend))
            {
                if (orderID != 0)
                {
                    sql = " select od from OrderDetail od where od.Order.Id=:orderID and od.Order.BuyTime>" + dbegin + " and od.Order.BuyTime<" + dend;
                    query = session.CreateQuery(sql);
                    query.SetParameter("orderID", orderID);
                }
                else
                {
                    sql = " select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=:scenicID and od.Order.BuyTime>" + dbegin + " and od.Order.BuyTime<" + dend;
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
            if (!string.IsNullOrWhiteSpace(dbegin) || !string.IsNullOrWhiteSpace(dend))
            {
                if (orderID != 0)
                {
                    sql = " select od from OrderDetail od where od.Order.Id=:orderID and od.Order.IsPaid=:isPaid  and od.Order.BuyTime>" + dbegin + " and od.Order.BuyTime<" + dend;
                    query = session.CreateQuery(sql);
                    query.SetParameter("orderID", orderID);
                    query.SetParameter("isPaid", isPaid);
                }
                else
                {
                    sql = " select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=:scenicID and od.Order.IsPaid=:isPaid and od.Order.BuyTime>" + dbegin + " and od.Order.BuyTime<" + dend;
                    query = session.CreateQuery(sql);
                    query.SetParameter("scenicID", scenicID);
                    query.SetParameter("isPaid", isPaid);
                }
                return query.Future<Model.OrderDetail>().ToList<Model.OrderDetail>();
            }
            return null;
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

        public IList<OrderDetail> GetMonthOrder(int scenicid, string dateBegin, string dateEnd, bool? paidstate)
        {
            string sql = "select od from OrderDetail od where od.TicketPrice.Ticket.Scenic.Id=" + scenicid
                + " and od.Order.PayTime>" + dateBegin
                + " and od.Order.PayTime<" + dateEnd;
            IQuery query = session.CreateQuery(sql);
            IList<OrderDetail> temp = query.Future<Model.OrderDetail>().ToList();
            return temp;
        }

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
    }
}
