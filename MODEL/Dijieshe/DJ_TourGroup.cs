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
          //  Workers = new List<DJ_Group_Worker>();
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
            return ts.Days+1;
        } set { daysAmount = value; } }
        /// <summary>
        /// 成人总人数
        /// </summary>
     
        public virtual int AdultsAmount { 
            get { return Members.Where(x => x.MemberType == MemberType.成人游客).Count(); } }
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
        /// 路线描述
        /// </summary>
        public virtual IList<DJ_Route> Routes { get; set; }
        /// <summary>
        ///导游和司机信息
        /// </summary>
        public virtual IList<DJ_Group_Worker> Workers { get {

            List<DJ_Group_Worker> works = new List<DJ_Group_Worker>();
            foreach (DJ_TourGroupMember m in Members)
            {
                if (m.MemberType == MemberType.导游)
                {
                    DJ_Group_Worker w = new DJ_Group_Worker();
                    w.DJ_TourGroup = m.DJ_TourGroup;
                    w.IDCard = m.IdCardNo;
                    w.Name = m.RealName;
                    w.Phone = m.PhoneNum;
                    w.SpecificIdCard = m.SpecialCardNo;
                    w.WorkerType = DJ_GroupWorkerType.导游;
                    works.Add(w);
                }
                
            }
            return works;
        } }
      
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
}
