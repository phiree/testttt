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
}