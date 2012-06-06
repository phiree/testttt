using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
namespace BLL
{
  public  class TourRoleProvider:System.Web.Security.RoleProvider
    {
        IDAL.IRole iRole;
        public TourRoleProvider()
        {
            iRole = new DAL.DALRole();
        }
        public TourRoleProvider( IRole roleDal)
        {
            iRole = roleDal;
            }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            iRole.AddUsersToRoles(usernames, roleNames);
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            Model.Role role=new Model.Role();
            role.Name=roleName;
            iRole.CreateRole(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            iRole.DeleteRole(roleName);
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            IList<Model.Role> AllRoles = iRole.GetAllRoles();
            List<string> AllRoleNames = new List<string>();
            foreach (Model.Role role in AllRoles)
            {
                AllRoleNames.Add(role.Name);
            }
            return AllRoleNames.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
          return  iRole.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return iRole.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return iRole.IsUserInRole(username,roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            iRole.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override bool RoleExists(string roleName)
        {
            return iRole.IsRoleExists(roleName);
        }
    }
}
