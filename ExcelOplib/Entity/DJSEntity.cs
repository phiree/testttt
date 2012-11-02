using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class DJSEntity
    {
        /// <summary>
        /// 1级部门
        /// </summary>
        public string Department1 { get; set; }
        /// <summary>
        /// 2级部门
        /// </summary>
        public string Department2 { get; set; }
        /// <summary>
        /// 3级部门
        /// </summary>
        public string Department3 { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Diqu { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public 数据类型 EnterpType { get; set; }
    }

    public enum 数据类型
    {
        地接社=1,
        景区,
        宾馆
    }
}
