using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 后台用户
    /// </summary>
    public class ScenicAdmin
    {
        public virtual Guid Id { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual string RealName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        public virtual ScenicAdminType AdminType { get; set; }
        public virtual TourMembership Membership { get; set; }
        public virtual bool IsDisabled { get; set; }
    }
    public enum ScenicAdminType
    {
        景区资料员=1,//管理员
        检票员=2,//验票
        景区财务=4//财会
    }
}
