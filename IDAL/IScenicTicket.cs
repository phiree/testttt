using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IScenicTicket
    {
        IList<Scenic> GetScenicsByTicketId(int ticketId);
        IList<Ticket> GetTicketByScenicId(int scenicId);
        void Delete(ScenicTicket st);
        void Add(ScenicTicket st);
        ScenicTicket Get(int ticketid,int scenicId);
    }
}
