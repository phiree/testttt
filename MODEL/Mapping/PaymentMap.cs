using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class PaymentMap:ClassMap<Payment>
    {
        public PaymentMap()
        {
            Id(x => x.Id);
            References<Model.Order>(x => x.Order);
            Map(x => x.PayType).CustomType<int>();
            Map(x => x.PayAmount);
            Map(x => x.BeginPay);
            Map(x => x.RequestStringToPay).Length(4000);
            Map(x => x.EndPay);
            Map(x => x.ReceivedStringFromPay).Length(4000);
        }
    }
}
