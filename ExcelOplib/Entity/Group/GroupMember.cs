using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupMember
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Memtype { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Memname { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Memid { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Memphone { get; set; }
        /// <summary>
        /// 导游号
        /// </summary>
        public string GuideNo { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string Carno { get; set; }
    }
}
