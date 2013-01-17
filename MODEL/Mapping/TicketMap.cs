
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
            Map(x => x.MipangId);
            Map(x => x.Lock);
            Map(x => x.OrderNumber);
            //References<TicketsType>(x => x.TicketsType);
            References<Scenic>(x => x.Scenic);
           // References<TicketPrice>(x => x.TicketPrice);
            HasMany<TicketPrice>(x => x.TicketPrice).Inverse().Cascade.All();
            Map(x => x.IsMain);
            Map(x => x.Amount);
            Map(x => x.BeginDate);
            Map(x => x.EndDate);
            Map(x => x.ProductCode);
            Map(x => x.Remark);
        }
    }
}
