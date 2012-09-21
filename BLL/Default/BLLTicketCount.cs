using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;
using System.Collections;

namespace BLL
{
    public class BLLTicketCount
    {
        private ITicketCount iticketcount;

        public ITicketCount Iticketcount
        {
            get
            {
                if (iticketcount == null)
                    iticketcount = new DALTicketCount();
                return iticketcount; 
            }
            set { iticketcount = value; }
        }
        
    }
}
