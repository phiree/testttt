<%@ WebHandler Language="C#" Class="TimeHandler" %>

using System;
using System.Web;

public class TimeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int ticketId =Convert.ToInt32( context.Request["id"]);
        if (context.Request.QueryString["now"] != null)
        {
            context.Response.Write(DateTime.Now.ToString());
        }
        else
        {
            string Hour = DateTime.Now.Hour.ToString();
            context.Response.Write(Hour);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}