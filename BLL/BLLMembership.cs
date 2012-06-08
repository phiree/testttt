using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Web.Security;
namespace BLL
{
    public class BLLMembership
    {
        IDAL.IMembership dal = new DAL.DALMembership();

        /// <summary>
        /// 创建普通用户
        /// </summary>
        /// <param name="realname"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="idcard"></param>
        /// <param name="loginname"></param>
        /// <param name="password"></param>
        public void CreateUser(string realname, string phone, string address, string idcard,
            string loginname, string password)
        {
            //valid parameters
            string encryptedPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            Model.User user = new Model.User()
            {
                RealName = realname,
                Phone = phone,
                Address = address,
                IdCard = idcard,
                Name = loginname,
                Password = encryptedPwd,
            };
            CreateUpdateMember(user);
        }

        /// <summary>
        /// 创建第三方登录普通用户
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="openid"></param>
        /// <param name="opentype"></param>
        public void CreateUser(string nickname, string openid, Model.Opentype opentype)
        {
            string encryptedPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(
                new Random().Next(100000, 999999999).ToString(), "MD5");
            TourMembership tm = GetMember(nickname);
            while (tm != null)
            {
                nickname += nickname + "0";
                tm = GetMember(nickname);
            }
            Model.User user = new Model.User()
            {
                RealName = "",
                Phone = "",
                Address = "",
                IdCard = "",
                Name = nickname,
                Password = encryptedPwd,
                Openid = openid,
                Opentype = opentype
            };
            CreateUpdateMember(user);
        }

        /// <summary>
        /// 创建后台管理员
        /// </summary>
        /// <param name="realname"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="idcard"></param>
        /// <param name="loginname"></param>
        /// <param name="password"></param>
        public void CreateUser(string realname, string phone, string address,
             string loginname, string password, Scenic scenic)
        {
            //string encryptedPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            //Model.ScenicAdmin backuser = new ScenicAdmin()
            //{
            //    Address = address,
            //    Id = Guid.NewGuid(),
            //    Name = loginname,
            //    Password = encryptedPwd,
            //    Phone = phone,
            //    RealName = realname,
            //    Scenic = scenic,
            //};
            //CreateUpdateMember(backuser);
        }

        public void CreateUpdateMember(TourMembership member)
        {
            dal.CreateUpdateMember(member);
        }
        public TourMembership GetMember(string loginName)
        {
            TourMembership member = dal.GetMemberByName(loginName);
            return member;
        }
        public TourMembership GetMemberByOpenid(string openid, Model.Opentype opentype)
        {
            TourMembership member = dal.GetMemberByOpenid(openid, opentype);
            return member;
        }
        public TourMembership GetMemberById(Guid memberId)
        {
            return dal.GetMemberById(memberId);
        }

        public Model.User GetUserByUserId(Guid userid)
        {
            TourMembership member = dal.GetMemberById(userid);
            if (member.GetType() == typeof(User))
            {
                return (User)member;
            }
            else
            {
                throw new Exception("该用户不能转换为User");
            }
        }

        public IList<TourMembership> GetAllUsers()
        {
            return dal.GetAllUsers();
        }
        TourRoleProvider trp = new TourRoleProvider();
        string[] roles = { "ScenicAdmin" };
        public void CreateUpdateScenicAdmin(Guid memid, int scenicid)
        {

            Model.ScenicAdmin sa = GetScenicAdmin(memid);

            if (sa == null)
            {
                sa = new ScenicAdmin();
                sa.Membership = GetMemberById(memid);
            }
            
            Model.Scenic sc = new BLL.BLLScenic().GetScenicById(scenicid);
            sa.Scenic = sc;
            dal.UpdateScenicAdmin(sa);
         
         
            string[] names = { sa.Membership.Name};
            trp.AddUsersToRoles(names, roles);

        }
        public Model.ScenicAdmin GetScenicAdmin(Guid id)
        {
            return dal.GetScenicAdmin(id);
        }
        public IList<Model.ScenicAdmin> GetScenicAdmin(int scenicid)
        {
            return dal.GetScenicAdmin(scenicid);
        }
        public IList<Model.ScenicAdmin> GetScenicAdmin(int scenicid,string code)
        {
            return dal.GetScenicAdmin(scenicid,code);
        }
        public void DeleteScenicAdmin(Model.ScenicAdmin sa)
        {
            dal.DeleteScenicAdmin(sa);
             
            string[] names = { sa.Membership.Name};
            trp.RemoveUsersFromRoles(names, roles);
        }
        public void DeleteScenicAdmin(Guid id)
        {
            DeleteScenicAdmin(GetScenicAdmin(id));
        }
        public void updateinfo(TourMembership tm)
        {
            dal.ChangeInfo(tm);
        }
    }
}
