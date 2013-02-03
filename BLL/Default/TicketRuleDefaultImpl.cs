using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TicketRuleDefaultImpl:Model.ITicketRule
    {
        
        public bool CheckAmountPerDay(int amount)
        {
            throw new NotImplementedException();
        }

        public bool CheckAmountAmount(int amount)
        {
            throw new NotImplementedException();
        }

        public bool CheckBuyHour()
        {
            throw new NotImplementedException();
        }

        public bool CheckValidCheckDate()
        {
            throw new NotImplementedException();
        }

        public bool VisitorAreas(Model.Area from)
        {
            throw new NotImplementedException();
        }

        public bool CheckMaxAmountPerTicket(string idcardno)
        {
            throw new NotImplementedException();
        }

        public bool CheckMaxAmountAllTicket(string idcardno)
        {
            throw new NotImplementedException();
        }
    }
}
