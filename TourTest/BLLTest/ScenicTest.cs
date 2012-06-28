using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class ScenicTest
    {
        [Test]
        public void GetScenicTicketTest()
        {
            IDAL.ITicket iticket = MockRepository.GenerateStub<IDAL.ITicket>();
            IDAL.ITicketPrice iticketprice = MockRepository.GenerateStub<IDAL.ITicketPrice>();

            IList<Model.Ticket> list = new List<Model.Ticket>();
            Model.Ticket ticket1 = new Model.Ticket() { Scenic = new Model.Scenic() { Id = 1 } };
            Model.Ticket ticket2 = new Model.Ticket() { Scenic = new Model.Scenic() { Id = 2 } };
            Model.Ticket ticket3 = new Model.Ticket() { Scenic = new Model.Scenic() { Id = 3 } };
            list.Add(ticket1);
            list.Add(ticket2);
            list.Add(ticket3);
            IList<Model.TicketPrice> tp = new List<Model.TicketPrice>();
            Model.TicketPrice ticketprice1 = new Model.TicketPrice() { PriceType = Model.PriceType.Normal, Price = 10 };
            Model.TicketPrice ticketprice2 = new Model.TicketPrice() { PriceType = Model.PriceType.PayOnline, Price = 20 };
            Model.TicketPrice ticketprice3 = new Model.TicketPrice() { PriceType = Model.PriceType.PreOrder, Price = 30 };
            tp.Add(ticketprice1);
            tp.Add(ticketprice2);
            tp.Add(ticketprice3);

            BLL.BLLScenic bllscenic = new BLL.BLLScenic();
            bllscenic.ITicket = iticket;
            bllscenic.ITicketprice = iticketprice;
            int areaid=1;
            int scid=2;
            iticket.Stub(x => x.GetTicketByAreaId(areaid)).Return(list);
            iticket.Stub(x=>x.GetTicketByscId(scid)).Return(list);
            iticketprice.Stub(x => x.GetTicketPriceByScenicId(1)).Return(tp);
            iticketprice.Stub(x => x.GetTicketPriceByScenicId(2)).Return(tp);
            iticketprice.Stub(x => x.GetTicketPriceByScenicId(3)).Return(tp);

            List<Model.ScenicTicket> ScenicTicket = new List<Model.ScenicTicket>();
            Model.ScenicTicket st1 = new Model.ScenicTicket() { Scenic = ticket1.Scenic, Ticket = ticket1, Price1 = 10 };
            Model.ScenicTicket st2 = new Model.ScenicTicket() { Scenic = ticket2.Scenic, Ticket = ticket2, Price2 = 20 };
            Model.ScenicTicket st3 = new Model.ScenicTicket() { Scenic = ticket3.Scenic, Ticket = ticket3, Price3 = 30 };
            ScenicTicket.Add(st1);
            ScenicTicket.Add(st2);
            ScenicTicket.Add(st3);
            Assert.AreEqual(bllscenic.GetScenicTicket(areaid, scid), ScenicTicket);
        }
    }
}
