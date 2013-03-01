using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Model;

public partial class _Site : System.Web.UI.MasterPage
{
    public string dptId_dptdetai = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //bind();
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
            returnUrl = "/Login.aspx?returnUrl="+Server.UrlEncode(Request.RawUrl);
            Response.Redirect(returnUrl);
        }
        

    }
}
