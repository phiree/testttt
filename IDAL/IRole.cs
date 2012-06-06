using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
   public  interface IRole
    {
       void CreateRole(Role r);
       IList<Role> GetAllRoles();
       void DeleteRole(string roleName);
       bool IsRoleExists(string roleName);
       void RemoveUsersFromRoles(string[] userNames, string[] roleNames);
       void AddUsersToRoles(string[] userNames, string[] roleNames);
       string[] GetRolesForUser(string userName);
       string[] GetUsersInRole(string roleName);
        bool IsUserInRole(string userName, string roleName);
    }
}
