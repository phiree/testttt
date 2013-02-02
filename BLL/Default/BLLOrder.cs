using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLOrder:BLLBase<Order>
    {
        DAL.DALOrder dal = new DAL.DALOrder();
        public IList<Model.Order> GetListForUser(Guid memberId)
        {
            return dal.GetListForUser(memberId);
        }
        //public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID)
        //{
        //    return dal.GetListForUser(orderID, scenicID);
        //}
        public IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID, bool? isPaid, string dateBegin, string dateEnd)
        {
            #region 日期封装
            dateBegin = dateBegin.Substring(0, 4) + dateBegin.Substring(5, 2);
            dateEnd = dateEnd.Substring(0, 4) + dateEnd.Substring(5, 2);
            string datebegin = dateBegin.Substring(0, 4) + "-" + dateBegin.Substring(4, 2) + "-01";
            string dateend = string.Empty;
            if (dateEnd.Substring(4, 2) == "01" || dateEnd.Substring(4, 2) == "03" || dateEnd.Substring(4, 2) == "05" || dateEnd.Substring(4, 2) == "07" ||
                dateEnd.Substring(4, 2) == "08" || dateEnd.Substring(4, 2) == "10" || dateEnd.Substring(4, 2) == "12")
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(4, 2) + "-31";
            }
            if (dateEnd.Substring(4, 2) == "04" || dateEnd.Substring(4, 2) == "06" || dateEnd.Substring(4, 2) == "09" || dateEnd.Substring(4, 2) == "11")
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(4, 2) + "-30";
            }
            if (dateEnd.Substring(4, 2) == "02" && int.Parse(dateEnd.Substring(0, 4)) % 4 == 0)
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(4, 2) + "-29";
            }
            if (dateEnd.Substring(4, 2) == "02" && int.Parse(dateEnd.Substring(0, 4)) % 4 != 0)
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(4, 2) + "-28";
            }
            #endregion
            return dal.GetListForUser(orderID, scenicID, isPaid, datebegin, dateend);
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
            #region 日期封装
            string datebegin = dateBegin.Substring(0, 4) + "-" + dateBegin.Substring(5, 2) + "-01";
            string dateend = string.Empty;
            if (dateEnd.Substring(5, 2) == "01"||dateEnd.Substring(5, 2) == "03"||dateEnd.Substring(5, 2) == "05"||dateEnd.Substring(5, 2) == "07"||
                dateEnd.Substring(5, 2) == "08"||dateEnd.Substring(5, 2) == "10"||dateEnd.Substring(5, 2) == "12")
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(5, 2) + "-31";
            }
            if (dateEnd.Substring(5, 2) == "04" || dateEnd.Substring(5, 2) == "06" || dateEnd.Substring(5, 2) == "09" || dateEnd.Substring(5, 2) == "11" )
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(5, 2) + "-30";
            }
            if (dateEnd.Substring(5, 2) == "02" && int.Parse(dateEnd.Substring(0, 4))%4==0)
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(5, 2) + "-29";
            }
            if (dateEnd.Substring(5, 2) == "02" && int.Parse(dateEnd.Substring(0, 4)) % 4 != 0)
            {
                dateend = dateEnd.Substring(0, 4) + "-" + dateEnd.Substring(5, 2) + "-28";
            }
            #endregion
            IList<OrderDetail> odlist = dal.GetMonthOrder(scenicid, datebegin, dateend, paidstate);
            IList<MonthOrder> molist = new List<MonthOrder>();
            int idatebegin = int.Parse(dateBegin.Substring(0,4)+dateBegin.Substring(5,2));
            int idateend = int.Parse(dateEnd.Substring(0,4)+dateEnd.Substring(5,2));
            int totalnum = 0;
            decimal totalprice = 0;
            for (int i = idatebegin; i <= idateend; i++)
            {
                if (i % 100 == 13)
                {
                    i = (idatebegin / 100 + 1) * 100 + 1;
                }
                string startwith = i.ToString("D6").Substring(0, 4) + "-" + i.ToString("D6").Substring(4, 2);
                IEnumerable<OrderDetail> temp = odlist.Where(x => ((DateTime)x.Order.PayTime).ToString("yyyy-MM-dd").StartsWith(startwith));
                var temp_online = temp.Where(x => x.TicketPrice.PriceType == PriceType.PayOnline);
                var temp_book = temp.Where(x => x.TicketPrice.PriceType == PriceType.PreOrder);
                //网上支付订单统计
                totalnum = temp_online.Sum(x => x.Quantity);
                totalprice = temp_online.Sum(x => x.Order.TotalPrice);
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
                totalprice = temp_book.Sum(x => x.Order.TotalPrice);
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
            for (int i = idatebegin; i <= idateend && i % 100 < 13; i++)
            {

            }
            return molist;
        }

        /// <summary>
        /// 获取每天的销售数据总和
        /// </summary>
        /// <returns></returns>
        public IList<object[]> GetDaysOrderTotal()
        {
            return dal.GetDaysOrderTotal();
        }
        /// <summary>
        /// 获取某天所有景区销售
        /// </summary>
        /// <returns></returns>
        public IList<object[]> GetDateOrderTotal(string datetime)
        {
            return dal.GetDateOrderTotal(datetime);
        }
        /// <summary>
        /// 获取所有天某景区销售
        /// </summary>
        /// <returns></returns>
        public IList<object[]> GetDaysScenicOrderTotal(string scenicname)
        {
            return dal.GetDaysScenicOrderTotal(scenicname);
        }
        /// <summary>
        /// 自动创建多个订单.
        /// </summary>
        /// <param name="activityName"></param>
        /// <param name="partnerCode"></param>
        /// <param name="memberId"></param>
        /// <param name="ticketList"></param>
        /// <param name="idcardno"></param>
        /// <param name="assignName"></param>
        /// <param name="amount"></param>
        /// <param name="errMsg"></param>
        public void CreateOrder(string activityName, string partnerCode, Guid memberId, Ticket ticket, string idcardno, string assignName, int amount, out string errMsg)
        {
            List<Ticket> ticketList = new List<Ticket>();

            if (ticket is TicketUnion)
            {
                foreach (Ticket t in ((TicketUnion)ticket).TicketList)
                {
                    ticketList.Add(t);
                }
            }
            else
            {
                ticketList.Add(ticket);
            }
            
            dal.CreateMultiOrder(activityName, partnerCode, memberId, ticketList, idcardno, assignName, amount, out errMsg);
        }
    }
}
