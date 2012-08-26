<%@ WebHandler Language="C#" Class="SaveHTML" %>

using System;
using System.Web;
using System.Configuration;
using CommonLibrary;
using System.Text;

public class SaveHTML : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string type = context.Request.QueryString["type"]; 
        string scname = context.Request.QueryString["scname"];
        string scfunctype = context.Request.QueryString["scfunctype"];
        string htmldata=context.Request.Form["html"];
        HTMLInfo htmlinfo = new HTMLInfo();
        htmlinfo.WriteHTMLInfo(type, scname, scfunctype, htmldata);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}