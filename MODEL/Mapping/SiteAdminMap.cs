using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class SiteAdminMap : SubclassMap<SiteAdmin>
    {
        public SiteAdminMap()
        {
           // Id(x => x.ID);
           // References<TourMembership>(x => x.Membership);
        }
    }
}
