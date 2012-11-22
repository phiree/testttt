using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class DJ_WorkersMap : ClassMap<DJ_Workers>
    {
        public DJ_WorkersMap()
        {
            Id(x => x.Id);
            Map(x => x.IDCard);
            Map(x => x.Name);
            Map(x => x.Phone);
            Map(x => x.SpecificIdCard);
            Map(x => x.WorkerType).CustomType<int>();
            References<DJ_DijiesheInfo>(x => x.DJ_Dijiesheinfo);
        }
    }
}
