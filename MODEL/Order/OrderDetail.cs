using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            TicketAssignList = new List<TicketAssign>();
        }
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        public virtual TicketPrice TicketPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual string Remark { get; set; }
       
        public virtual IList<TicketAssign> TicketAssignList { get; set; }
    }
}
