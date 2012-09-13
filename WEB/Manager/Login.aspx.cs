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

    /// <summary>
    /// 登陆
    /// </summary>
    /// <remarks>
    ///  原始裸机混乱,修改之.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Login1_LoggingIn(object sender, EventArgs e)
    {
        MembershipUser member = (tourmembership.GetUser(Login1.UserName, true));
        if (member == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('未找到该用户名，请重新确认！');", true);
        }
        if (Roles.IsUserInRole(member.UserName, "SiteAdmin"))
        {
            Response.Redirect("/default.aspx");
        }
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名或密码错误');", true);
    }
}