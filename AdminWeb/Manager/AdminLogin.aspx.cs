using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Manager_AdminLogin : System.Web.UI.Page
{
    TourMembershipProvider tourmembership = new TourMembershipProvider();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        Response.Redirect("ScenicinfoCheckaspx.aspx");
    }
}