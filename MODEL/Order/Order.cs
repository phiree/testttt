using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Order
    {
        public Order()
        {
            OrderDetail = new List<OrderDetail>();
        }
        public Order(TourMembership member,string orderFrom)
            : this()
        {
           this.TourMembership = member;
           this.BuyTime = DateTime.Now;
           this.OrderFrom = orderFrom;
            
        }
        public virtual int Id { get; set; }
        public virtual TourMembership TourMembership { get; set; }
        /// <summary>
        /// 门票总数
        /// </summary>
        private int totalNum = 0;
      
        public virtual int TotalNum
        {
            get
            {
                totalNum = 0;
                foreach (OrderDetail od in OrderDetail)
                {
                    totalNum += od.Quantity;
                }
                return totalNum;
            }
            set
            {
                totalNum = value;
            }
        }
        /// <summary>
        /// 总价格
        /// </summary>
        private decimal totalPrice = 0.00m;
        public virtual decimal TotalPrice
        {
            get
            {
                totalPrice = 0;
                foreach (OrderDetail od in OrderDetail)
                {
                  
                    if (od.TicketPrice!= null)
                    {

                        totalPrice += od.Quantity * (od.TicketPrice.Price);
                    }
                }
                return totalPrice;
            }
            set { totalPrice = value; }
        }
      
        public virtual bool IsPaid { get; set; }
        /// <summary>
        /// pricet
        /// </summary>
        public virtual PriceType PriceType { get; set; }
        public virtual DateTime BuyTime { get; set; }
        /// <summary>
        ///  平台返回的支付交易号
        /// </summary>
        public virtual string TradeNo { get; set; }
        public virtual DateTime? PayTime { get; set; }
        public virtual IList<OrderDetail> OrderDetail { get; set; }
        public virtual bool GetUsedState
        {
            get
            {
                {
                    bool result = true;
                    foreach (OrderDetail item in OrderDetail)
                    {
                        foreach (TicketAssign item2 in item.TicketAssignList)
                        {
                            result = result & item2.IsUsed;
                        }
                    }
                    return result;
                }
            }
        }

        public virtual string Description
        {
            get
            {
                string desc = string.Empty;

                foreach (OrderDetail detail in OrderDetail)
                {
                    desc += detail.TicketPrice.Ticket.Scenic.Name + "*" + detail.Quantity + "|";
                }
                return desc.TrimEnd(new char[] { '|' });
            }
        }

        public virtual int State
        {
            get
            {
                if (OrderDetail[0].TicketPrice.PriceType == PriceType.PreOrder)
                {
                    return 2;
                }
                if (OrderDetail[0].TicketPrice.PriceType == PriceType.PayOnline)
                {
                    if (IsPaid == true)
                        return 1;
                    else
                        return 3;
                }
                return 1;
            }

            set
            {
                State = value;
            }
        }

        public virtual string Datepart {
            get
            {
                return BuyTime.Date.ToString();
            }
        }
        /// <summary>
        /// 订单来源:当前用途:记录活动合作伙伴的ProductCode
        /// </summary>
        public virtual string OrderFrom { get; set; }
    }

    public class MonthOrder
    {
        public virtual int Id { get; set; }
        public virtual string date { get; set; }
        public virtual Scenic scenic { get; set; }
        public virtual string orderway { get; set; }
        public virtual int num { get; set; }
        public virtual decimal totalprice { get; set; }
        public virtual bool paidstate { get; set; }
    }
}
