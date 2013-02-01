using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class ActivityPartner
    {
       public Guid Id { get; set; }
       public string Name { get; set; }
       public string PartnerCode { get; set; }
       public bool Enabled { get; set; }
       public bool OnlyControlTotalAmount { get; set; }
       public int AssignedAmount { get; set; }
    }
}
