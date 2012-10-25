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
        /// 团队编号
        /// </summary>
        public virtual string No { get; set; }
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
        private int daysAmount;
        public virtual int DaysAmount { get {

            TimeSpan ts = EndDate - BeginDate;
            return ts.Days;
        } set { daysAmount = value; } }
        /// <summary>
        /// 成人总人数
        /// </summary>
        public virtual int AdultsAmount { get; set; }
        /// <summary>
        /// 儿童总人数
        /// </summary>
        public virtual int ChildrenAmount { get; set; }
        /// <summary>
        /// 港澳台人数
        /// </summary>
        public virtual int GangaotaisAmount { get; set; }
        /// <summary>
        /// 外宾人数
        /// </summary>
        public virtual int ForeignersAmount { get; set; }
        /// <summary>
        /// 集合点
        /// </summary>
        public virtual string Gether { get; set; }
        /// <summary>
        /// 返程点
        /// </summary>
        public virtual string BackPlace { get; set; }

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


    }
}
