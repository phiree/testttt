<%@ WebHandler Language="C#" Class="TicketPriceHandler" %>

using System;
using System.Web;

public class TicketPriceHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        string[] datas = context.Request.Form[0].Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
        BLL.BLLTicket bllTicket = new BLL.BLLTicket();
        BLL.BLLScenic bllscenic = new BLL.BLLScenic();
        foreach (var item in datas)
        {
            string[] tmp = item.Split(new char[] { ',' });
            string ticketname = tmp[0];
            if (string.IsNullOrWhiteSpace(ticketname)) continue;
            ticketname = ticketname.Replace(' ', '+');
            string yuanjia = tmp[1];
            string xianfujia = tmp[2];
            string zaixianjia = tmp[3];
            string ticketid = tmp[4];
            string scid = tmp[5];
            string begindate = tmp[6];
            string enddate = tmp[7];
            bllTicket.SaveOrUpdateTicket(ticketname, yuanjia, xianfujia, zaixianjia, ticketid, scid,begindate,enddate);
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