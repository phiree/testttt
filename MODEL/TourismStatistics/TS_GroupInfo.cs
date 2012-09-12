using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队信息
    /// </summary>
    public class TS_GroupInfo
    {
        /// <summary>
        /// 旅行社所属区域的区域码
        /// </summary>
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        /// <summary>
        /// 线路描述
        /// </summary>
        public virtual string Route { get; set; }
        /// <summary>
        /// 团队总人数
        /// </summary>
        public virtual int Amount { get; set; }
        public virtual string GuideName { get; set; }
        public virtual string GuidePhone { get; set; }
        public virtual string GuideCardNo { get; set; }
        public virtual string DriverName{ get; set; }
        public virtual string DriverPhone{ get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo{ get; set; }
        /// <summary>
        /// 所属旅行社
        /// </summary>
        public virtual TS_TourEnterprise EnterPrise { get; set; }
        public virtual IList<TS_GroupConsumList> ConsumList { get; set; }
    }
}
