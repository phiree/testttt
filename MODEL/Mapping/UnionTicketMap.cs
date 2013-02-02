
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class UnionTicketMap : SubclassMap<UnionTicket>
    {
        public UnionTicketMap()
        {
            HasMany<Ticket>(x => x.TicketList);
            //fenzhiqiehuan
        }
    }
}
