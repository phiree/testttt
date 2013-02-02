using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnionTicket:TicketBase
    {

       public virtual IList<TicketBase> TicketList { get; set; }
        public override decimal GetPrice(PriceType priceType)
        {
            decimal price = 0m;
            foreach (TicketBase t in TicketList)
            {
                decimal ticketPrice = t.GetPrice(priceType);
                price += ticketPrice;
            }
            return price;
        }
        public override bool IsBelongTo(Scenic s)
        {
            foreach (TicketBase t in TicketList)
            {
                if (t.IsBelongTo(s)) return true;
            }
            return false;
        }
       



    }
}
