using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDJ_User
    {
        #region User_TourEnterprise
        Model.DJ_User_TourEnterprise GetUser_TEbyId(int id);
        Model.DJ_User_TourEnterprise GetByMemberId(Guid id);
        Model.DJ_User_TourEnterprise GetUser_TEbyId(int id, int permis);

        IList<Model.DJ_User_Gov> GetAllGov_User();
        IList<Model.DJ_User_TourEnterprise> GetAllEnt_User();
        void DeleteGov_User(Model.TourMembership m);
        Model.DJ_User_Gov GetGov_UserById(Guid id);
        Model.DJ_User_Gov GetGov_UserByName(string seoname);
        void SaveOrUpdate(Model.TourMembership m);
        #endregion
    }
}
