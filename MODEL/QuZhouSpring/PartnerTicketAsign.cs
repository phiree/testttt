using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 合作网站 分配的门票数量.
    /// </summary>
    public class PartnerTicketAsign
    {
        public Guid Id { get; set; }
        //合作网站
        public QZSpringPartner Partner { get; set; }
        //分配的数量
        public int AsignedAmount { get; set; }
        //售出总数
        public int SoldAmount { get; set; }

    }
}
