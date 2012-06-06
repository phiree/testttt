using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;
public partial class Manager_AdminLogin : System.Web.UI.Page
{
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        TourMembership member = bllMember.GetMemberById((Guid) Membership.GetUser().ProviderUserKey);
        if (Roles.IsUserInRole(member.Name, "SiteAdmin"))
        {
            Response.Redirect("/Manager/");
        }
        else {
            ErrHandler.Redirect(ErrType.AccessDenied);
        }
        
    }
}