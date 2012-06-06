using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourTest.TDD.ScenicCheck
{

    public class Scenic {

        public decimal NormalPrice { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal PayOnlinePrice { get; set; }

        public bool CheckPrice()
        {

            return NormalPrice > OrderPrice && OrderPrice > PayOnlinePrice;
            
        }
    }
    public class Member
    {
        public Guid Id{get;set;}
    }

    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        public Guid Id { get; set; }
        public Member Member { get; set; }
        public DateTime OrderTime { get; set; }
        public IList<OrderDetail> Details { get; set; }
        
    }
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Order Order{ get; set; }
        public Scenic Scenic { get; set; }
        /// <summary>
        /// 购票总数
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 购买时选择的价格 可能是
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 购买时的价格类型.
        /// </summary>
        public string PriceType { get; set; }
    }

   public class ScenicCheckCode
    {
    }
}
