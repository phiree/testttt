using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class DiscountCodeMap:ClassMap<DiscountCode>
    {
        public DiscountCodeMap()
        {
            Id(x => x.Id);
            Map(x => x.IdCard);
            Map(x => x.MemberId);
            Map(x => x.PeriodTime);
            Map(x => x.DisCode);
            Map(x => x.CloseTime);
            Map(x => x.IsObj);
        }

    }
}
