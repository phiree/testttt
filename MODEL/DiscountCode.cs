using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DiscountCode
    {
        public virtual int Id { get; set; }
        public virtual string  DisCode { get; set; }
        public virtual Guid MemberId { get; set; }
        public virtual string IdCard { get; set; }
        public virtual DateTime  CloseTime { get; set; }
        public virtual DateTime  PeriodTime { get; set; }
        public virtual bool  IsObj { get; set; }
    }
}
