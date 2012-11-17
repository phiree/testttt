using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TourMembership
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Openid { get; set; }
        public virtual Opentype Opentype { get; set; }
        public virtual string RealName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        public virtual string IdCard { get; set; }
        public virtual string Email { get; set; }
        public virtual PermissionType PermissionType { get; set; }
    }
    public enum Opentype
    {
        TencentQQ,
        TencentWeibo,
        Sina
    }

    public enum PermissionType
    {
        信息编辑员=1,
        行业管理员=1,
        报表查看员=2,
        用户管理员=4,
        团队录入员=8
    }
}
