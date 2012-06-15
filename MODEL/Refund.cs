using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 退款记录
    /// </summary>
    public class Refund
    {
        public virtual Guid Id { get; set; }
        public virtual string RefundSerialNo { get; set; }
        public virtual string RefundTradeNo { get; set; }
        public virtual string TargetTradeNo { get; set; }
        public virtual TourMembership Member { get; set; }
        public virtual Order Order { get; set; }
       
        public virtual decimal RefundPrice { get; set; }

        decimal totalPrice = 0;
        public virtual decimal TotalReturnAmount
        {
            get
            {
                totalPrice = 0;
                foreach (OrderDetail od in Order.OrderDetail)
                {
                    foreach (TicketAssign ta in od.TicketAssignList)
                    {
                        if (!ta.IsUsed)
                        {
                            totalPrice += od.TicketPrice.Price;
                        }
                    }
                }
                return totalPrice;
            }
            set { }
        }
        /// <summary>
        /// 申请 时间
        /// </summary>
        public virtual DateTime ApplyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ReturnTime { get; set; }
    }
}
