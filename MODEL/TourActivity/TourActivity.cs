using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 活动类
    /// </summary>
  public  class TourActivity:IActivityRule
    {
      
      public Guid Id { get; set; }
      public string Name { get; set; }
      public DateTime BeginDate { get; set; }
      public DateTime EndDate { get; set; }
      IList<ActivityPartner> Partners { get; set; }
      List<Ticket> Ticket{ get; set; }
      /// <summary>
      /// 门票分配详情
      /// </summary>
      IList<ActivityTicketAssign> ActivityTicketAssign { get; set; }


      public bool HasEnoughAmount()
      {
          throw new NotImplementedException();
      }

      public bool CheckIdCardAmountPerTicket()
      {
          throw new NotImplementedException();
      }
    }
}
