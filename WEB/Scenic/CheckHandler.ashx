<%@ WebHandler Language="C#" Class="TimeHandler" %>

using System;
using System.Web;
using BLL;
using Model;

public class TimeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.QueryString["date"] != null)
        {
            context.Response.Write(DateTime.Now);
        }
        else
        {
            int ticketId = Convert.ToInt32(context.Request["id"]);
            BLLTicket bllTicket = new BLLTicket();
            Ticket t = bllTicket.GetTicket(ticketId);
            if (t.TourActivity == null)
            {
                context.Response.Write("true");
            }
            else if (DateTime.Now.Hour >= t.TourActivity.BeginHour)
            {
                context.Response.Write("true");

            }
            else
            {
                context.Response.Write(t.TourActivity.BeginHour);
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}