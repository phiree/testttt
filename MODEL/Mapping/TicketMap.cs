
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketMap : SubclassMap<Ticket>
    {
        public TicketMap()
        {

            
            Map(x => x.MipangId);
            Map(x => x.IsMain);
            References<UnionTicket>(x => x.UnionTicket);
            References<Scenic>(x => x.Scenic);

        }
    }
}
