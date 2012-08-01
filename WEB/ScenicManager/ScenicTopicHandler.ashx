<%@ WebHandler Language="C#" Class="ScenicTopicHandler" %>

using System;
using System.Web;

public class ScenicTopicHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        BLL.BLLTopic bllTopic = new BLL.BLLTicket();
        bllTopic.SaveOrUpdateTicket();
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}