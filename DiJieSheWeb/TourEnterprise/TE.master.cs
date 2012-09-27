using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.Security;

public partial class TourEnterprise_TE : System.Web.UI.MasterPage
{
    private DJ_TourEnterprise currentTE;

    public DJ_TourEnterprise CurrentTE
    {
        get { return currentTE; }
        set { currentTE = value; }
    }

    protected override void OnInit(EventArgs e)
    {
        MembershipUser mu = Membership.GetUser();
        BLLDJ_User blldj_user=new BLLDJ_User();
        DJ_User_TourEnterprise DJ_User_TE=null;
        if (mu != null)
        {
            DJ_User_TE=blldj_user.GetUser_TEbyId((Guid)mu.ProviderUserKey);
        }
        if (mu == null || mu.UserName == string.Empty||DJ_User_TE==null)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {
            currentTE = DJ_User_TE.Enterprise;
        }
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
