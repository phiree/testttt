<%@ WebHandler Language="C#" Class="QQweiboHandle" %>

using System;
using System.Web;

public class QQweiboHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        HttpCookie c_appkey = new HttpCookie("appkey", "801130045");
        HttpCookie c_appsecret = new HttpCookie("appsecret", "17d89ba17cd735a9ef7bf558907ed970");
        context.Response.Cookies.Add(c_appkey);
        context.Response.Cookies.Add(c_appsecret);

        //获取request_token
        if (GetRequestToken(c_appkey.Value, c_appsecret.Value, context) == false)
        {
            return;
        }
        context.Response.Redirect("http://open.t.qq.com/cgi-bin/authorize?oauth_token=" + context.Response.Cookies["tokenKey"].Value);

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
        oauthKey.callbackUrl = "http://www.tourol.cn/Account/QQweiboRecieveHandle.ashx";

        QWeiboSDK.QWeiboRequest request = new QWeiboSDK.QWeiboRequest();
        return ParseToken(request.SyncRequest(QWeiboSDK.OauthKey.urlRequesToken, "GET", oauthKey, parameters, null), context);
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
        context.Response.Cookies["tokenKey"].Value = token1[1];

        string[] token2 = strTokenSecrect.Split('=');
        if (token2.Length < 2)
        {
            return false;
        }
        context.Response.Cookies["tokenSecret"].Value = token2[1];

        return true;
    }
}