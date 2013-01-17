using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace BLL
{
   public class TourLog
    {
       public static readonly ILog LogInstance = LogManager.GetLogger("ErrorLogger");
       private static readonly ILog payLog = LogManager.GetLogger("PaymentLogger");

       public static void LogPayment(string paymentMsg)
       {
           payLog.Info(paymentMsg);
       }
       public static void LogError(object errorMsg)
       {
           LogInstance.Error( System.Web.HttpContext.Current.Request.RawUrl+Environment.NewLine+ errorMsg);
           
       }
    }
}
