using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupBasic
    {
        public string Name { get; set; }
        /// <summary>
        /// 起止时间
        /// </summary>
        public string Bedate { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public string Days { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public string PeopleTotal { get; set; }
        /// <summary>
        /// 成人人数
        /// </summary>
        public string PeopleAdult { get; set; }
        /// <summary>
        /// 儿童人数
        /// </summary>
        public string PeopleChild { get; set; }
        /// <summary>
        /// 开始集结地
        /// </summary>
        public string StartPlace { get; set; }
        /// <summary>
        /// 结束集结地
        /// </summary>
        public string EndPlace { get; set; }
    }
}
