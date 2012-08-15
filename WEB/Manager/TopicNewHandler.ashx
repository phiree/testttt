<%@ WebHandler Language="C#" Class="TopicNewHandler" %>

using System;
using System.Web;

public class TopicNewHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        BLL.BLLTopic blltopic = new BLL.BLLTopic();
        blltopic.SaveTopic(context.Request["newitem"],null);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}