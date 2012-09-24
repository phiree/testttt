using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Web.Security;

public partial class TourEnterprise_TE : System.Web.UI.MasterPage
{
    private DJ_TourEnterprise currentTE;
    public DJ_TourEnterprise CurrentTE { get; set; }

    protected override void OnInit(EventArgs e)
    {
        MembershipUser mu = Membership.GetUser();
        if (mu == null || mu.UserName == string.Empty)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {

        }
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
