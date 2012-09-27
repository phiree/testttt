using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队消费信息,刷卡记录
    /// </summary>
    public class DJ_GroupConsumRecord
    {
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 在哪里消费
        /// </summary>
        public virtual DJ_TourEnterprise Enterprise { get; set; }
        /// <summary>
        /// 在此消费的团队中的某条行程
        /// </summary>
        public virtual DJ_Route Route { get; set; }

        public virtual DateTime ConsumeTime { get; set; }
        
        public virtual int AdultsAmount { get; set; }
        public virtual int ChildrenAmount { get; set; }

    }
}
