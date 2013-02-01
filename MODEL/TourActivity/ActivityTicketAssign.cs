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
        public virtual ActivityPartner Partner { get; set; }
        /// <summary>
        /// 总票数分配
        /// </summary>
        public virtual int AssignedAmount { get; set; }
        /// <summary>
        /// 销售总数
        /// </summary>
        public virtual int SoldAmount { get; set; }
        /// <summary>
        /// 分配时间
        /// </summary>
        public virtual DateTime DateAssign { get; set; }
        /// <summary>
        /// 门票
        /// </summary>
        public virtual Ticket Ticket { get; set; }
        public virtual TourActivity TourActivity { get; set; }


    }
}
