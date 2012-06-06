using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
    public class TicketPriceMap:ClassMap<TicketPrice>
    {
        public TicketPriceMap()
        {
            Id(x => x.Id);
            Map(x => x.Price);
            Map(x => x.PriceType).CustomType<int>();
            References<Ticket>(x => x.Ticket);
        }
    }
}
