using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupRoute
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string RouteDate { get; set; }
        /// <summary>
        /// 早餐
        /// </summary>
        public string Breakfast { get;set;}
        /// <summary>
        /// 午餐
        /// </summary>
        public string Lunch { get; set; }
        /// <summary>
        /// 晚餐
        /// </summary>
        public string Dinner { get; set; }
        /// <summary>
        /// 住宿
        /// </summary>
        public string Hotel { get; set; }
        /// <summary>
        /// 景点
        /// </summary>
        public string Scenic { get; set; }
        /// <summary>
        /// 购物点
        /// </summary>
        public string ShoppingPoint { get; set; }
    }
}
