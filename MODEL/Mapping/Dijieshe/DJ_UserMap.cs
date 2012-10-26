using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
    /// <summary>
    /// 政府部门用户
    /// </summary>
    public class DJ_User_GovMap:SubclassMap<DJ_User_Gov>
    {

        public DJ_User_GovMap()
        {
            References<DJ_GovManageDepartment>(x => x.GovDpt);
            Map(x => x.PermissionMask).CustomType<int>();
      }
    }
    public class DJ_User_TourEnterpriseMap : SubclassMap<DJ_User_TourEnterprise>
    {

        public DJ_User_TourEnterpriseMap()
        {
            References<DJ_TourEnterprise>(x => x.Enterprise).Not.LazyLoad();
            Map(x => x.PermissionMask).CustomType<int>(); 
        }
    }
}
