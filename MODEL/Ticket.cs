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
    public class Ticket
    {
        public Ticket()
        {
            TicketPrice = new List<TicketPrice>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual TicketsType TicketsType { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual bool Lock { get; set; }
        
        public virtual IList<TicketPrice> TicketPrice { get; set; }
        /// <summary>
        /// 获得某个类型的票价
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual decimal GetPrice(PriceType type)
        {
            var tp = TicketPrice.Where<TicketPrice>(x => x.PriceType == type).FirstOrDefault();
            if (tp == null) return 0 ;
            return tp.Price;
        }
    }
}
