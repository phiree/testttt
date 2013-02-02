using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Model
{
    /// <summary>
    /// 门票的票价
    /// </summary>
    public class TicketPrice
    {
        public virtual int Id { get; set; }
        public virtual Ticket Ticket { get; set; }

        public virtual PriceType PriceType { get; set; }
        public virtual decimal Price { get; set; }
        ////更新时间
        //public virtual DateTime UpdateTime { get; set; }
        ////是否正在使用中
        //public bool IsInUse { get; set; }

    }
    public enum PriceType
    {
        [Description("门市价")]
        Normal = 1//正常价格/门市价格
           ,
        [Description("预定价")]
        PreOrder//预定价格(本地区票)
        ,
        [Description("优惠价")]
        PayOnline//优惠价(网上支付)
       
       
    }
}
