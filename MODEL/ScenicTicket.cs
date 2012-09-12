using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ScenicTicket
    {
        public virtual Guid Id {get;set;}
        public virtual Scenic scenic {get;set;}
        public virtual Ticket ticket {get;set;}
    }
}
