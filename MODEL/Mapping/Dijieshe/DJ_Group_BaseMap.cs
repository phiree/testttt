using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model
{
    public class DJ_Group_BaseMap : ClassMap<DJ_Group_Base>
    {
        public DJ_Group_BaseMap()
        {
            Id(x => x.Id);
            Map(x => x.Gender);
            Map(x => x.Idcard);
            Map(x => x.Name);
            Map(x => x.Phone);
            References<Model.DJ_TourEnterprise>(x => x.TourEnterprise);
        }
    }
}
