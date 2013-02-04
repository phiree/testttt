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
       /// <summary>
       /// 是否在规定的时间内才可购买.
       /// </summary>
       public virtual bool NeedCheckTime { get; set; }
       /// <summary>
       /// 是否只控制该合作商的总数,而不是每一天的派发数量
       /// </summary>
       public virtual bool OnlyControlTotalAmount { get; set; }
       public virtual TourActivity TourActivity { get; set; }
    }
}
