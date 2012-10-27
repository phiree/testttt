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

    }

    /// <summary>
    ///旅游企业用户
    /// </summary>
    public class DJ_User_TourEnterprise : TourMembership
    {
      
        public virtual DJ_TourEnterprise Enterprise { get; set; }
    }


}
