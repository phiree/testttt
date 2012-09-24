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
    public class RouteMap : ClassMap<DJ_Route>
    {
        public RouteMap()
        {
            Id(x => x.Id);
            Map(x => x.BeginTime);
            Map(x => x.EndTime);
          //  Map(x => x.Gather);
            References(x => x.Enterprise);
            Map(x => x.Description);
            References<DJ_Product>(x => x.DJ_Product);
        }
    }
}
