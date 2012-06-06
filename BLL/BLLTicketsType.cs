using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using DAL;

namespace BLL
{
    public class BLLTicketsType
    {
        ITicketsType iticketstype;

        public ITicketsType Iticketstype
        {
            get
            {
                if (iticketstype == null)
                {
                    iticketstype = new DALTicketType();
                }
            return iticketstype; }
            set { iticketstype = value; }
        }


        public IList<TicketsType> GetTicketsType()
        {
            return Iticketstype.GetTicketsType();
        }
    }
}
