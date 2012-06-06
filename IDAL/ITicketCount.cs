using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ITicketCount
    {
         IList<TicketCount> GetTicketCountByScenic(int scenicid);
         void SaveTicketCountByScenic(TicketCount tc);
    }
}
