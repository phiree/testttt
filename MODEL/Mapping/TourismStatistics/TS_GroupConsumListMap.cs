using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TS_GroupConsumListMap:ClassMap<TS_GroupConsumList>
    {
        public TS_GroupConsumListMap()
        { 
            Id(x=>x.Id);
            References<TS_TourEnterprise>(x=>x.Enterprise);
          
            
        }
    }
}
