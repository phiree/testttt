
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Lock);
            //References<TicketsType>(x => x.TicketsType);
            References<Scenic>(x => x.Scenic);
           // References<TicketPrice>(x => x.TicketPrice);
            HasMany<TicketPrice>(x => x.TicketPrice).Cascade.All();//.Inverse();
        }
    }
}
