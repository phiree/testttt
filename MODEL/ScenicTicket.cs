using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ScenicTicket
    {
        public virtual Guid Id {get;set;}
        public virtual Scenic Scenic {get;set;}
        public virtual Ticket Ticket {get;set;}
        //是否验过票
        public virtual bool IsUsed { get; set; }
    }
}
