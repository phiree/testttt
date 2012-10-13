using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Groups_Groups : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        (Master.FindControl("changepwd") as HtmlAnchor).HRef = "/Groups/ChangePwd.aspx";
    }
}
