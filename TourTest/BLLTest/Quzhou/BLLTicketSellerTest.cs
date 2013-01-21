using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BLL;
using Model;
namespace TourTest.BLLTest.Quzhou
{
    [TestFixture]
   public class BLLTicketSellerTest
    {
        [Test]
        public void SellerTest()
        { 
         //  string client
        }
        [Test]
        public void BuildOrderForQZTest()
        { 
            BLL.BLLQZTicketSeller seller = new BLLQZTicketSeller();

            TourMembership member = new TourMembership();
            member.IdCard = "idcard";
            
            Ticket currentTicket = new Ticket();
            TicketPrice tp = new TicketPrice();
            tp.Price = 1;
            tp.PriceType = PriceType.PreOrder;
            tp.Ticket = currentTicket;
            currentTicket.TicketPrice.Add(tp);
            Model.Order order = seller.BuildOrderForQZ(member,"yuanfei","",currentTicket, 1, "浙江旅游信息中心网站");

            Assert.AreEqual(order.TotalPrice, 1);
        }
       
        
    }
}
