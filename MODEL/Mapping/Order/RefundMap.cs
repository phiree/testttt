using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class RefundMap : ClassMap<Model.Refund>
    {
        public RefundMap()
        {
            Id(x => x.Id);
            Map(x => x.RefundPrice);
            Map(x => x.ReturnTime);
            Map(x => x.TotalReturnAmount);
            References<TourMembership>(x => x.Member);
            References<Model.Order>(x => x.Order);
            
        }
    }
}