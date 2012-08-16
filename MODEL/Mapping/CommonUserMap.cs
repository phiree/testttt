using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class CommonUserMap:ClassMap<CommonUser>
    {
        public CommonUserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.IdCard);
            References<TourMembership>(x => x.User);
        }
    }
}
