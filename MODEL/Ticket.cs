using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 景区的门票定义
    /// 有多个价格:门市价 预订价 优惠价 
    /// </summary>
    public class Ticket:TicketBase
    {
        public Ticket()
        {
            TicketPrice = new List<TicketPrice>();
            BeginDate = new DateTime(2013, 1, 1);
            EndDate = DateTime.MaxValue;
        }
        /// <summary>
        /// 米胖的门票
        /// </summary>
        public virtual string MipangId { get; set; }
        //只需要显示一个价格时使用的门票
        public virtual bool IsMain { get; set; }
        //属于那张套票
        public virtual UnionTicket UnionTicket { get; set; }
        //属于哪个景区
        public virtual Scenic Scenic { get; set; }
       /// <summary>
        /// 获得某个类型的票价
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public  override decimal GetPrice(PriceType type)
        {
            var tp = GetTicketPrice(type);
            if (tp == null) return 0;
            return tp.Price;
        }
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
        public override bool IsBelongTo(Scenic s)
        {
            return s.Id == Scenic.Id;
        }
      

    }
}
