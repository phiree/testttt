using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{
    BLL.BLLMembership bllMembership = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        TourMembership tourMembership = bllMembership.GetMember(LoginUser.UserName);
        tourMembership.loginCount += 1;
        tourMembership.lastLogin = DateTime.Now;
        bllMembership.Update(tourMembership);
        new LoginRedirect();
    }
}
