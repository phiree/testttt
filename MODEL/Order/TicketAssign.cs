using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //每张门票分配一个身份证IDp        
    public class TicketAssign
    {
        public TicketAssign()
        { }
        public TicketAssign(string name,string idcard,OrderDetail detail,int amount)
            :this()
        {
            this.Name = name;
            this.OrderDetail = detail;
            this.Amount = amount;
            this.IdCard = idcard;
            this.TicketCode = detail.TicketPrice.Ticket.ProductCode;
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IdCard { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        /// <summary>
        /// 门票编码,冗余字段
        /// </summary>
        public virtual string TicketCode { get; set; }
        /// <summary>
        /// 分配的数量
        /// </summary>
        public virtual int Amount { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual DateTime? UsedTime { get; set; }
        /// <summary>
        /// 验票员
        /// </summary>
        public virtual ScenicAdmin ScenicAdmin { get; set; }
        /// <summary>
        /// 验票员真实姓名
        /// </summary>
        public virtual string saName { get; set; }
        /// <summary>
        /// 验票方式
        /// </summary>
        public virtual string checkType { get; set; }
        
    }

   
}
