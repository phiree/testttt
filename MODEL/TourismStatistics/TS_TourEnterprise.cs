using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 旅游企业
    /// </summary>
    public class TS_TourEnterprise : TourMembership
    {
        /// <summary>
        /// 旅行社所属区域的区域码
        /// </summary>
     
        public virtual string AreaCode { get; set; }
        public virtual TourEnterpriseType EnterpriseType { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
    }
    public enum TourEnterpriseType
    {
        旅行社=1,
        餐馆,
        景点,
        宾馆,
        饭店

    }
}
