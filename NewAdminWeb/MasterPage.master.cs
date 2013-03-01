using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string themeValue = pmMain.Theme.ToString().ToLower();
        HttpCookie themeCookie = Request.Cookies["Theme"];
        if (themeCookie != null)
        {
            themeValue = themeCookie.Value;
            switch (themeValue)
            {
                case "blue": pmMain.Theme = FineUI.Theme.Blue; break;
                case "access": pmMain.Theme = FineUI.Theme.Access; break;
                case "gray": pmMain.Theme = FineUI.Theme.Gray; break;
                default: pmMain.CustomTheme = themeValue;
                    break;
            }
        }
        bind();
    }

    private void bind()
    {
        MembershipUser mu = Membership.GetUser();
        string returnUrl = "/";
        if (mu != null)
        {
            string[] roles = Roles.GetRolesForUser(mu.UserName);

            if (!Roles.IsUserInRole(mu.UserName, "SiteAdmin"))
            {
                var targetFromParam = Request["returnUrl"];
                if (!string.IsNullOrEmpty(targetFromParam))
                {
                    returnUrl = targetFromParam;
                }
                Response.Redirect(returnUrl);
            }
        }
        else
        {
            returnUrl = "/Login.aspx?returnUrl=" + Server.UrlEncode(Request.RawUrl);
            Response.Redirect(returnUrl);
        }
    }
}
