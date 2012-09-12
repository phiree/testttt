<<<<<<< HEAD
﻿using System;
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
        public virtual bool IsMain { get; set; }
        /// <summary>
        /// 序号,用来控制门票的排序
        /// </summary>
        public virtual int OrderNumber { get; set; }
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
        //是否属于套票
        public virtual bool IsPackage { get; set; }
        //景区Id,以逗号隔开
        public virtual string ScenicIds { get; set; }
    }
}
=======
﻿using System;
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
        public virtual bool IsMain { get; set; }
        /// <summary>
        /// 序号,用来控制门票的排序
        /// </summary>
        public virtual int OrderNumber { get; set; }
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
        /// <summary>
        /// 本门票对应的景区,联票需要重写此方法
        /// </summary>
        /// <returns></returns>
        public virtual IList<Scenic> GetScenics()
        {
            IList<Scenic> ss = new List<Scenic>();
            ss.Add(Scenic);
            return ss;
        }
    }
}
>>>>>>> 套票修改
