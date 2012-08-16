using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class UserVoteAmountMap : ClassMap<UserVoteAmount>
    {
        public UserVoteAmountMap()
        {
            Id(x => x.Id);
            References<TourMembership>(x => x.User);
            Map(x => x.EarnWay).CustomType<int>();
            Map(x => x.Amount);
            Map(x => x.EarnDate);
        }
    }
    public class EarnWayAmountMap : ClassMap<EarnWayAmount>
    {
        public EarnWayAmountMap()
        {
            Id(x => x.Id);
            Map(x => x.EarnWay).CustomType<int>();
            Map(x => x.Amount);
        }
    }
}
