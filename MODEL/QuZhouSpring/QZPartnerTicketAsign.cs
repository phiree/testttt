using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 合作网站 分配的门票数量.
    /// </summary>
    public class QZPartnerTicketAsign
    {
        public virtual Guid Id { get; set; }
        //合作网站
        public virtual QZSpringPartner Partner { get; set; }
        //分配的数量
        public virtual int AsignedAmount { get; set; }
        //售出总数
        public virtual int SoldAmount { get; set; }

         public virtual bool HasEnoughTickets(int requestAmount)
       {
           return AsignedAmount >= SoldAmount + requestAmount;
       }

    }
}
