using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Dijieshe
{
    /// <summary>
    /// 团队消费信息,刷卡记录
    /// </summary>
    public class GroupConsumRecord
    {
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 在哪里消费
        /// </summary>
        public virtual TourEnterprise Enterprise { get; set; }
        /// <summary>
        /// 在此消费的团队
        /// </summary>
        public virtual TourGroup Group { get; set; }

        public virtual DateTime ConsumeTime { get; set; }
        
        public virtual int AdultsAmount { get; set; }
        public virtual int ChildrenAmount { get; set; }

    }
}
