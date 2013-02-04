using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALActivityPartner:DalBase<Model.ActivityPartner>
    {
        public Model.ActivityPartner GetByPartnerCode(string partnerCode)
        {
            return session.QueryOver<Model.ActivityPartner>().Where(x => x.PartnerCode == partnerCode).SingleOrDefault();
        }
    }
}
