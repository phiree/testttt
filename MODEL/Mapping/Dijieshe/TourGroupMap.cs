using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model
{
    //团队信息
    public class TourGroupMap:ClassMap<DJ_TourGroup>
    {
        public TourGroupMap()
        {
            Id(x => x.Id);
            References<DJ_DijiesheInfo>(x => x.Dijieshe);
            Map(x => x.Name);
            Map(x => x.BeginDate);
            Map(x => x.EndDate);
            Map(x => x.CarNo);
            Map(x => x.DaysAmount);
            Map(x => x.DriverName);
            Map(x => x.DriverPhone);
            Map(x => x.GuideIdCardNo);
            Map(x => x.AdultsAmount);
            Map(x => x.ChildrenAmount);

            Map(x => x.GuideName);
            Map(x => x.GuidePhone);
            HasMany<DJ_Route>(x => x.RouteDescription);
            HasMany<DJ_TourGroupMember>(x => x.Members);
        }
        /// <summary>
        /// 该团队所属的地接社
        /// </summary>
        public DJ_DijiesheInfo Dijieshe { get; set; }
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
        public virtual string RouteDescription { get; set; }

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

        public IList<DJ_TourGroupMember> Members { get; set; }


    }
}
