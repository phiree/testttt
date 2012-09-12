using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ScenicTicketMap : ClassMap<ScenicTicket>
    {
        public ScenicTicketMap()
        {
            Id(x => x.Id);
            References<Scenic>(x => x.Scenic);
            References<Ticket>(x => x.Ticket);
        }
    }
}
