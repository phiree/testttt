using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ContractScenicPriceMap:ClassMap<ContractScenicPrice>
    {
        public ContractScenicPriceMap()
        {
            Id(x => x.Id);
            Map(x => x.PriceContract);
            References<Scenic>(x => x.Scenic);
        }
    }
}
