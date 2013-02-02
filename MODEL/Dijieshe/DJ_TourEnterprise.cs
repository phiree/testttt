using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 旅游企业信息/饭店,宾馆,景点,购物点
    /// </summary>
    public class DJ_TourEnterprise
    {
        public DJ_TourEnterprise()
        {
            Tickets = new List<TicketBase>();
            lastUpdateTime = DateTime.Now;
        }
        public virtual IList<TicketBase> Tickets { get; set; }
        public virtual int Id { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public virtual Area Area { get; set; }

        public virtual string Name { get; set; }

        public virtual string Address { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        public virtual string ChargePersonName { get; set; }
        public virtual string ChargePersonPhone { get; set; }
        public virtual string Phone { get; set; }
        ///// <summary>
        ///// 是否经过认证,成为奖励方位内的企业.
        ///// </summary>
        public virtual bool IsVerified { get {
            return ProvinceVeryfyState == RewardType.已纳入
                || CityVeryfyState == RewardType.已纳入
                || CountryVeryfyState == RewardType.已纳入;
        } }
        //是否是省级奖励方位内的企业
        public virtual RewardType ProvinceVeryfyState { get; set; }
        //是否是市级奖励范围内的企业
        public virtual RewardType CityVeryfyState { get; set; }
        //是否是县级奖励范围内的企业
        public virtual RewardType CountryVeryfyState { get; set; }
        public virtual EnterpriseType Type { get; set; }
        public virtual string SeoName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Url { get; set; }
        public virtual string Buslicense { get; set; }
        public virtual string Level { get; set; }
        private DateTime lastUpdateTime = DateTime.Now;
        public virtual DateTime LastUpdateTime { get { return lastUpdateTime; } set { lastUpdateTime = value; } }
        public virtual RewardType GetRewart(Area area)
        {
            RewardType t = 0;
            switch (area.Level)
            {
                case AreaLevel.区县: t = CountryVeryfyState; break;
                case AreaLevel.省: t = ProvinceVeryfyState; break;
                case AreaLevel.市: t = CityVeryfyState; break;
            }
            return t;
        }
    }
    public enum EnterpriseType
    {
        景点 = 1,
        饭店 = 2,
        宾馆 = 4,
        购物点 = 8,
        旅行社 = 16
    }

    public enum RewardType
    {
        已纳入 = 1,
        从未纳入 = 2,
        纳入后移除 = 4
    }
}
