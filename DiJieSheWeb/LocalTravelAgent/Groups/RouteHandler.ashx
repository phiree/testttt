<%@ WebHandler Language="C#" Class="RouteHandler" %>

using System;
using System.Web;
using System.Collections.Generic;

public class RouteHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        BLL.BLLDJConsumRecord bllDJCR = new BLL.BLLDJConsumRecord();
        string[] enternamelist = context.Request.QueryString[0].Split(new char[] { '-', '1', '2', '3', '4', '5', '6' }, StringSplitOptions.RemoveEmptyEntries);
        string gid=context.Request.QueryString[1];
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        string jsonResult = "{";
        foreach (var item in enternamelist)
        {
            jsonResult+=@""""+item+@""":"""+(bllDJCR.GetGCR8Name(item, gid) == null ? "0" : "1")+@""",";
        }
        jsonResult=jsonResult.Substring(0, jsonResult.Length - 1);
        jsonResult += "}";
        context.Response.Write(jsonResult);
     }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}