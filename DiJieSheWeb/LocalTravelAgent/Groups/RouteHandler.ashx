<%@ WebHandler Language="C#" Class="RouteHandler" %>

using System;
using System.Web;

public class RouteHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        BLL.BLLDJConsumRecord bllDJCR = new BLL.BLLDJConsumRecord();
        var gcr = bllDJCR.GetGroupConsumRecordByRouteId(context.Request["enterpid"].ToString());
        if (gcr == null)
        {
            context.Response.Write("False");
        }
        else
        {
            context.Response.Write("True");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}