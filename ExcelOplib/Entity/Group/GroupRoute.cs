using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupRoute
    {
        #region v.10/22

        ///// <summary>
        ///// 日期
        ///// </summary>
        //public string RouteDate { get; set; }
        ///// <summary>
        ///// 地区
        ///// </summary>
        //public string City { get; set; }
        ///// <summary>
        ///// 早餐
        ///// </summary>
        //public string Breakfast { get;set;}
        ///// <summary>
        ///// 午餐
        ///// </summary>
        //public string Lunch { get; set; }
        ///// <summary>
        ///// 晚餐
        ///// </summary>
        //public string Dinner { get; set; }
        ///// <summary>
        ///// 住宿1
        ///// </summary>
        //public string Hotel1 { get; set; }
        ///// <summary>
        ///// 住宿2
        ///// </summary>
        //public string Hotel2 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic1 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic2 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic3 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic4 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic5 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic6 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic7 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic8 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic9 { get; set; }
        ///// <summary>
        ///// 景点
        ///// </summary>
        //public string Scenic10 { get; set; }
        ///// <summary>
        ///// 购物点
        ///// </summary>
        //public string ShoppingPoint1 { get; set; }
        ///// <summary>
        ///// 购物点
        ///// </summary>
        //public string ShoppingPoint2 { get; set; }
        ///// <summary>
        ///// 购物点
        ///// </summary>
        //public string ShoppingPoint3 { get; set; }
        #endregion

        #region v.10/31
        /// <summary>
        /// 日期
        /// </summary>
        public string RouteDate { get; set; }
        /// <summary>
        /// 住宿
        /// </summary>
        public string Hotel { get; set; }
        /// <summary>
        /// 景点
        /// </summary>
        public string Scenic { get; set; }
        #endregion
    }

    public class GroupRouteNew
    {
        #region v.10/22
        /// <summary>
        /// 日期
        /// </summary>
        public string RouteDate { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 早餐
        /// </summary>
        public Model.DJ_Route Breakfast { get; set; }
        /// <summary>
        /// 午餐
        /// </summary>
        public Model.DJ_Route Lunch { get; set; }
        /// <summary>
        /// 晚餐
        /// </summary>
        public Model.DJ_Route Dinner { get; set; }
        /// <summary>
        /// 住宿1
        /// </summary>
        public IList<Model.DJ_Route> Hotel { get; set; }
        /// <summary>
        /// 景点
        /// </summary>
        public IList<Model.DJ_Route> Scenic { get; set; }
        /// <summary>
        /// 购物点
        /// </summary>
        public IList<Model.DJ_Route> ShoppingPoint { get; set; }
    #endregion

    }
}
