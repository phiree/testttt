using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UseRecord
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual int UsedNum { get; set; }
        public virtual DateTime UsedDate { get; set; }
        public virtual Order Order { get; set; }
    }
}
