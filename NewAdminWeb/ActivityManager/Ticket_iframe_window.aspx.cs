using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using FineUI;

public partial class ActivityManager_Ticket_iframe_window : System.Web.UI.Page
{
    BLLScenic bllScenic = new BLLScenic();
    BLLTicket bllTicket = new BLLTicket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    private void InitData()
    {
        bindOwner();
        if (Session["OwnerTicket"] != "" && Session["OwnerTicket"]!=null)
            lblOwnerScenic.Text = Session["OwnerTicket"].ToString().Split(',')[2] + "-" + Session["OwnerTicket"].ToString().Split(',')[1];
        btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindOwner();
    }

    protected void gridTicketOwner_RowCommand(object sender, FineUI.GridCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            Session["OwnerTicket"] = (gridTicketOwner.DataKeys[e.RowIndex][0] + "," + gridTicketOwner.DataKeys[e.RowIndex][1] + "," + gridTicketOwner.DataKeys[e.RowIndex][2]);
            lblOwnerScenic.Text = gridTicketOwner.DataKeys[e.RowIndex][2].ToString() + "-" + gridTicketOwner.DataKeys[e.RowIndex][1].ToString();
        }
    }

    protected void gridTicketOwner_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        gridTicketOwner.PageIndex = e.NewPageIndex;
    }

    private void bindOwner()
    {
        gridTicketOwner.DataSource = bllTicket.GetAll<Ticket>().Where(x => x.Name.Contains(tbxOwnerName.Text)).ToList();
        gridTicketOwner.DataBind();
    }
}