using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class DJ_Group_DriverMap : SubclassMap<DJ_Group_Driver>
    {
        public DJ_Group_DriverMap()
        {
            Map(x => x.Carno);
        }
    }
}
