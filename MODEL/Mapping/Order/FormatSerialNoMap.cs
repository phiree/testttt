using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class FormatSerialNoMap:ClassMap<Model.FormatSerialNo>
    {
        public FormatSerialNoMap()
        {
            Id(x => x.FormatId);
            Map(x => x.Day);
            Map(x => x.Flag);
            Map(x => x.Month);
            Map(x => x.Value);
            Map(x => x.Year);
            
        }
    }

    

}
