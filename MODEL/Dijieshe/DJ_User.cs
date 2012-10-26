using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 地接社系统 旅游管理部门用户
    /// 
    /// </summary>
    public class DJ_User_Gov : TourMembership
    {
        public virtual DJ_GovManageDepartment GovDpt { get; set; }

        public virtual DJ_User_GovPermission PermissionMask { get; set; }
    }

    /// <summary>
    ///旅游企业用户
    /// </summary>
    public class DJ_User_TourEnterprise : TourMembership
    {
      
        public virtual DJ_TourEnterprise Enterprise { get; set; }
        /// <summary>
        /// 权限枚举
        /// </summary>
        public virtual DJ_User_TourEnterprisePermission PermissionMask { get; set; }
    }

    /// <summary>
    /// 企业用户权限
    /// </summary>
    public enum DJ_User_TourEnterprisePermission
    {
        DJS创建团队 = 1
    }

    public enum DJ_User_GovPermission
    {
        超级管理员=1
    }
}
