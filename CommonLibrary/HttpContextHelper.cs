using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace CommonLibrary
{

    public sealed class HttpContextHelper
    {
        private HttpContextHelper()
        { }
        /// <summary>
        /// 获取当前站点的虚拟目录名,如果是根站点 则 "/"
        /// </summary>
        /// <returns></returns>
        public static string CurrentVirtualPath
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_POST"]
                    + (HttpContext.Current.Request.ApplicationPath.EndsWith("/") ? HttpContext.Current.Request.ApplicationPath : HttpContext.Current.Request.ApplicationPath + "/");
            }
        }
        /// <summary>
        /// 获取完整的当前站点完整的虚拟目录:如  
        /// </summary>
        /// <returns></returns>
        public static string FullVirtualPath
        {
            get
            {
                string currentPath = CurrentVirtualPath;
                if (currentPath == "/")
                    currentPath = string.Empty;
                string mid = string.Empty;
                if (HttpContext.Current.Request.Url.Host.EndsWith("/") || currentPath.StartsWith("/"))
                {

                }
                else if (HttpContext.Current.Request.Url.Host.EndsWith("/") && currentPath.StartsWith("/"))
                {
                    currentPath = currentPath.Substring(1);
                }
                else
                {
                    mid = "/";
                }
                string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (port == "80")
                {
                    port = string.Empty;
                }
                else
                {
                    port = ":" + port;
                }

                return "http://" + HttpContext.Current.Request.Url.Host + port + mid + currentPath;
            }
        }

    }

}
