using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //团队信息
    public class DJ_TourGroup
    {
        public DJ_TourGroup()
        {
            Members = new List<DJ_TourGroupMember>();
        }
        /// <summary>
        /// 该团队所属的地接社
        /// </summary>
        public virtual DJ_DijiesheInfo Dijieshe { get; set; }
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public virtual DateTime BeginDate { get; set; }
        /// <summary>
        /// 总天数
        /// </summary>
        public virtual int DaysAmount { get; set; }
        /// <summary>
        /// 路线描述
        /// </summary>
        public virtual IList<DJ_Route> RouteDescription { get; set; }
        /// <summary>
        /// 导游姓名
        /// </summary>
        public virtual string GuideName { get; set; }
        /// <summary>
        /// 导游电话号码
        /// </summary>
        public virtual string GuidePhone { get; set; }
        /// <summary>
        /// 导游身份证号
        /// </summary>
        public virtual string GuideIdCardNo { get; set; }
        /// <summary>
        /// 司机信息
        /// </summary>
        public virtual string DriverName { get; set; }
        /// <summary>
        /// 司机电话
        /// </summary>
        public virtual string DriverPhone { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }
        /// <summary>
        /// 成人总人数
        /// </summary>
        public virtual int AdultsAmount { get; set; }
        /// <summary>
        /// 儿童总人数
        /// </summary>
        public virtual int ChildrenAmount { get; set; }
        /// <summary>
        /// 成员详细信息
        /// </summary>
        public virtual IList<DJ_TourGroupMember> Members { get; set; }


    }
}
