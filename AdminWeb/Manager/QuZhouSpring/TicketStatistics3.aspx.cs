using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_QuZhouSpring_TicketStatistics3 : System.Web.UI.Page
{
    BLL.BLLOrder bllorder = new BLL.BLLOrder();
    string s_date = string.Empty;
    int tickettotal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        s_date=Request["date"]==null?string.Empty:Request["date"].ToString();
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        if (!string.IsNullOrWhiteSpace(s_date))
        {
            rptStatic.DataSource = bllorder.GetDateOrderTotal(s_date);
            rptStatic.DataBind();
        }
    }

    protected void rptStatic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            var lblnum = e.Item.FindControl("lblnum") as Label;
            if (lblnum != null && !string.IsNullOrWhiteSpace(lblnum.Text))
            {
                tickettotal += int.Parse(lblnum.Text);
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            var lbltotal = e.Item.FindControl("lbltotal") as Label;
            lbltotal.Text = tickettotal.ToString();
        }
    }
}