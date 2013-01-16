<%@ WebHandler Language="C#" Class="QQweiboHandle" %>

using System;
using System.Web;

public class QQweiboHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Cookies.Clear();
        HttpCookie c_appkey = new HttpCookie("appkey", "801154804");
        HttpCookie c_appsecret = new HttpCookie("appsecret", "0e31863380d0d82de81d23253d640c06");
        HttpCookie c_unoauthtokenkey = new HttpCookie("unoauthtokenkey", null);
        HttpCookie c_unoauthtokensecret = new HttpCookie("unoauthtokensecret", null);
        context.Response.Cookies.Add(c_appkey);
        context.Response.Cookies.Add(c_appsecret);
        context.Response.Cookies.Add(c_unoauthtokenkey);
        context.Response.Cookies.Add(c_unoauthtokensecret);

        //获取request_token
        if (GetRequestToken(c_appkey.Value, c_appsecret.Value, context) == false)
        {
            return;
        }
        context.Response.Redirect("http://open.t.qq.com/cgi-bin/authorize?oauth_token=" + context.Response.Cookies["unoauthtokenkey"].Value);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private bool GetRequestToken(string customKey, string customSecret, HttpContext context)
    {
        System.Collections.Generic.List<QWeiboSDK.Parameter> parameters = new System.Collections.Generic.List<QWeiboSDK.Parameter>();
        QWeiboSDK.OauthKey oauthKey = new QWeiboSDK.OauthKey();
        oauthKey.customKey = customKey;
        oauthKey.customSecret = customSecret;
        oauthKey.callbackUrl = System.Configuration.ConfigurationManager.AppSettings["QQWeiboCallBackUrl"];

        QWeiboSDK.QWeiboRequest request = new QWeiboSDK.QWeiboRequest();
        try
        {
            return ParseToken(request.SyncRequest(QWeiboSDK.OauthKey.urlRequesToken, "GET", oauthKey, parameters, null), context);
        }
        catch
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.QQOAuth);
            return false;
        }
    }
    private bool ParseToken(string response, HttpContext context)
    {
        if (string.IsNullOrEmpty(response))
        {
            return false;
        }

        string[] tokenArray = response.Split('&');

        if (tokenArray.Length < 2)
        {
            return false;
        }

        string strTokenKey = tokenArray[0];
        string strTokenSecrect = tokenArray[1];

        string[] token1 = strTokenKey.Split('=');
        if (token1.Length < 2)
        {
            return false;
        }
        context.Response.Cookies["unoauthtokenkey"].Value = token1[1];

        string[] token2 = strTokenSecrect.Split('=');
        if (token2.Length < 2)
        {
            return false;
        }
        context.Response.Cookies["unoauthtokensecret"].Value = token2[1];

        return true;
    }
}