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

        /// <summary>
        /// 通过userid获得常用联系人
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IList<CommonUser> GetCommonUserByUserId(Guid userid)
        {
            return ICommonUser.GetCommonUserByUserId(userid);
        }

        /// <summary>
        /// 通过idcard获得常用联系人
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public IList<CommonUser> GetCommonUserByIdCard(string idcard)
        {
            return ICommonUser.GetCommonUserByIdCard(idcard);
        }

        /// <summary>
        /// 通过userid和idcard获得常用联系人
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public Model.CommonUser GetCommonUserByUserIdandidcard(Guid userid, string idcard)
        {
            return ICommonUser.GetCommonUserByUserIdandidcard(userid, idcard);
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

        /// <summary>
        /// 保存常用联系人
        /// </summary>
        /// <param name="commonuser"></param>
        /// <param name="msg"></param>
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

        /// <summary>
        /// 保存常用联系人
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="idcard"></param>
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
        /// 搜索常用联系人
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IList<CommonUser> SearchCommonUser(string name)
        {
            return ICommonUser.SearchCommonUser(name);
        }

        /// <summary>
        /// 删除常用联系人
        /// </summary>
        /// <param name="id"></param>
        public void deleteCommonUser(int id)
        {
            ICommonUser.deleteCommonUser(id);
        }
        /// <summary>
        /// 通过id获取常用联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommonUser GetCommonUserByid(int id)
        {
            return ICommonUser.GetCommonUserByid(id);
        }

        /// <summary>
        /// 更新常用联系人
        /// </summary>
        /// <param name="cu"></param>
        public void updatecu(CommonUser cu)
        {
            ICommonUser.updatecu(cu);
        }
    }
}
