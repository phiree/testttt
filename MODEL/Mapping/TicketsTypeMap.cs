using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TicketsTypeMap : ClassMap<TicketsType>
    {
        public TicketsTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
