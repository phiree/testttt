using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

///支持test通过, 然后重构.
namespace TourTest.RoleTDD
{
    public interface IRole
    { 
     void AddRole(Role role);
    }
    public class Role
    {
        public int Id;
        public string Name;
    }
    public class DALRole:IRole
    {
        public void AddRole(Role role)
        {
           
        }
    }
}
