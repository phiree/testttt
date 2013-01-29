using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_QuZhouSpring_TicketStatistics2 : System.Web.UI.Page
{
    BLL.BLLOrder bllorder = new BLL.BLLOrder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRptdate();
        }
    }

    protected void BindRptdate()
    {
        var list=bllorder.GetDaysOrderTotal();
        rptdate.DataSource = list;
        rptdate.DataBind();
    }
}