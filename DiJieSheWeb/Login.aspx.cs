using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Web.Security;
using BLL;
public partial class Login2 : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    BLLMembership bllMember = new BLLMembership();
    protected void lg_LoggedIn(object sender, EventArgs e)
    {

        TourMembership CurrentMember = bllMember.GetMember(lg.UserName);
        string redirectUrl = Redirector.RedirectForUser(CurrentMember);
        Response.Redirect(redirectUrl);
    }
}