using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MemberRole
    {
        public virtual Guid Id { get; set; }
        public virtual TourMembership Member { get; set; }
        public virtual Role Role { get; set; }
    }
}
