using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User:TourMembership
    {
       
        public virtual string RealName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        public virtual string IdCard { get; set; }
        public virtual string Email { get; set; }
       // public virtual Membership Membership { get; set; }
    }
}
