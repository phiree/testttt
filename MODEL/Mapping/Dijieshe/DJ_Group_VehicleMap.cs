using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class DJ_Group_VehicleMap : ClassMap<DJ_Group_Vehicle>
    {
        public DJ_Group_VehicleMap()
        {
            Id(x=>x.Id);
            Map(x=>x.Brand);
            Map(x => x.Capacity);
            Map(x => x.VehicleNo);
            References<DJ_TourGroup>(x => x.Group);
           
           
        }
    }
}
