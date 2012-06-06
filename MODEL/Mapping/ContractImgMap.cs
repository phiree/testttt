using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ContractImgMap : ClassMap<ContractImg>
    {
        public ContractImgMap() {
            Id(x => x.Id);
            Map(x => x.Imgloc);
            Map(x => x.ScenicModule).CustomType<int>();
            References<Model.Scenic>(x => x.Scenic);
        }
    }
}
