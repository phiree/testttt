using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 客户网站 分配的门票数量.
    /// </summary>
  public class ClientTicketAsign
    {
      public Guid Id { get; set; }
      public QzClient Client { get; set; }
      public int AsignedAmount { get; set; }
      public int SoldAmount { get; set; }
    }
}
