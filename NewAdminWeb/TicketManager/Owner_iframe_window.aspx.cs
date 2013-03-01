using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using BLL;
using Model;

public partial class TicketManager_Owner_iframe_window : System.Web.UI.Page
{
    BLLScenic bllScenic=new BLLScenic();
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
        lblOwnerScenic.Text = Session["OwnerScenic"].ToString();
        btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindOwner();
    }

    protected void gridOwner_RowCommand(object sender, FineUI.GridCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            Session["OwnerScenic"] = gridOwner.DataKeys[e.RowIndex][0];
            lblOwnerScenic.Text = gridOwner.DataKeys[e.RowIndex][0].ToString();
        }
    }

    protected void gridOwner_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        gridOwner.PageIndex = e.NewPageIndex;
    }

    private void bindOwner()
    {
        gridOwner.DataSource = bllScenic.GetScenic().Where(x=>x.Name.Contains(tbxOwnerName.Text)).ToList();
        gridOwner.DataBind();
    }
}