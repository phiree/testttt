using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ScenicTicket
    {
        public Scenic Scenic { get; set; }
        public Ticket Ticket { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal Price4 { get; set; }
        public decimal Price5 { get; set; }
    }
}
