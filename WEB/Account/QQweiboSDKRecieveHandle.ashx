<%@ WebHandler Language="C#" Class="QQweiboRecieveHandle" %>

using System;
using System.Web;

public class QQweiboRecieveHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        HttpCookie c_openid = new HttpCookie("openid", null);
        HttpCookie c_openkey = new HttpCookie("openkey", null);
        HttpCookie c_verify = new HttpCookie("OauthVerify", null);
        HttpCookie c_oauthtokenkey = new HttpCookie("oauthtokenkey", null);
        HttpCookie c_oauthtokensecret = new HttpCookie("oauthtokensecret", null);
        context.Response.Cookies.Add(c_openid);
        context.Response.Cookies.Add(c_openkey);
        context.Response.Cookies.Add(c_verify);
        context.Response.Cookies.Add(c_oauthtokenkey);
        context.Response.Cookies.Add(c_oauthtokensecret);

        string verifier = context.Request.QueryString["oauth_verifier"];
        context.Response.Cookies["OauthVerify"].Value = context.Request.QueryString["oauth_verifier"];
        if (GetAccessToken(
            context.Request.Cookies["appKey"].Value,
            context.Request.Cookies["appSecret"].Value,
            context.Request.Cookies["unoauthtokenkey"].Value,
            context.Request.Cookies["unoauthtokensecret"].Value,
           verifier,
            context) == false)
        {
            return;
        }
        context.Response.Cookies["openid"].Value = context.Request.QueryString["openid"];
        context.Response.Cookies["openkey"].Value = context.Request.QueryString["openkey"];
        QWeiboSDK.QWeiboRequest request = new QWeiboSDK.QWeiboRequest();
        var url = "http://open.t.qq.com/api/user/info";
        var oauthkey = new QWeiboSDK.OauthKey()
        {
            customKey = context.Request.Cookies["appKey"].Value,
            customSecret = context.Request.Cookies["appSecret"].Value,
            tokenKey = context.Response.Cookies["oauthtokenkey"].Value,
            tokenSecret = context.Response.Cookies["oauthtokensecret"].Value
        };
        var jsonResult = request.SyncRequest(url, "GET", oauthkey, new System.Collections.Generic.List<QWeiboSDK.Parameter>(), null);
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        Model.Qweiboinfo Qwuinfo = jss.Deserialize<Model.Qweiboinfo>(jsonResult);
        context.Response.Redirect("/Account/Handler.ashx?openid=" + context.Request.QueryString["openid"] +
                "&&nickname=" + Qwuinfo.data.nick + "&&opentype=" + Model.Opentype.TencentWeibo);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private bool GetAccessToken(string customKey, string customSecret, string requestToken, string requestTokenSecrect, string verify, HttpContext context)
    {
        string url = "https://open.t.qq.com/cgi-bin/access_token";
        System.Collections.Generic.List<QWeiboSDK.Parameter> parameters = new System.Collections.Generic.List<QWeiboSDK.Parameter>();
        QWeiboSDK.OauthKey oauthKey = new QWeiboSDK.OauthKey();
        oauthKey.customKey = customKey;
        oauthKey.customSecret = customSecret;
        oauthKey.tokenKey = requestToken;
        oauthKey.tokenSecret = requestTokenSecrect;
        oauthKey.verify = verify;

        QWeiboSDK.QWeiboRequest request = new QWeiboSDK.QWeiboRequest();
        try
        {
            return ParseToken(request.SyncRequest(url, "GET", oauthKey, parameters, null), context);
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
        context.Response.Cookies["oauthtokenkey"].Value = token1[1];

        string[] token2 = strTokenSecrect.Split('=');
        if (token2.Length < 2)
        {
            return false;
        }
        context.Response.Cookies["oauthtokensecret"].Value = token2[1];

        return true;
    }

}