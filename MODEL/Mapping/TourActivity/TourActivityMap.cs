using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TourActivityMap:ClassMap<TourActivity>
    {
        public TourActivityMap()
        {
            Id(x => x.Id);
          HasMany<ActivityTicketAssign>(x=>x.ActivityTicketAssign).Cascade.All();
          Map(x => x.ActivityCode).Unique();
          Map(x => x.BeginHour);
          Map(x => x.EndHour);
          HasMany<ActivityPartner>(x => x.Partners).Cascade.All();
          HasMany<Ticket>(x => x.Tickets).Cascade.All();
            Map(x => x.Name);
            Map(x => x.BeginDate);
            Map(x => x.EndDate);
            Map(x => x.AmountPerIdcardTicket);
            Map(x => x.AmountPerIdcardInActivity);

            Map(x => x.AreasUseBlack);
            Map(x => x.AreasWhiteList);
            Map(x => x.AreasBlackList);
            
        }
    }
}
