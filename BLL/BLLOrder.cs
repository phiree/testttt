using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLOrder
    {
        IDAL.IOrder dal = new DAL.DALOrder();
        public IList<Model.Order> GetListForUser(Guid memberId)
        {
            return dal.GetListForUser(memberId);
        }
        //public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID)
        //{
        //    return dal.GetListForUser(orderID, scenicID);
        //}
        public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID, bool? isPaid,string dbegin,string dend)
        {
            return dal.GetListForUser(orderID, scenicID, isPaid,dbegin,dend);
        }
        public int SaveOrUpdateOrder(Order order)
        {
            return dal.SaveOrUpdateOrder(order);
        }
        public IList<TicketAssign> GetListByscidandcardid(int scenicid, string idcard)
        {
            return dal.GetListByscidandcardid(scenicid, idcard);
        }
        public Order GetOrderByOrderid(int orderid)
        {
            return dal.GetOrderByOrderid(orderid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenicid"></param>
        /// <param name="dateBegin">日期6位数  yyyyMM</param>
        /// <param name="dateEnd">限定同1年, UI层判断</param>
        /// <param name="paidstate"></param>
        /// <param name="paidway"></param>
        /// <returns></returns>
        public IList<MonthOrder> GetMonthOrder(int scenicid, string dateBegin, string dateEnd, bool? paidstate)
        {
            IList<OrderDetail> odlist = dal.GetMonthOrder(scenicid, dateBegin, dateEnd, paidstate);
            IList<MonthOrder> molist = new List<MonthOrder>();
            int idatebegin = int.Parse(dateBegin);
            int idateend = int.Parse(dateEnd);
            int totalnum = 0;
            decimal totalprice = 0;
            for (int i = idatebegin; i <= idateend && i%100<13; i++)
            {
                IEnumerable<OrderDetail> temp = odlist.Where(x => x.Order.PayTime.ToString() == i.ToString("D6"));
                var temp_online = temp.Where(x => x.TicketPrice.PriceType == PriceType.PayOnline);
                var temp_book = temp.Where(x => x.TicketPrice.PriceType == PriceType.PreOrder);
                //网上支付订单统计
                totalnum = temp_online.Sum(x => x.Quantity);
                totalprice = temp_online.Sum(x => x.TicketPrice.Ticket.GetPrice(x.TicketPrice.PriceType));
                MonthOrder motemp = dal.GetPaidstate(i.ToString("D6"), scenicid, "在线支付");
                if (paidstate == null || (motemp == null && paidstate == false) || (motemp != null && paidstate==true))
                {
                    molist.Add(new MonthOrder()
                    {
                        date = i.ToString("D6"),
                        orderway = "在线支付",
                        num = totalnum,
                        totalprice = totalprice,
                        paidstate = motemp == null ? false : motemp.paidstate
                    });
                }
                //预定订单明细统计
                totalnum = temp_book.Sum(x => x.Quantity);
                totalprice = temp_book.Sum(x => x.TicketPrice.Ticket.GetPrice(x.TicketPrice.PriceType));
                motemp = dal.GetPaidstate(i.ToString("D6"), scenicid, "预定");
                if (paidstate == null || (motemp == null && paidstate == false) || (motemp != null && paidstate == true))
                {
                    molist.Add(new MonthOrder()
                    {
                        date = i.ToString("D6"),
                        orderway = "预定",
                        num = totalnum,
                        totalprice = totalprice,
                        paidstate = motemp == null ? false : motemp.paidstate
                    });
                }
            }
            return molist;
        }

        public void AddMonthBill(string date, Model.Scenic scenic, string orderway, int num, decimal price, bool state)
        {
            dal.AddMonthBill(date, scenic, orderway, num, price, state);
        }

        public IList<MonthOrder> BuildMonthOrder(int scenicid, string dateBegin, string dateEnd)
        {
            IList<OrderDetail> odlist = dal.GetMonthOrder(scenicid, dateBegin, dateEnd);
            IList<MonthOrder> molist = new List<MonthOrder>();
             int idatebegin = int.Parse(dateBegin);
            int idateend = int.Parse(dateEnd);
            int totalnum = 0;
            decimal totalprice = 0;
            for (int i = idatebegin; i <= idateend && i % 100 < 13; i++)
            {

            }
            return molist;
        }
    }
}
