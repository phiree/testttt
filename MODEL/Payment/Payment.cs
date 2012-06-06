using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 支付记录
    /// </summary>
   public  class Payment
    {
       public virtual Guid Id { get; set; }
       //dingdan
       public virtual Order Order { get; set; }
       //支付接口类型: 支付宝/网银等
       public virtual PayType PayType { get; set; }
       //支付总额
       public virtual decimal PayAmount { get; set; }

       public virtual DateTime BeginPay { get; set; }
      
       public virtual string RequestStringToPay
       {
           get;
           set;
       }
       public virtual DateTime EndPay { get; set; }
       public virtual string ReceivedStringFromPay
       {
           get;
           set;
       }
       //接口字符串


    }
    public enum PayType
    {
     AliPay=1
    }
}
