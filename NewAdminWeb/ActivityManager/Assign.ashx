<%@ WebHandler Language="C#" Class="Assign" %>

using System;
using System.Web;
using BLL;
using Model;

public class Assign : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        BLLActivityTicketAssign BLLAta = new BLLActivityTicketAssign();
        context.Response.ContentType = "text/plain";
        Guid ataId = Guid.Parse(context.Request.QueryString["id"]);
        ActivityTicketAssign ata = BLLAta.GetOne(ataId);
        ata.AssignedAmount = int.Parse(context.Request.QueryString["ataCount"]);
        BLLAta.SaveOrUpdate(ata);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}