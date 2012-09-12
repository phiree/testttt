using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ScenicTicket
    {
        public virtual Guid Id;
        public virtual Scenic scenic;
        public virtual TicketUnion ticketunion;
    }
}
