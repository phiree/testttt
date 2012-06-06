using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class VoteMap : ClassMap<Vote>
    {
        public VoteMap()
        {
            Id(x => x.Id);
            Map(x => x.IdCard);
            Map(x => x.Num);
            Map(x => x.Type);
            Map(x => x.Time);
            Map(x => x.Note);
            Map(x => x.IsEffect);
            Map(x => x.TourMembershipId);
            References<Scenic>(x => x.Scenic);
        
        }
    }
}
