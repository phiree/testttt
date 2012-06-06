using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TicketCount
    {
        public virtual int Id { get; set; }
        public virtual DateTime  TicketDate { get; set; }
        public virtual string TicketType { get; set; }
        public virtual int Count { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual bool IsSettle { get; set; }
        public virtual Scenic scenic { get; set; }
    }
}
