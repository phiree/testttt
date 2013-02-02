using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_ticketList : System.Web.UI.Page
{
    BLLTourActivity bllTa = new BLLTourActivity();
    BLLTicket bllTicket = new BLLTicket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }


    private void bindData()
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        rptTicket.DataSource = bllTa.GetOne(actId).Tickets;
        rptTicket.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int ticketId = int.Parse(txtTicketId.Text);
        Ticket t= bllTicket.GetTicket(ticketId);
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        t.TourActivity = bllTa.GetOne(actId);
        bllTicket.SaveOrUpdateTicket(t);
        bindData();
    }
    protected void rptTicket_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "save")
        {
            int ticketId = int.Parse(e.CommandArgument.ToString());
            Ticket t = bllTicket.GetTicket(ticketId);
            TextBox txtProductCode = e.Item.FindControl("txtProductCode") as TextBox;
            t.ProductCode = txtProductCode.Text;
            TextBox txtBeginDate = e.Item.FindControl("txtBeginDate") as TextBox;
            t.BeginDate = DateTime.Parse(txtBeginDate.Text);
            TextBox txtEndDate = e.Item.FindControl("txtEndDate") as TextBox;
            t.EndDate = DateTime.Parse(txtEndDate.Text);
            bllTicket.SaveOrUpdateTicket(t);
            bindData();
        }
    }
}