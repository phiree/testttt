using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLDJ_User
    {
        IDAL.IDJ_User Idj_user_enterprise=new DAL.DALDJ_User();
        #region User_TourEnterprise
        public Model.DJ_User_TourEnterprise GetUser_TEbyId(int id)
        {
            return Idj_user_enterprise.GetUser_TEbyId(id);
        }
        public Model.DJ_User_TourEnterprise GetByMemberId(Guid id)
        {
            return Idj_user_enterprise.GetByMemberId(id);
        }
        public Model.DJ_User_TourEnterprise GetUser_TEbyId(int id, int permis)
        {
            return Idj_user_enterprise.GetUser_TEbyId(id, permis);
        }
      //  public Model
        #endregion
    }
}
