using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 订单详情
    /// </summary>
    public class OrderDetail
    {
        public OrderDetail(int quantity, TicketPrice ticketPrice, string remark):this()
        {
            this.Quantity = quantity;
            this.TicketPrice = ticketPrice;
            this.Remark = remark;
        }

        public OrderDetail()
        {
            TicketAssignList = new List<TicketAssign>();
            ChildTicketDetail = new List<OrderDetail>();
        }
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        /// <summary>
        /// 景区--门票类型--门票价格
        /// </summary>
        public virtual TicketPrice TicketPrice { get; set; }
        /// <summary>
        /// 价格冗余
        /// </summary>
        public virtual decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual string Remark { get; set; }
        public virtual IList<TicketAssign> TicketAssignList { get; set; }
        //是否是联票的子票 断言:子票不会单独出售
        public virtual bool IsChildTicket { get{
         return TicketPrice.Ticket.As<Ticket>() is TicketUnion;
        } }
        //为联票的子票创建的详情
        public IList<OrderDetail> ChildTicketDetail { get; set; }

      
    }
}
