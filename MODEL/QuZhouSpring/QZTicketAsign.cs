﻿using System;
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
       public virtual Guid Id { get; set; }
       //门票-->景区
       //本次活动的门票代码.
       public virtual string ProductCode { get; set; }
       //网站对应的门票
       public virtual Ticket Ticket { get; set; }
       //总数
       public virtual int Amount { get; set; }
       //已售总数
       public virtual int SoldAmount { get; set; }
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
    }
}