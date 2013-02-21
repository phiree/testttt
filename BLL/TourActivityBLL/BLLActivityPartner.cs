using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLActivityPartner:BLLBase<ActivityPartner>
    {
        DAL.DALActivityPartner dalAp;
        DAL.DALActivityPartner DalAP
        {
            get {
                if (dalAp == null)
               dalAp= new DAL.DALActivityPartner();
                return dalAp;
            }
            set {
                dalAp = value;
            }

        }
        public ActivityPartner GetByPartnerCode(string activityCode,string partnerCode)
        {
            return DalAP.GetByPartnerCode(activityCode, partnerCode);
        }
    }
}
