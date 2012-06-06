using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 推广统计
    /// </summary>
    public class PromotionStatic
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual string UserFrom { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual bool Validated { get; set; }
    }
}
