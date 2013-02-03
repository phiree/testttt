using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class ActivityPartner
    {
       public virtual Guid Id { get; set; }
       public virtual string Name { get; set; }
       public virtual string PartnerCode { get; set; }
       public virtual bool Enabled { get; set; }
       public virtual bool OnlyControlTotalAmount { get; set; }
       public virtual TourActivity TourActivity { get; set; }
    }
}
