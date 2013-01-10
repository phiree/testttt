using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///LoginRedirect 的摘要说明
/// </summary>
public class LoginRedirect
{
    //需要跳转的路径
    string noneedreturl = "/err.aspx,/account/logout.aspx";
	public LoginRedirect()
	{
        HttpRequest Request = HttpContext.Current.Request;
        HttpServerUtility Server = HttpContext.Current.Server;
        HttpResponse Response = HttpContext.Current.Response;
		
        //默认跳转到首页
        string returnUrl = "/weibologinsuccess.htm";
        string returnUrlFromParam = Request["returnurl"];
        //返回路径不在url参数里
        if (string.IsNullOrEmpty(returnUrlFromParam))
        {
            HttpCookie cookie = Request.Cookies["ru"];

            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                returnUrl = Server.UrlDecode(cookie.Value);
                cookie.Expires = DateTime.Now.AddMinutes(-10);
                Response.Cookies.Add(cookie);
            }
        }
        else
        {
            returnUrlFromParam = Server.UrlDecode(returnUrlFromParam);
            //
            if (noneedreturl.IndexOf(returnUrlFromParam) >= 0)
            {
                returnUrlFromParam = "/";
            }
            returnUrl = returnUrlFromParam;
        }
        Response.Redirect(returnUrl);
	}
}