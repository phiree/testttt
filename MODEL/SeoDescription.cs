using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class SeoDescription
    {
       public virtual int Id { get; set; }
       public virtual int TargetId { get; set; }
       public virtual string type { get; set; }//area,或者 scenic
       public virtual string Description { get; set; }

    }
}
