
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketBaseMap : ClassMap<TicketBase>
    {
        public TicketBaseMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.ProductCode);
            HasMany<TicketPrice>(x => x.TicketPrice).Inverse().Cascade.All();

            Map(x => x.Lock);
            Map(x => x.BeginDate);
            Map(x => x.EndDate);
            //References<TicketsType>(x => x.TicketsType);
            // References<TicketPrice>(x => x.TicketPrice);
            Map(x => x.Remark);
            References<TourActivity>(x => x.TourActivity);
        }
    }
}
