using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupBasic
    {
        /// <summary>
        /// 团队编号
        /// </summary>
        public string GroupNo { get; set; }
        /// <summary>
        /// 团队名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string Begindate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string Enddate { get; set; }
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
        /// 外宾人数
        /// </summary>
        public string Foreigners { get; set; }
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
