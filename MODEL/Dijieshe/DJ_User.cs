using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dijieshe
{
    /// <summary>
    /// 地接社系统 旅游管理部门用户
    /// 1)等级关系: 管理部门用户-->同地区以及下级旅游企业.
    /// </summary>
   public class DJ_User_GovManager
    {
       public virtual Guid Id { get; set; }
       public virtual TourMembership Member { get; set; }
       public bool IsGoverManager { get; set; }

       
    }
}
