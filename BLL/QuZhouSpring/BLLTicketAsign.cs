using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace BLL.QuZhouSpring
{
    //将某天某景区门票分发给接入商
    public class BLLTicketAsign
    {
        public void Asign(DateTime date, Ticket t, Dictionary<Guid,int> partnersAsign, int asignedAmount)
        {
            QZTicketAsign ta = new QZTicketAsign();

        }

    }
}
