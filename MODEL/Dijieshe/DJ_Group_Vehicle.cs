using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队车辆信息
    /// </summary>
    public class DJ_Group_Vehicle 
    {
        
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string VehicleNo { get; set; }
        /// <summary>
        /// 车辆品牌
        /// </summary>
        public virtual string Brand { get; set; }

        /// <summary>
        /// 几座
        /// </summary>
        public virtual string Capacity { get; set; }

        /// <summary>
        /// 该车辆 参与的团队
        /// </summary>
      public virtual  DJ_TourGroup Group { get; set; }
    }
}
