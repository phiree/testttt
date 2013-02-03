using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping.Order
{
    public class TicketAssignMap:ClassMap<TicketAssign>
    {
        public TicketAssignMap()
        {
            Id(x => x.Id);
            Map(x => x.IdCard);
            Map(x => x.Name);
            Map(x => x.IsUsed);
            Map(x => x.UsedTime);
            Map(x => x.TicketCode);
            References<Scenic>(x => x.Scenic);
            References<OrderDetail>(x => x.OrderDetail);
            References<ScenicAdmin>(x => x.ScenicAdmin);
            Map(x => x.saName);
            
        }
    }
}
