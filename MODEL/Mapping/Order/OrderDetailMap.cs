using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Model.Mapping
{
    public class OrderDetailMap : ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            References<TicketPrice>(x => x.TicketPrice);
            References<Model.Order>(x => x.Order);
            Map(x => x.Remark);
            Map(x => x.Price);
            HasMany<TicketAssign>(x => x.TicketAssignList).Cascade.All();
            References<OrderDetail>(x => x.OrderDetailForUnionTicket);
            /*   HasMany<OrderDetail>(x => x.ChildTicketDetail).KeyColumn("pid").Cascade.AllDeleteOrphan()
                   .Where(x => x.OrderDetailForUnionTicket.Id == x.Id);
   */
        }
        public class ReferenceColumnConvention : IReferenceConvention
        {
            public void Apply(IManyToOneInstance instance)
            {
                // uncomment if needed
                //if (instance.EntityType == instance.Property.PropertyType)
                instance.Column(instance.Name + "id");
            }
        }
    }
}
