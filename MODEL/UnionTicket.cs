using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnionTicket:Ticket
    {

       public virtual IList<Ticket> TicketList { get; set; }
        public override decimal GetPrice(PriceType priceType)
        {
            decimal price = 0m;
            foreach (Ticket t in TicketList)
            {
                decimal ticketPrice = t.GetPrice(priceType);
                price += ticketPrice;
            }
            return price;
        }
        public override bool IsBelongTo(Scenic s)
        {
            foreach (Ticket t in TicketList)
            {
                if (t.IsBelongTo(s)) return true;
            }
            return false;
        }
       



    }
}
