using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Account_Register : System.Web.UI.Page
{
    BLLMembership bllMember = new BLLMembership();
    BLLProm bllProm = new BLLProm();
    protected void Page_Load(object sender, EventArgs e)
    {
        // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

    }

    protected void btnRegist_Click(object sender, EventArgs e)
    {
        string username = txtBoxLoginname.Text.Trim();
        string password = txtBoxPwd.Text.Trim();
        string email = txtPost.Text.Trim();
        TourMembership isexist = bllMember.GetMember(username);
        if (isexist != null)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Button), "1", "alert('该用户名已注册，请直接登录。')", true);
            return;
        }
        bllMember.CreateUser(username, string.Empty, string.Empty,
        string.Empty, txtBoxLoginname.Text.Trim(), txtBoxPwd.Text.Trim(),email);
        FormsAuthentication.SetAuthCookie(username, false /* createPersistentCookie */);
        if (Request.Cookies["promid"] != null)
        {
            bllProm.AddPromInfo(new Guid(Request.Cookies["promid"].Value), "腾讯");
        }
        new LoginRedirect();// Response.Redirect("/account/regsuccess.aspx");
    }
}
