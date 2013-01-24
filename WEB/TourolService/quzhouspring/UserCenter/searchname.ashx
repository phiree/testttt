<%@ WebHandler Language="C#" Class="searchname" %>

using System;
using System.Web;
using BLL;
using Model;

public class searchname : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name = context.Request.Form[0];
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}