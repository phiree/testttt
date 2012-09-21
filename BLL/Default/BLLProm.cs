using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLProm
    {
        IDAL.IProm iprom;
        public IDAL.IProm IProm
        {
            get {
                if (iprom == null)
                {
                    iprom = new DAL.DALProm();
                }
                return iprom;
            }
            set {
                iprom = value;

            }
        }

        public IList<Model.PromotionStatic> GetPromById(int psid)
        {
            return IProm.GetPromById(psid);
        }
        public Model.PromotionStatic GetPromByUsername(string username)
        {
            return IProm.GetPromByUsername(username);
        }
        public void AddPromInfo(Guid userid,string userfrom)
        {
            Model.PromotionStatic prom = new Model.PromotionStatic()
            {
                Member = new BLLMembership().GetUserByUserId(userid),
                UserFrom=userfrom,
                Time=DateTime.Now,
                Validated=false
            };
            IProm.AddPromInfo(prom);
        }
        public void UpdatePromInfo(Model.PromotionStatic prom)
        {
            IProm.UpdatePromInfo(prom);
        }
    }
}
