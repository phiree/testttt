using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 指定日期的门票分配情况
    /// </summary>
    public class QZTicket:Ticket
    {
        public virtual string ProductCode { get; set; }
    }
}
