using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DJ_Group_Base
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Idcard { get; set; }
        public virtual string Phone { get; set; }
        public virtual bool Gender { get; set; }

        public virtual Model.DJ_TourEnterprise TourEnterprise { get; set; }
    }
}
