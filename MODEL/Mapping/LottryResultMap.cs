using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class LottryResultMap : ClassMap<LottryResult>
    {
        public LottryResultMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.IdCard);
            Map(x => x.IsGet);
            Map(x => x.Time);
            References<Lottery>(x => x.Lottery);
        }
    }
}
