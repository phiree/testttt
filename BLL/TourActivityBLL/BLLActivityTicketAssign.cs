using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    public class BLLActivityTicketAssign : BLLBase<ActivityTicketAssign>
    {
        DALActivityTicketAssign dALActivityTicketAssign;
        public DAL.DALActivityTicketAssign DalTourActivity
        {
            get {
                if (dALActivityTicketAssign == null)
                {
                    dALActivityTicketAssign = new DALActivityTicketAssign();
                }
                return dALActivityTicketAssign;
            }
            set {
                dALActivityTicketAssign = value;
            }
        }
        }
}
