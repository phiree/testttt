using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 门票分配详情 合作商,某天. 某门票 多少数量
    /// </summary>
    public class ActivityTicketAssign
    {
        public virtual Guid Id { get; set; }
        public ActivityPartner Partner { get; set; }
        /// <summary>
        /// 总票数分配
        /// </summary>
        public int DateAmount { get; set; }
        /// <summary>
        /// 分配时间
        /// </summary>
        public DateTime DateAssign { get; set; }
        /// <summary>
        /// 门票
        /// </summary>
        public Ticket TicketInActivity { get; set; }
    }
}
