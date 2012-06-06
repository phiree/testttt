using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommonUser
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IdCard { get; set; }
        public virtual TourMembership User { get; set; }
    }
}
