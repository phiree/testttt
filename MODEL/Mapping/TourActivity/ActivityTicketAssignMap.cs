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
            Map(x => x.SoldAmount);
            //三列结合的唯一约束,保证每个合作商每天对某一门票只有一条记录
            Map(x => x.DateAssign).UniqueKey("UK_TicketAssign");
            References<ActivityPartner>(x => x.Partner).UniqueKey("UK_TicketAssign");
            References<Ticket>(x => x.Ticket).UniqueKey("UK_TicketAssign");
            References<TourActivity>(x => x.TourActivity);
            
          
        }
    }
}
