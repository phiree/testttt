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
        string redirectUrl = string.Empty;
        Type UserType = CurrentMember.GetType();
        HttpCookie cookie = new HttpCookie("DJSID", "0");
        Response.Cookies.Add(cookie);
        if (UserType == typeof(DJ_User_Gov))
        {
            redirectUrl = "/TourManagerDpt/";
        }
        else if (UserType == typeof(DJ_User_TourEnterprise))
        {
            DJ_User_TourEnterprise entUser = (DJ_User_TourEnterprise)CurrentMember;
            if (entUser == null)
            { return; }
            DJ_TourEnterprise ent = entUser.Enterprise;
            if (ent.Type == EnterpriseType.旅行社)
            {
                redirectUrl = "/LocalTravelAgent/";
            }
            else
            {
                redirectUrl = "/TourEnterprise/";
            }
            Response.Cookies["DJSID"].Value = entUser.Enterprise.Id.ToString();
        }
        else if (CurrentMember.Name == "admin")
        {
            redirectUrl = "/admin/";
        }
        Response.Redirect(redirectUrl);
    }
}