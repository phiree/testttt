using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using BLL;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class TicketTest
    {
        [Test]
        public void EnsureTicket()
        {
            var  iticket = MockRepository.GenerateStub<DAL.DALTicket>();
            int scid = 1;
            IList<Model.TicketNormal> tickets = new List<Model.TicketNormal>();
            Model.TicketNormal ticket = new Model.TicketNormal() { Name = "test" };
            tickets.Add(ticket);
            iticket.Stub(x => x.GetMainTicketByscId(scid)).Return(tickets);

            BLL.BLLTicket bllticket = new BLL.BLLTicket();
            bllticket.Iticket = iticket;

         //   Assert.AreNotEqual(ticket, bllticket.EnsureTicket(scid));
        }
    }
}
