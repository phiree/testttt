<%@ WebHandler Language="C#" Class="TimeHandler" %>

using System;
using System.Web;

public class TimeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string Hour = DateTime.Now.Hour.ToString();
        context.Response.Write(Hour);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}