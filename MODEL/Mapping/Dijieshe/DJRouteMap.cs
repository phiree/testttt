using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model
{
    /// <summary>
    /// 行程路线
    /// </summary>
    public class DJ_RouteMap : SubclassMap<DJ_Route>
    {
        public DJ_RouteMap()
        {
          
            References<DJ_TourGroup>(x => x.DJ_TourGroup);
        }
    }
}
