
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketUnionMap : SubclassMap <TicketUnion>
    {
        public TicketUnionMap()
        {
             HasMany<Scenic> (x => x.Scenics);
           
        }
    }
}
