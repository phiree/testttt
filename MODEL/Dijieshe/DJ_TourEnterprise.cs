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
        /// <summary>
        /// 是否经过认证,成为奖励方位内的企业.
        /// </summary>
        public virtual bool IsVeryfied { get; set; }
        public virtual EnterpriseType Type { get; set; }
    }
    public enum EnterpriseType
    {
        景点 = 1,
        饭店,
        宾馆,
        购物点,
        旅行社
    }
}
