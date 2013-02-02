
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketNormalMap : SubclassMap<TicketNormal>
    {
        public TicketNormalMap()
        {

            
            Map(x => x.MipangId);
        
            References<UnionTicket>(x => x.UnionTicket);
            References<Scenic>(x => x.Scenic);

        }
    }
}
