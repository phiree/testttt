using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace TourTest.TDD.Payment
{
    /// <summary>
    /// 如何测试支付
    /// 1 断言是什么: 
    /// 
    /// </summary>
    [TestFixture]
   public class TetsPayment
    {

        [Test]
       public void TestPay()
       {
           int totalFee = 100;
           string orderId = Guid.NewGuid().ToString();
           TestCodePayment payment = new TestCodePayment();
       }
        [Test]
        public void Pay()
        {
            Model.Order order = new BLL.BLLOrder().GetOrderByOrderid(62);
            BLL.BLLPayment bllpamment = new BLL.BLLPayment(order);
            bllpamment.Pay();
            bllpamment.Received("dasf");
            
        }
    }

   public class TestCodePayment
   {
      public TestCodeOrder Order;
      public void Pay(TestCodeOrder order)
      { 
        
      }
   }
   public class TestCodeOrder
   {
       public bool HasPaid;
    }

    


}
