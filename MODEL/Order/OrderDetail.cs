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
        public OrderDetail()
        {
            TicketAssignList = new List<TicketAssign>();
        }
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        /// <summary>
        /// 景区--门票类型--门票价格
        /// </summary>
        public virtual TicketPrice TicketPrice { get; set; }
        //价格冗余
        public virtual decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual string Remark { get; set; }
       
        public virtual IList<TicketAssign> TicketAssignList { get; set; }
    }
}
