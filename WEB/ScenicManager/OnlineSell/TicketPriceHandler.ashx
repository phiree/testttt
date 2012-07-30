<%@ WebHandler Language="C#" Class="TicketPriceHandler" %>

using System;
using System.Web;

public class TicketPriceHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        string ticketname = context.Request.Form["ticketname"];
        string yuanjia = context.Request.Form["yuanjia"];
        string mingxipianjia = context.Request.Form["mingxipianjia"];
        string xianfujia = context.Request.Form["xianfujia"];
        string zaixianjia = context.Request.Form["zaixianjia"];
        string ticketid = context.Request.Form["ticketid"];
        string scid = context.Request.Form["scid"];
        BLL.BLLTicket bllTicket = new BLL.BLLTicket();
        bllTicket.SaveOrUpdateTicket(ticketname, yuanjia, mingxipianjia, xianfujia, zaixianjia, ticketid, scid);
        //System.Collections.Generic.IList<Model.Ticket> tickets = bllTicket.GetTicketByscId(int.Parse(context.Request["scid"]));
        //var json = new System.Runtime.Serialization.Json.DataContractJsonSerializer(tickets.GetType());
        //json.WriteObject(context.Response.OutputStream, tickets);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}