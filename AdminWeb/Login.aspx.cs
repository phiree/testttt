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
    BLL.BLLMembership bllMembership = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    BLLMembership bllMember = new BLLMembership();
    protected void democlick(object o, EventArgs e)
    {

        CommonLibrary.Notification.Show(this, "登录提示", "登录成功","");
        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "pop",
        //                "$(function(){PopMsg('Iam here!',null,'/',true);});",true
        //                );
    }
  
    bool isvalid = false;
  
   
    private void PopMsg() {
        string returnUrl = "/";
        string userName = lg.UserName;

        string[] roles = Roles.GetRolesForUser(userName);

        if (Roles.IsUserInRole(userName, "SiteAdmin"))
        {
            var targetFromParam = Request["returnUrl"];
            if (!string.IsNullOrEmpty(targetFromParam))
            {
                returnUrl = targetFromParam;
            }
            //  ClientScript.RegisterClientScriptBlock
            //ScriptManager
            ClientScript.RegisterStartupScript(Page.GetType(), "pop",
                      "$(function(){PopMsg('Iam here!,null," + returnUrl + "');});"
                      );
            // Response.Redirect(returnUrl);
        }
        else
        {

        }
    }

    protected void lg_LoggedIn(object sender, EventArgs e)
    {
        TourMembership tourMembership = bllMembership.GetMember(lg.UserName);
        tourMembership.loginCount += 1;
        tourMembership.lastLogin = DateTime.Now;
        bllMembership.Update(tourMembership);
    }
  
}