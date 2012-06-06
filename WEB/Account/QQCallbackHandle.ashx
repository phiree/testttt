<%@ WebHandler Language="C#" Class="QQCallbackHandle" %>

using System;
using System.Web;

public class QQCallbackHandle : IHttpHandler,System.Web.SessionState.IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        var QQcontext = new QConnectSDK.Context.QzoneContext();
        string state = Guid.NewGuid().ToString().Replace("-", "");
        string scope = "";
        var authenticationUrl = QQcontext.GetAuthorizationUrl(state, scope);
        //request token, request token secret 需要保存起来 
        //在demo演示中，直接保存在全局变量中.真实情况需要网站自己处理 
        context.Session["requeststate"] = state;
        context.Response.Redirect(authenticationUrl);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}