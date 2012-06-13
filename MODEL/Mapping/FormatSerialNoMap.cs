using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class FormatSerialNoMap : ClassMap<FormatSerialNo>
    {
        public FormatSerialNoMap()
        {
            Id(x => x.FormatId);

            Map(x => x.Day);

            Map(x => x.Flag);
            Map(x => x.Month);
            Map(x => x.Year);
            Map(x => x.Value);



        }
    }
}
