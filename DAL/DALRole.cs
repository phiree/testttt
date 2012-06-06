using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALRole : DalBase, IDAL.IRole
    {


        public void CreateRole(Model.Role r)
        {
            session.Save(r);
            session.Flush();
        }
        public void DeleteRole(string roleName)
        {
            string strQry = @"delete from Role r 
                                    where r.Name='" + roleName + "'";
            IQuery qry = session.CreateQuery(strQry);
            qry.ExecuteUpdate();
        }
        public bool IsRoleExists(string roleName)
        {
            string strQry = @"select count(*) from Role r 
                                    where r.Name='" + roleName+ "'";
            IQuery qry = session.CreateQuery(strQry);
           long count= qry.FutureValue<long>().Value;
           return count >= 1;
        }
        public IList<Model.Role> GetAllRoles()
        {
            return session.QueryOver<Model.Role>().List();
        }
        public void RemoveUsersFromRoles(string[] userNames, string[] roleNames)
        {
            foreach (string username in userNames)
            {
                foreach (string roleName in roleNames)
                {
                    string strQry = @"delete from UserRole ur 
                                    where ur.MemberName='" + username +
                                      "' and ur.RoleName='" + roleName + "'";
                    IQuery qry = session.CreateQuery(strQry);
                    qry.ExecuteUpdate();

                }
            }
            session.Flush();
        }
        public void AddUsersToRoles(string[] userNames, string[] roleNames)
        {
            foreach (string username in userNames)
            {
                foreach (string roleName in roleNames)
                {
                    if (IsUserInRole(username, roleName)) { continue; }

                    Model.UserRole ur = new Model.UserRole();
                    ur.RoleName = roleName;
                    ur.MemberName = username;
                    session.Save(ur);
                }
            }
            session.Flush();

        }
        public bool IsUserInRole(string userName, string roleName)
        {
            bool isExists = false;
            string strQry = @"select count(*) from UserRole ur 
                                    where ur.MemberName='" + userName +
                                     "' and ur.RoleName='" + roleName + "'";
            IQuery qry = session.CreateQuery(strQry);
            long count = qry.FutureValue<long>().Value;
            isExists = count == 1;
            return isExists;

        }
        public string[] GetRolesForUser(string userName)
        {
            IList<string> roles = new List<string>();
            string strQry = @"select ur.RoleName from UserRole ur 
                                    where ur.MemberName='" + userName+"'";
            IQuery qry = session.CreateQuery(strQry);
            roles = qry.List<string>();
            return roles.ToArray();
        }

        public  string[] GetUsersInRole(string roleName)
        {
            IList<string> members = new List<string>();
            string strQry = @"select ur.MemberName from UserRole ur 
                                    where ur.RoleName='" + roleName+"'";
            IQuery qry = session.CreateQuery(strQry);
            members = qry.List<string>();
            return members.ToArray();
        }


    }
}
