using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketCountMap:ClassMap<TicketCount>
    {
        public TicketCountMap()
        {
            Id(x => x.Id);
            Map(x => x.TicketDate);
            Map(x => x.TicketType);
            Map(x => x.Count);
            Map(x => x.Price);
            Map(x => x.TotalPrice);
            Map(x => x.IsSettle);
            References<Scenic>(x => x.scenic);
        }
    }
}
