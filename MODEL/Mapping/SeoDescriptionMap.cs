using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
    public class SeoDescriptionMap:ClassMap<SeoDescription>
    {
        public SeoDescriptionMap()
        {
            Id(x => x.Id);
            Map(x => x.TargetId);
            Map(x => x.type);
            Map(x => x.Description);
        }
    }
}
