<%@ WebHandler Language="C#" Class="TicketPriceHandler" %>

using System;
using System.Web;

public class TicketPriceHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        //string ticketname = context.Request.Form["ticketname"];
        //string yuanjia = context.Request.Form["yuanjia"];
        //string mingxipianjia = context.Request.Form["mingxipianjia"];
        //string xianfujia = context.Request.Form["xianfujia"];
        //string zaixianjia = context.Request.Form["zaixianjia"];
        //string ticketid = context.Request.Form["ticketid"];
        //string scid = context.Request.Form["scid"];
        string[] datas = context.Request.Form[0].Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
        BLL.BLLTicket bllTicket = new BLL.BLLTicket();
        foreach (var item in datas)
        {
            string[] tmp = item.Split(new char[] { ',' });
            string ticketname = tmp[0];
            string yuanjia = tmp[1];
            string mingxipianjia = tmp[2];
            string xianfujia = tmp[3];
            string zaixianjia = tmp[4];
            string ticketid = tmp[5];
            string scid = tmp[6];
            bllTicket.SaveOrUpdateTicket(ticketname, yuanjia, mingxipianjia, xianfujia, zaixianjia, ticketid, scid);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}