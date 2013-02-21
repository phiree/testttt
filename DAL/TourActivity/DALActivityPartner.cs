using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALActivityPartner:DalBase<Model.ActivityPartner>
    {
        public Model.ActivityPartner GetByPartnerCode(string activityCode, string partnerCode)
        {
          string sql = string.Format(@"select ap from ActivityPartner ap
                                        where ap.TourActivity.ActivityCode='{0}'
                                            and ap.PartnerCode='{1}'", activityCode, partnerCode);
            return session.CreateQuery(sql).FutureValue<Model.ActivityPartner>().Value;
            //session.QueryOver<Model.ActivityPartner>().
            //   Where(x =>x.TourActivity.ActivityCode==activityCode&& x.PartnerCode == partnerCode).SingleOrDefault();
         

        }
    }
}
