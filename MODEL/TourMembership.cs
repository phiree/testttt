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
    }
    public enum Opentype
    {
        TencentQQ,
        TencentWeibo,
        Sina
    }
}
