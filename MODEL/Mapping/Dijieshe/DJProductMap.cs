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
    public class DJ_ProductMap : ClassMap<DJ_Product>
    {
        public DJ_ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.DaysAmount);
            Map(x => x.IsTemplate);
          //  Map(x => x.Gather);
            Map(x => x.Name);
            HasMany<DJ_Route>(x => x.Routes);
        }
    }
}
