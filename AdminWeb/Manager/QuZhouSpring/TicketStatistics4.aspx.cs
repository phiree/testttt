using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_QuZhouSpring_TicketStatistics4 : System.Web.UI.Page
{
    BLL.BLLOrder bllorder = new BLL.BLLOrder();
    string s_scenicname = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        s_scenicname = Request["scenicname"] == null ? string.Empty : Request["scenicname"].ToString();
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        if (!string.IsNullOrWhiteSpace(s_scenicname))
        {
            rptStatic.DataSource = bllorder.GetDaysScenicOrderTotal(s_scenicname);
            rptStatic.DataBind();
        }
    }
}