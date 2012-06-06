using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class LotteryMap : ClassMap<Lottery>
    {
        public LotteryMap()
        {
            Id(x => x.Id);
            Map(x => x.IdCard);
        }
    }
}
