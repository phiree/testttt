using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Web.Security;
using BLL;

public partial class LTALogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    BLLMembership bllMember = new BLLMembership();
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        TourMembership CurrentMember = bllMember.GetMember(Login1.UserName);
        DJ_User_TourEnterprise dj_user= bllMember.GetMemberById(CurrentMember.Id) as DJ_User_TourEnterprise;
        if (dj_user != null)
        {
            Response.Redirect("/LocalTravelAgent/");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名或者密码错误')", true);
        }
    }
}