using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _12301_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnOk_Click(object sender, EventArgs e)
    {
        string accountname = txtAccount.Text.Trim();
        string password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text, "MD5");
        if (accountname == "12301_admin" && password == FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"))
        {
            Response.Redirect("/12301/Operation.aspx");
        }
    }
}