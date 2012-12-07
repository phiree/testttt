using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
namespace TourTest
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void GetMonthOrder()
        {
            IDAL.IOrder dal = new DAL.DALOrder();
            dal.GetMonthOrder(0, "201201", "201212", null);
        }
        [Test]
        public void OrderMappingTest()
        {
            ISession Session = new DAL.HybridSessionBuilder().GetSession();
            new PersistenceSpecification<Model.Order>(Session)
                .CheckProperty(x => x.IsPaid,false)
                .CheckList(x=>x.OrderDetail, new List<Model.OrderDetail>() )
                .VerifyTheMappings();
        }
        [Test]
        public void GetPaidstate()
        {
            IDAL.IOrder dal = new DAL.DALOrder();
            dal.GetPaidstate("201201", 10, "在线支付");
        }
    }
}
