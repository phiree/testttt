using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class OrderDetailMap:ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            References<TicketPrice>(x => x.TicketPrice);
            References<Model.Order>(x => x.Order);
            Map(x => x.Remark);
            HasMany<TicketAssign>(x => x.TicketAssignList).Cascade.All();
        }
    }
}
