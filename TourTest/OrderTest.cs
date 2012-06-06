using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
        public void GetPaidstate()
        {
            IDAL.IOrder dal = new DAL.DALOrder();
            dal.GetPaidstate("201201", 10, "在线支付");
        }
    }
}
