using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lg_LoggedIn(object sender, EventArgs e)
    {
        Response.Redirect("/Groups/GroupList.aspx");
    }
}