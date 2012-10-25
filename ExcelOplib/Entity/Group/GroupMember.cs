using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupMember
    {
        #region v.10/22
        ///// <summary>
        ///// 类型
        ///// </summary>
        //public string Memtype { get; set; }
        ///// <summary>
        ///// 姓名
        ///// </summary>
        //public string Memname { get; set; }
        ///// <summary>
        ///// 身份证号
        ///// </summary>
        //public string Memid { get; set; }
        ///// <summary>
        ///// 电话
        ///// </summary>
        //public string Memphone { get; set; }
        ///// <summary>
        ///// 证件号
        ///// </summary>
        //public string Cardno { get; set; }
        ///// <summary>
        ///// 身份证校验结果
        ///// </summary>
        ////public string IdValidate { get; set; }
        #endregion

        #region v.10/31
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
        /// 类型
        /// </summary>
        public string Memtype { get; set; }

        public string Cardno { get; set; }
        #endregion
    }
}
