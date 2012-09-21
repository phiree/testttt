using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLCommonUser
    {
        IDAL.ICommonUser ICommonUser = new DAL.DALCommonUser();
        public IList<CommonUser> GetCommonUserByUserIdandidcard(Guid userid)
        {
            return ICommonUser.GetCommonUserByUserIdandidcard(userid);
        }
        public Model.CommonUser GetCommonUserByUserIdandidcard(Guid userid, string idcard)
        {
            return ICommonUser.GetCommonUserByUserIdandidcard(userid, idcard);
        }
        public void SaveCommonUser(CommonUser commonuser, out string msg)
        {
            msg = string.Empty;
            CommonUser cu = Get(commonuser.User.Id, commonuser.Name, commonuser.IdCard);
            if (cu != null)
            {
                msg = "已存在";
                return;
            }
            ICommonUser.SaveCommonUser(commonuser);
        }
        public void Save(Guid userid, string name, string idcard)
        {
            string msg;
            CommonUser cu = new CommonUser();
            cu.IdCard = idcard;
            cu.Name = name;
            cu.User = new BLLMembership().GetMemberById(userid);
            SaveCommonUser(cu, out msg);

        }


        /// <summary>
        /// 获取一个常用联系人
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public CommonUser Get(Guid userid, string name, string idcard)
        {
            CommonUser cu = new CommonUser();
            cu = ICommonUser.Get(userid, name, idcard);
            return cu;
        }


        public IList<CommonUser> SearchCommonUser(string name)
        {
            return ICommonUser.SearchCommonUser(name);
        }

        public void deleteCommonUser(int id)
        {
            ICommonUser.deleteCommonUser(id);
        }
        public CommonUser GetCommonUserByid(int id)
        {
            return ICommonUser.GetCommonUserByid(id);
        }

        public void updatecu(CommonUser cu)
        {
            ICommonUser.updatecu(cu);
        }

        public IList<CommonUser> GetCommonUserByIdCard(string idcard)
        {
            return ICommonUser.GetCommonUserByIdCard(idcard);
        }
    }
}
