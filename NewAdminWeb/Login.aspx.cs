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
    protected void lg_LoggingIn(object sender, EventArgs e)
    {

    }
    protected void lg_LoggedIn(object sender, EventArgs e)
    {
        TourMembership tourMembership = bllMember.GetMember(lg.UserName);
        tourMembership.loginCount += 1;
        tourMembership.lastLogin = DateTime.Now;
        bllMember.Update(tourMembership);
        BLL.BLLMembership bllMembership = new BLLMembership();
        MembershipUser member = (tourmembership.GetUser(lg.UserName, true));
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