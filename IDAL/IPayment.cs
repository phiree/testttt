using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
  public  interface IPayment
    {
      /// <summary>
      /// 保存/更新支付记录
      /// </summary>
      /// <param name="payment"></param>
      void Save(Payment payment);
      Payment GetByOrder(int orderId);
    }
}
