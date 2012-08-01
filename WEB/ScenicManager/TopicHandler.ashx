<%@ WebHandler Language="C#" Class="TopicHandler" %>

using System;
using System.Web;

public class TopicHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string tnames = context.Request.Form["scenicnames"];
        string scid = context.Request.Form["scid"];
        System.Collections.Generic.IList<string> topicnames=tnames.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
        BLL.BLLTopic blltopic = new BLL.BLLTopic();
        blltopic.Save(topicnames, int.Parse(scid));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}