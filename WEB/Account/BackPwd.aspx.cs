using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_BackPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["pwdcode"] == null)
        {
            Response.Redirect("/");
        }
        else
        {
            string id = Request.QueryString["id"];
            string pwd = Request.QueryString["pwdcode"];
            TourMembership user = new BLLMembership().GetUserByUserId(Guid.Parse(id));
            if (user.Password != pwd)
            {
                Response.Redirect("/");
            }
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        string pwd = Request.QueryString["pwdcode"];
        TourMembership user = new BLLMembership().GetUserByUserId(Guid.Parse(id));
        string newpwd = txtPwd.Text;
        string encryptedNewPsw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpwd, "MD5");
        user.Password = encryptedNewPsw;
        new BLLMembership().updateinfo(user);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('重置密码成功!');window.location='/Account/Login.aspx'", true);
    }
}