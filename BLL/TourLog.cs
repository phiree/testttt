using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace BLL
{
   public class TourLog
    {
       private static readonly ILog errLog = LogManager.GetLogger("ErrorLogger");
       private static readonly ILog payLog = LogManager.GetLogger("PaymentLogger");

       public static void LogPayment(string paymentMsg)
       {
           payLog.Info(paymentMsg);
       }
       public static void LogError(object errorMsg)
       {
           errLog.Error(errorMsg);
       }
    }
}
