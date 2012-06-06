using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ScenicAdminMap : ClassMap<ScenicAdmin>
    {
        public ScenicAdminMap()
        {
            Id(x => x.Id);
            Map(x => x.Address);
            Map(x => x.RealName);
            Map(x => x.Phone);
            Map(x => x.AdminType).CustomType<int>();
            References<Scenic>(x => x.Scenic);
            References<TourMembership>(x => x.Membership);
            Map(x => x.IsDisabled);
        }
    }
}
