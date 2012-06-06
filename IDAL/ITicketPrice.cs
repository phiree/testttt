using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface ITicketPrice
    {
        IList<Model.TicketPrice> GetTicketPriceByScenicId(int scenicid);
        void SaveOrUpdateTicketPrice(Model.TicketPrice ticketprice);
        Model.TicketPrice GetTicketPriceByScenicandtypeid(int scenicid, int typeid);
        IList<Model.TicketPrice> GetTicketPriceByAreaId(int areaid, int typeid,string level,out int sceniccount,int pageindex,int pagesize);
    }
}
