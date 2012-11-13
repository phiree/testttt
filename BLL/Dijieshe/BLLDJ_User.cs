using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLDJ_User
    {
        public DAL.DALDJ_User Idj_user_enterprise=new DAL.DALDJ_User();
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
        public IList<Model.DJ_User_Gov> GetGov_UserByGovId(Guid govid)
        {
            return Idj_user_enterprise.GetAllGov_User().Where(x=>x.GovDpt.Id ==govid).ToList();
        }
      //  public Model
        public void DeleteGov_User(Model.TourMembership m)
        {
            Idj_user_enterprise.DeleteGov_User(m);
        }
        public Model.DJ_User_Gov GetGov_UserById(Guid id)
        {
            return Idj_user_enterprise.GetGov_UserById(id);
        }

        public Model.DJ_User_Gov GetGov_UserByName(string seoname)
        {
            return Idj_user_enterprise.GetGov_UserByName(seoname);
        }

        public void SaveOrUpdate(Model.TourMembership m)
        {
            Idj_user_enterprise.SaveOrUpdate(m);
        }
        #endregion

        public List<Model.DJ_User_TourEnterprise> GetAllEnt_User()
        {
            return Idj_user_enterprise.GetAllEnt_User().Where(x => x.Enterprise.Type != Model.EnterpriseType.旅行社).ToList<Model.DJ_User_TourEnterprise>();
        }

        public List<Model.DJ_User_TourEnterprise> GetAllLocal_User()
        {
            return Idj_user_enterprise.GetAllEnt_User().Where(x => x.Enterprise.Type == Model.EnterpriseType.旅行社).ToList<Model.DJ_User_TourEnterprise>();
        }

        public List<Model.DJ_User_TourEnterprise> GetLocal_UserByLocalId(int localid)
        {
            return Idj_user_enterprise.GetAllEnt_User().Where(x => x.Enterprise.Id == localid).ToList<Model.DJ_User_TourEnterprise>();
        }
    }
}
