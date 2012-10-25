using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class DJ_Group_WorkerMap : ClassMap<DJ_Group_Worker>
    {
        public DJ_Group_WorkerMap()
        {
            Id(x=>x.Id);
            Map(x=>x.IDCard);
            Map(x => x.Name);
            Map(x => x.Phone);
            Map(x => x.SpecificIdCard);
            Map(x => x.WorkerType).CustomType<int>();
            References<DJ_TourGroup>(x => x.DJ_TourGroup).Cascade.All();
            References<DJ_DijiesheInfo>(x => x.DJ_Dijiesheinfo);
        }
    }
}
