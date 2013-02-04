using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace BLL
{
   public class TourLog
    {
       public static readonly ILog ErrorLog = LogManager.GetLogger("ErrorLogger");
       public static readonly ILog PaymentLog = LogManager.GetLogger("PaymentLogger");
       public static readonly ILog DebugLog = LogManager.GetLogger("DebugerLogger");

       public static void LogPayment(string paymentMsg)
       {
           PaymentLog.Info(paymentMsg);
       }
       public static void LogError(object errorMsg)
       {
           ErrorLog.Error( System.Web.HttpContext.Current.Request.RawUrl+Environment.NewLine+ errorMsg);
           
       }
    }
}
