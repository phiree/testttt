using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 指定日期的门票分配情况
    /// </summary>
   public class QZTicketAsign
    {
       public QZTicketAsign()
       {
           PartnerTicketAsign = new List<QZPartnerTicketAsign>();
       }
       public virtual Guid Id { get; set; }
       //门票-->景区
      //已停用,直接从 ticket获取
       public virtual string ProductCode { get; set; }
       //网站对应的门票
       public virtual Ticket Ticket { get; set; }
       //总数
       private int _amount = 0;
       public virtual int Amount {
           get {
               _amount = 0;
               foreach (QZPartnerTicketAsign ct in PartnerTicketAsign)
               {
                   _amount += ct.AsignedAmount;
               }
               return _amount;
           }
           set { _amount = value; }
       }
       //已售总数

       public virtual int SoldAmount
       {
           get
           {
               return GetSolidAmount();
           }
       
       }
       //日期
       public virtual DateTime Date { get; set; }
       /// <summary>
       /// 该景区门票的分配情况.
       /// </summary>
       public virtual IList<QZPartnerTicketAsign> PartnerTicketAsign
       {
           get;
           set;
       }
       /// <summary>
       /// 分发门票
       /// </summary>
       public virtual void Asign()
       { 
       
       }

       public  virtual  bool ValidAmount()
       {
           int asigned = 0;
           foreach (QZPartnerTicketAsign ct in PartnerTicketAsign)
           {
               asigned += ct.AsignedAmount;
           }
           return Amount == asigned;
       }

       private int GetSolidAmount()
       {
           int solidAmount = 0;
           foreach (var item in PartnerTicketAsign)
           {
               solidAmount += item.SoldAmount;
           }
           return solidAmount;
       }
    }
}
