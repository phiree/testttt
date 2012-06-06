<%@ WebHandler Language="C#" Class="QweiboHandler" %>

using System;
using System.Web;

public class QweiboHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        HttpCookie c_appkey = new HttpCookie("appkey", "801130045");
        HttpCookie c_appsecret = new HttpCookie("appsecret", "17d89ba17cd735a9ef7bf558907ed970");
        context.Response.Cookies.Add(c_appkey);
        context.Response.Cookies.Add(c_appsecret);

        //获取request_token
        //if (GetRequestToken(c_appkey.Value, c_appsecret.Value, context) == false)
        //{
        //    return;
        //}
        GetRequestToken(c_appkey.Value, c_appsecret.Value, context);
        context.Response.Redirect("http://open.t.qq.com/cgi-bin/authorize?oauth_token=" + context.Response.Cookies["tokenKey"].Value);

    }
    private void GetRequestToken(string customKey, string customSecret, HttpContext context)
    {
        System.Collections.Generic.List<CommonLibrary.QweiboSDK.Parameter> parameters = new System.Collections.Generic.List<CommonLibrary.QweiboSDK.Parameter>();
        QWeiboSDK.OauthKey oauthKey = new QWeiboSDK.OauthKey();
        oauthKey.customKey = customKey;
        oauthKey.customSecret = customSecret;
        oauthKey.callbackUrl = "http://www.tourol.cn/Account/QQweiboRecieveHandle.ashx";

        CommonLibrary.QweiboSDK.OAuth oauth = new CommonLibrary.QweiboSDK.OAuth();
        string queryString = null;
        var url = "https://open.t.qq.com/cgi-bin/request_token";
        var httpMethod = "GET";
        var key = oauthKey;
        string oauthUrl = oauth.GetOauthUrl(url, httpMethod, key.customKey, key.customSecret,
            key.tokenKey, key.tokenSecret, key.verify, key.callbackUrl, parameters, out queryString);
        if (!string.IsNullOrEmpty(queryString))
        {
            oauthUrl += "?" + queryString;
        }
        context.Response.Redirect(oauthUrl);
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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}