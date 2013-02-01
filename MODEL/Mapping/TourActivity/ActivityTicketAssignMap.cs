using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ActivityTicketAssignMapMap : ClassMap<ActivityTicketAssign>
    {
        public ActivityTicketAssignMapMap()
        {
            Id(x => x.Id);
            Map(x => x.AssignedAmount);
            Map(x => x.DateAssign);
            References<ActivityPartner> (x => x.Partner);
            Map(x => x.SoldAmount);
            References<Ticket>(x => x.Ticket);
            References<TourActivity>(x => x.TourActivity);
            
          
        }
    }
}
