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
        BLL.BLLScenic bllscenic = new BLL.BLLScenic();
        foreach (var item in datas)
        {
            string[] tmp = item.Split(new char[] { ',' });
            string ticketname = tmp[0];
            ticketname = ticketname.Replace(' ', '+');
            string yuanjia = tmp[1];
            string xianfujia = tmp[2];
            string zaixianjia = tmp[3];
            string ticketid = tmp[4];
            string scid = tmp[5];
            bllTicket.SaveOrUpdateTicket(ticketname, yuanjia, xianfujia, zaixianjia, ticketid, scid);
            Model.ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(int.Parse(scid), 1);
            scp.CheckStatus = Model.CheckStatus.Applied_1;
            bllscenic.UpdateCheckState(scp);
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