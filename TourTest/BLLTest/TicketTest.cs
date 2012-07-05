using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class TicketTest
    {
        [Test]
        public void EnsureTicket()
        {
            IDAL.ITicket iticket = MockRepository.GenerateStub<IDAL.ITicket>();
            int scid = 1;
            IList<Model.Ticket> tickets = new List<Model.Ticket>();
            Model.Ticket ticket = new Model.Ticket() { Name="test"};
            tickets.Add(ticket);
            iticket.Stub(x => x.GetTicketByscId(scid)).Return(tickets);

            BLL.BLLTicket bllticket = new BLL.BLLTicket();
            bllticket.Iticket = iticket;

            Assert.AreNotEqual(ticket, bllticket.EnsureTicket(scid));
        }
    }
}
