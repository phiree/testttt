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
            References<DJ_TourGroup>(x => x.DJ_TourGroup).Cascade.All();
        }
    }
}
