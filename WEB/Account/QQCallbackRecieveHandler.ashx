<%@ WebHandler Language="C#" Class="QQCallbackRecieveHandler" %>

using System;
using System.Web;

public class QQCallbackRecieveHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.Params["code"] != null)
        {
            QConnectSDK.QOpenClient qzone = null;
            QConnectSDK.Models.User currentUser = null;
            var verifier = context.Request.Params["code"];
            string state = context.Session["requeststate"].ToString();
            qzone = new QConnectSDK.QOpenClient(verifier, state);
            currentUser = qzone.GetCurrentUser();
            if (null != currentUser)
            {
                context.Session["QzoneOauth"] = qzone;
                context.Response.Redirect("/Account/Handler.ashx?openid=" + qzone.OAuthToken.OpenId +
                    "&&nickname=" + currentUser.Nickname + "&&opentype=" + Model.Opentype.TencentWeibo);
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}