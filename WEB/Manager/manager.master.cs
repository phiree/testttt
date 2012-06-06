using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
public partial class Manager_manager : System.Web.UI.MasterPage
{

    BLL.BLLMembership bllMember = new BLL.BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
       MembershipUser mu=  Membership.GetUser();
       if (mu == null||mu.UserName==string.Empty)
       {
           Response.Redirect("/manager/login.aspx");
       }
       TourMembership member = bllMember.GetMember(mu.UserName);
       if (! Roles.IsUserInRole(member.Name, "SiteAdmin"))
       {
           BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
       }
    }
}
