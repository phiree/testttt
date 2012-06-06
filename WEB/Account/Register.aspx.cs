using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class Account_Register : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        
    }



    protected void btnRegist_Click(object sender, EventArgs e)
    {
       

        BLLMembership bllMember = new BLLMembership();
        BLLProm bllProm=new BLLProm();
       
            string username = txtBoxLoginname.Text.Trim();
            string password = txtBoxPwd.Text.Trim();

        

            bllMember.CreateUser(username, string.Empty, string.Empty,
            string.Empty, txtBoxLoginname.Text.Trim(), txtBoxPwd.Text.Trim());
            FormsAuthentication.SetAuthCookie(username, false /* createPersistentCookie */);
            if (Request.Cookies["promid"] != null)
            {
                bllProm.AddPromInfo(new Guid(Request.Cookies["promid"].Value), "腾讯");
            }
            Response.Redirect("/account/regsuccess.aspx");
       

    }
}
