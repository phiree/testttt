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

        public IList<Model.DJ_User_Gov> GetAllGov_User()
        {
            return Idj_user_enterprise.GetAllGov_User();
        }
      //  public Model
        public void DeleteGov_User(Guid userid)
        {
            Idj_user_enterprise.DeleteGov_User(userid);
        }
        public Model.DJ_User_Gov GetGov_UserById(Guid id)
        {
            return Idj_user_enterprise.GetGov_UserById(id);
        }
        #endregion
    }
}
