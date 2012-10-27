using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TourMembershipMap : ClassMap<TourMembership>
    {
        public TourMembershipMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Password);
            Map(x => x.Openid);
            Map(x => x.Opentype).CustomType<int>();
            Map(x => x.RealName);
            Map(x => x.Phone);
            Map(x => x.Address);
            Map(x => x.IdCard);
            Map(x => x.Email);
            Map(x => x.PermissionType).CustomType<int>();
        }
    }
}
