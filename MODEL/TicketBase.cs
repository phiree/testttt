using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    ///门票的基类, 统一 单一门票 和 套票
    public abstract class TicketBase
    {

        public virtual int Id { get; set; }
        /// <summary>
        /// 该门票的拥有者
        /// </summary>
        public virtual DJ_TourEnterprise Scenic { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual IList<TicketPrice> TicketPrice { get; set; }
        public virtual bool IsMain { get; set; }
        public virtual bool Lock { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual decimal OrderNumber { get; set; }
        /// <summary>
        /// 截止有效期
        /// </summary>
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        //参与的活动
        public virtual TourActivity TourActivity { get; set; }
        public abstract bool IsBelongTo(Scenic s);
        public abstract decimal GetPrice(PriceType priceType);
        /// <summary>
        /// 获取这个票价
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual TicketPrice GetTicketPrice(PriceType type)
        {
            var tp = TicketPrice.Where<TicketPrice>(x => x.PriceType == type).FirstOrDefault();
            if (tp == null) return null;
            else return tp;
        }
        
    }
}
