using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //每张门票分配一个身份证IDp        
    public class TicketAssign
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IdCard { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual DateTime? UsedTime { get; set; }
    }

    public class checkticketassign
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime BuyTime { get; set; }
    }
}
