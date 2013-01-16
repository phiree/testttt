using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// 为接入方 分配景区门票.
/// </summary>
public partial class Manager_QuZhouSpring_ClientManger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Manager/QuZhouSpring/ClientEditor.aspx");
    }
}