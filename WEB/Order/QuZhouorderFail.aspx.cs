using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QZOrder_Fail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string errMsg = Request["msg"];
        errMsg = Server.UrlDecode(errMsg);
        lblMsg.Text = errMsg;
    }
}