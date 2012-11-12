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
            Workers = new List<DJ_Group_Worker>();
            Vehicles = new List<DJ_Group_Vehicle>();
            Routes = new List<DJ_Route>();
        }
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 该团队所属的地接社
        /// </summary>
        public virtual DJ_DijiesheInfo DJ_DijiesheInfo { get; set; }
        /// <summary>
        /// 团队名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public virtual DateTime BeginDate { get; set; }



        /// <summary>
        /// 结束日期
        /// </summary>
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// 总天数
        /// </summary>

        public virtual int DaysAmount { get; set; }
        /// <summary>
        /// 成人总人数
        /// </summary>

        public virtual DJ_User_TourEnterprise DijiesheEditor { get; set; }
        public virtual int AdultsAmount
        {
            get { return Members.Where(x => x.MemberType == MemberType.成人游客).Count(); }
        }
        /// <summary>
        /// 儿童总人数
        /// </summary>
        public virtual int ChildrenAmount { get { return Members.Where(x => x.MemberType == MemberType.儿童).Count(); } }
        /// <summary>
        /// 港澳台人数
        /// </summary>
        public virtual int GangaotaisAmount { get { return Members.Where(x => x.MemberType == MemberType.港澳台).Count(); } }
        /// <summary>
        /// 外宾人数
        /// </summary>
        public virtual int ForeignersAmount { get { return Members.Where(x => x.MemberType == MemberType.外宾).Count(); } }
        /// <summary>
        /// 集合点
        /// </summary>
        public virtual string Gether { get; set; }
        public virtual int TotalTourist { get { return AdultsAmount + ChildrenAmount + GangaotaisAmount + ForeignersAmount; } }
        /// <summary>
        /// 返程点
        /// </summary>
        public virtual string BackPlace { get; set; }

        /// <summary>
        /// 尚未开始/正在精心/已经结束 -->计算类属性不能用于nql查询
        /// </summary>
        public virtual TourGroupState GroupState
        {
            get
            {
                DateTime now = DateTime.Now;

                if (now < BeginDate)
                {
                    return TourGroupState.尚未开始;
                }
                else if (now <= BeginDate && now < EndDate.AddDays(1))
                {
                    return TourGroupState.正在进行;
                }
                else
                {
                    return TourGroupState.已经结束;
                }
            }
        }
        /// <summary>
        /// 路线描述
        /// </summary>
        public virtual IList<DJ_Route> Routes { get; set; }
        /// <summary>
        ///导游和司机信息
        /// </summary>
        public virtual IList<DJ_Group_Worker> Workers { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        public virtual IList<DJ_Group_Vehicle> Vehicles { get; set; }

        /// <summary>
        /// 成员详细信息
        /// </summary>
        public virtual IList<DJ_TourGroupMember> Members { get; set; }

        public virtual void DeleteMember(DJ_TourGroupMember member)
        {
            this.Members.Remove(member);
        }

    }
    public enum TourGroupState
    {

        尚未开始=1,
        正在进行=2,
        已经结束=4
    }
}
