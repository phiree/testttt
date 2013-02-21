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
    public class TicketNormal:Ticket
    {
        public TicketNormal()
        {
            TicketPrice = new List<TicketPrice>();
            BeginDate = new DateTime(2013, 1, 1);
            EndDate = DateTime.MaxValue;
        }
        /// <summary>
        /// 米胖的门票
        /// </summary>
        public virtual string MipangId { get; set; }
    
       
 
    
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
       
        public override bool IsBelongTo(Scenic s)
        {
            return s.Id == Scenic.Id;
        }
      

    }
}
