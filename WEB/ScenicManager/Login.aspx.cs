using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Model;

public partial class AdminDefault :basepage
{
    BLLScenic bllscenic = new BLLScenic();
    BLLMembership bllMembership = new BLLMembership();
    TourMembershipProvider tourmembership = new TourMembershipProvider();
   protected void Page_Load(object sender, EventArgs e)
    {
        //ValidPermission();
    }
    Model.ScenicAdmin user;

    private void ValidPermission()
    {

        user = new BLLMembership().GetScenicAdmin((Guid)tourmembership.GetUser(Login1.UserName, true).ProviderUserKey);
        if (user == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名或密码错误')", true);
        }
        else
        {
            Scenic scenic = user.Scenic;
            if (!string.IsNullOrEmpty(scenic.Position))
            {
                HttpCookie httpcookie = new HttpCookie("unitposition", scenic.Position);
                Response.Cookies.Add(httpcookie);
            }
            else
            {
                HttpCookie httpcookie = new HttpCookie("unitposition", "120.159033,30.28376");
                Response.Cookies.Add(httpcookie);
            }
            Response.Cookies.Add(new HttpCookie("idcard", ""));
            Response.Redirect("/ScenicManager/");
        }
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        TourMembership tourMembership = bllMembership.GetMember(Login1.UserName);
        tourMembership.loginCount += 1;
        tourMembership.lastLogin = DateTime.Now;
        bllMembership.Update(tourMembership);
        ValidPermission();
    }

}