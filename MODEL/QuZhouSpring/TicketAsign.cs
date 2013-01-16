using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 景区门票总量
    /// </summary>
   public class TicketAsign
    {
       public Guid Id { get; set; }
       //门票-->景区
       public Ticket Ticket { get; set; }
       //总数
       public int Amount { get; set; }
       public int SoldAmount { get; set; }
       public IList<ClientTicketAsign> ClientTicketAsign
       {
           get;
           set;
       }
       public virtual bool ValidAmount()
       {
           int asigned = 0;
           foreach (ClientTicketAsign ct in ClientTicketAsign)
           {
               asigned += ct.AsignedAmount;
           }
           return Amount == asigned;
       }
    }
}
