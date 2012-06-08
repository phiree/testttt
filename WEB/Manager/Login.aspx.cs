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
    TourMembershipProvider tourmembership = new TourMembershipProvider();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        MembershipUser member = (tourmembership.GetUser(Login1.UserName, true));
        if (Roles.IsUserInRole(member.UserName, "SiteAdmin"))
        {
            Response.Redirect("/Manager/");
        }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名或密码错误');", true);



        
        
    }
}