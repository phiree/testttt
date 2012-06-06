using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model;
using BLL;
namespace TourTest.TDD.order
{
    /// <summary>
    /// 支付需要测试的
    /// </summary>
    [TestFixture]
   public class PaymentTDD
    {
        [Test]
        public void TestGetOrder()
        {
            Checkout checkout = new Checkout();
            checkout.BuerId =new Guid("2D3455F8-C7B5-4949-814A-A02A00DE271E");
            checkout.PriceType = PriceType.PayOnline;
            List<OrderDetail> details = new List<OrderDetail>();
            
                OrderDetail detail = new OrderDetail();
                detail.Quantity =5;
              

                Ticket t = new BLLTicket().GetTicket(1);
                TicketPrice tp = t.TicketPrice.Single<TicketPrice>(x => x.PriceType == PriceType.PayOnline);
            
                detail.TicketPrice = tp;
               
                for (int i = 0; i < detail.Quantity; i++)
                {
                     TicketAssign ta = new TicketAssign();
                    ta.IdCard = "idcard1";
                    ta.IsUsed = false;
                    ta.Name = "namei";
                    
                    detail.TicketAssignList.Add(ta);
                    
                }
           //     new BLLOrderDetail().SaveOrUpdateOrderDetail(detail);
                details.Add(detail);


                checkout.Details = details;
                checkout.MakeOrder();
            
                
           
        }
    
    }
}
