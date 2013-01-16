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
    public class DJ_ProductRouteMap : ClassMap<DJ_ProductRoute>
    {
        public DJ_ProductRouteMap()
        {
            Id(x => x.Id);
            Map(x => x.DayNo);
            References(x => x.Enterprise).Cascade.SaveUpdate();
            Map(x => x.Description);
            Map(x => x.RD_EnterpriseName);
          
        }
    }
}
