using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 优惠码
    /// </summary>
    public class PreferentialCode
    {
        public virtual int Id { get; set; }
        public virtual string PrefCode { get; set; }
        public virtual string IdCard { get; set; }
        public virtual DateTime DeadLine { get; set; }
        public virtual int validity { get; set; }
    }
}
