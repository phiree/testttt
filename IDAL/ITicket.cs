using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ITicket
    {
        IList<Ticket> GetTicketByAreaId(int areaid);
        IList<Ticket> GetTicketByscId(int scid);
        void SaveOrUpdateTicket(Model.Ticket ticket);
       
        IList<Scenic> GetTicketByAreaIdAndLevel(int areaId, int level,string topic, int pageSize, int pageIndex,out int totalRecord);
        IList<Model.Ticket> Search(string q, int pageIndex, int pageSize, out int totalRecord);
        Ticket Get(int ticketId);
        Ticket GetByScenicSeo(string scenicSeoName);
        IList<Ticket> GetTp(int scid);
    }
}
