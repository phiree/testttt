using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class TS_TourEnterpriseMap:SubclassMap<TS_TourEnterprise>
    {
        public TS_TourEnterpriseMap()
        { 
          
            Map(x => x.Address);
            Map(x => x.AreaCode);
            Map(x => x.Phone);
            Map(x => x.EnterpriseType).CustomType<int>();
        
            Map(x => x.Name);
           
            
        }
    }
}
