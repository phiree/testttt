using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
public partial class Admin_Demo : System.Web.UI.Page
{


   
    protected void btn_Click(object sender,EventArgs e)
    {
        if (tbxCode.Text != "zjs12301")
        {
            tbxCode.Text = "口令错误";
            return;
        }
        string name = ((Button)sender).Text.Split('-')[1];
        DemoLogin(name, "/scenicmanager/12301.aspx");
    }

    private void DemoLogin(string userName, string targetUrl)
    {
         
        FormsAuthentication.SetAuthCookie(userName, true);
        //  Response.Redirect(targetUrl);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "",
        "var opener=window.open('" + targetUrl + "','Graph','width=960,height=650;'); opener=null;", true);
    }

}