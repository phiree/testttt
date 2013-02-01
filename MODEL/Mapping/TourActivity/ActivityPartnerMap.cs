using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ActivityPartnerMap:ClassMap<ActivityPartner>
    {
        public ActivityPartnerMap()
        {
            Id(x => x.Id);
            Map(x => x.AssignedAmount);
            Map(x => x.Name);
            Map(x => x.OnlyControlTotalAmount);
            Map(x => x.PartnerCode);
          
        }
    }
}
