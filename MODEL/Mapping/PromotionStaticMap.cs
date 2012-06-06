using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class PromotionStaticMap : ClassMap<PromotionStatic>
    {
        public PromotionStaticMap()
        {
            Id(x => x.Id);
            Map(x => x.UserFrom);
            Map(x => x.Time);
            Map(x => x.Validated);
            References<User>(x => x.User);
            
        }
    }
}
