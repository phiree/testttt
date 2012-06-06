using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///需要用户登录
///在cookie里写入跳转跳转url
/// </summary>
public class AuthPage : System.Web.UI.Page
{

  
    public TourMembership CurrentMember;
    BLL.BLLMembership bllMember = new BLL.BLLMembership();
   protected override void OnLoad(EventArgs e)
    {
         MembershipUser CurrentUser = Membership.GetUser();
         if (CurrentUser != null)
         {
             CurrentMember = bllMember.GetMemberById((Guid)CurrentUser.ProviderUserKey);
         }
         else
         {
             HttpCookie cookie = new HttpCookie("ru", Server.UrlEncode(Request.RawUrl));
             cookie.Expires = DateTime.Now.AddMinutes(5);
             Response.Cookies.Add(cookie);
             Response.Redirect("/account/login.aspx");
         }
        base.OnLoad(e);
    }
}