using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class PreferentialCodeMap : ClassMap<PreferentialCode>
    {
        public PreferentialCodeMap()
        {
            Id(x => x.Id);
            Map(x => x.DeadLine);
            Map(x => x.IdCard);
            Map(x => x.PrefCode);
            Map(x => x.validity);
        }
    }
}
