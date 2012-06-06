using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 票的类型:
    /// 门市价, 预定价,优惠价, 电子明信片价格, 明星片价格.
    /// </summary>
    public class TicketsType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
