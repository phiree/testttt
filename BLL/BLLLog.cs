using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
namespace BLL
{
   public class BLLLog
    {
      static  ILog log = LogManager.GetLogger("tourol");
      public static void LogInfo(string logmsg,int level,string source)
      { 

      }
      public static void Log(string logmsg, int level, string source)
      {
          //log.Debug
         // log.Error();
          //log.Fatal
      }
    }
}
