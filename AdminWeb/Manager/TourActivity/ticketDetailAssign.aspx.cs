using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_ticketDetailAssign : System.Web.UI.Page
{
    BLLTourActivity bllTa = new BLLTourActivity();
    BLLTicket bllTicket = new BLLTicket();
    BLLActivityPartner bllAp = new BLLActivityPartner();
    BLLActivityTicketAssign bllAta = new BLLActivityTicketAssign();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }


    private void bindData()
    {
        DateTime dt = DateTime.Parse(Request.QueryString["dateTime"]);
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTa.GetOne(actId);
        rptTicket.DataSource = ta.Tickets;
        rptTicket.DataBind();
    }
    protected void rptTicket_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            TourActivity ta = bllTa.GetOne(actId);
            DateTime dt = DateTime.Parse(Request.QueryString["dateTime"]);
            Ticket t = e.Item.DataItem as Ticket;
            Repeater rptAssign = e.Item.FindControl("rptAssign") as Repeater;
            rptAssign.DataSource= ta.GetActivityAssignForTicketDate(t.ProductCode, dt);
            rptAssign.DataBind();
        }
    }
    protected void rptTicket_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Save")
        {
            Ticket t = bllTicket.GetTicket(int.Parse(e.CommandArgument.ToString()));
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            TourActivity ta = bllTa.GetOne(actId);
            DateTime dt = DateTime.Parse(Request.QueryString["dateTime"]);
            Repeater rptAssign = e.Item.FindControl("rptAssign") as Repeater;
            foreach (RepeaterItem item in rptAssign.Items)
            {
                TextBox txtPaName = item.FindControl("txtPaName") as TextBox;
                TextBox txtAmount=item.FindControl("txtAmount") as TextBox;
                HiddenField hfPaId = item.FindControl("hfPaId") as HiddenField;
                ActivityPartner ap = bllAp.GetOne(Guid.Parse(hfPaId.Value));
                if (txtAmount.Text == "")
                    txtAmount.Text = "0";
                ActivityTicketAssign Ata = ta.GetActivityAssignForPartnerTicketDate(ap.PartnerCode, t.ProductCode, dt)[0];
                Ata.AssignedAmount = int.Parse(txtAmount.Text);
                bllAta.SaveOrUpdate(Ata);
            }
            bindData();
        }
    }
}