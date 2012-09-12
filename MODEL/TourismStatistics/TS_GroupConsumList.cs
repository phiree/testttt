using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队消费列表
    /// </summary>
    public class TS_GroupConsumList
    {
        public virtual Guid Id { get; set; }
        public virtual TS_GroupInfo GroupInfo { get; set; }
        public virtual DateTime ConsumTime { get; set; }
        /// <summary>
        /// 游客人数
        /// </summary>
        public virtual int TouristAmount { get; set; }
        /// <summary>
        /// 那个消费处
        /// </summary>
        public virtual TS_TourEnterprise Enterprise { get { return enterprise; } set {
            if (value.EnterpriseType == TourEnterpriseType.旅行社)
            {
                throw new Exception("Can't be a TourAgent");
            }
            enterprise = value;
        } }
        public virtual TS_TourEnterprise TourAgent { get { return tourAgent; }
            set {
                if (value.EnterpriseType != TourEnterpriseType.旅行社)
                {
                    throw new Exception("Must be a TourAgent");
                }
                enterprise = value;
            }
        }

        private TS_TourEnterprise enterprise;
        private TS_TourEnterprise tourAgent;
    }
}
