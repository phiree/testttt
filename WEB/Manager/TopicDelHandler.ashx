<%@ WebHandler Language="C#" Class="TopicDelHandler" %>

using System;
using System.Web;

public class TopicDelHandler : IHttpHandler {
    
    BLL.BLLTopic blltopic = new BLL.BLLTopic();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        Model.Topic topic = blltopic.GetTopicByName(context.Request["delitem"]);
        blltopic.DelTopic(topic);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}