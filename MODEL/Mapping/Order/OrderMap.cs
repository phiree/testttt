using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class OrderMap:ClassMap<Model.Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.Custom<OrderIdGenerator>();
            Map(x => x.MemberId);
            Map(x => x.TotalNum);
            Map(x => x.TotalPrice);
            Map(x => x.IsPaid);
            Map(x => x.BuyTime);
            Map(x => x.PayTime);
            Map(x => x.TradeNo);
            Map(x => x.From);
            HasMany<OrderDetail>(x => x.OrderDetail).Cascade.All();
        }
    }

    public class MonthOrderMap : ClassMap<MonthOrder>
    {
        public MonthOrderMap() {
            Id(x => x.Id);
            Map(x => x.date);
            References(x => x.scenic);
            Map(x => x.orderway);
            Map(x => x.num);
            Map(x => x.totalprice);
            Map(x => x.paidstate);
        }
    }
     
    public class OrderIdGenerator:NHibernate.Id.IIdentifierGenerator
    {
        public object Generate(NHibernate.Engine.ISessionImplementor session, object obj)
        {

            return Math.Abs(  Guid.NewGuid().GetHashCode());
        }
    }

}
