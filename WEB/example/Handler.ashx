<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;
using CommonLibrary;
public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
       
        string dd = context.Server.UrlDecode(context.Request.Form[0]);
        HttpPostHelp hph = new HttpPostHelp();
        dd= hph.Decrypt(dd, "abcdefgh");
        
        context.Response.Write(dd);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}