using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class RoleMap:ClassMap<Role>
    {
        public RoleMap()
        { 
            Id(x=>x.Id);
            Map(x=>x.Name);
          
        }
    }
    public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Id(x => x.Id);
            Map(x => x.MemberName);
            Map(x => x.RoleName);
        }
    }
}
