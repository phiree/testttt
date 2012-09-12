using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 旅游管理部门
    /// </summary>
    public class TS_Manager : TourMembership
    {
        /// <summary>
        /// 所属区域的区域码
        /// </summary>
        public virtual string AreaCode { get; set; }

    }
}
