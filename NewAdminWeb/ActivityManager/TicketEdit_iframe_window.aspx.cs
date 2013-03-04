using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Model;
using BLL;

public partial class ActivityManager_TicketEdit_iframe_window : System.Web.UI.Page
{
    BLLTicket bllTicket = new BLLTicket();
    Ticket t;
    protected void Page_Load(object sender, EventArgs e)
    {
        t = bllTicket.GetOne(int.Parse(Request.QueryString["Id"]));
        if (!IsPostBack)
        {
            bindData();
        }
    }


    private void bindData()
    {
        txtOwnerName.Text = t.Scenic.Name;
        txtTicketName.Text = t.Name;
        txtTicketCode.Text = t.ProductCode;
        txtBeginDate.Text = t.BeginDate.ToString("yyyy-MM-dd");
        txtEndDate.Text = t.EndDate.ToString("yyyy-MM-dd");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        t.Name = txtTicketName.Text;
        t.ProductCode = txtTicketCode.Text;
        t.BeginDate = DateTime.Parse(txtBeginDate.Text);
        t.EndDate = DateTime.Parse(txtEndDate.Text);
        bllTicket.SaveOrUpdate(t);
        Alert.ShowInTop("保存成功", MessageBoxIcon.Information);
    }
}