using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //每张门票分配一个身份证IDp        
    public class TicketAssign
    {
        public virtual Guid Id { get; set; }
        //用户姓名
        public virtual string Name { get; set; }
        public virtual string IdCard { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        /// <summary>
        /// 该门票分配的景区,在分配身份证号码时,通过ticket的 GetScenics方法获取该门票对应的景区
        /// </summary>
        public virtual Scenic Scenic { get; set; }
        /// <summary>
        /// 分配的数量
        /// </summary>
        public virtual int Amount { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual DateTime? UsedTime { get; set; }
    }

    public class checkticketassign
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime BuyTime { get; set; }
    }
}
