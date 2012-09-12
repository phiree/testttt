using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;
using Model;
using System.Web;
using Newtonsoft;
namespace BLL
{
    public class BLLScenicTicket
    {
        IScenicTicket iticket;
        BLLScenic bllScenic = new BLLScenic();

        public IScenicTicket IScenicTicket
        {
            get
            {
                if (iticket == null)
                {
                    iticket = new DALScenicTicket();
                }
                return iticket;
            }
            set { iticket = value; }
        }

        public IList<Scenic> GetScenicByTicket(int ticketId)
        {
            return iticket.GetScenicsByTicketId(ticketId);
        }

    }
       
    
}
