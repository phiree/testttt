using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class LocalTravelAgent_LTA : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        MembershipUser mu = Membership.GetUser();
        BLLDJ_User blldj_user = new BLLDJ_User();
        DJ_User_TourEnterprise DJ_User_Ent = null;
        if (mu != null)
        {
            DJ_User_Ent = new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey) as DJ_User_TourEnterprise;
        }
        if (mu == null || mu.UserName == string.Empty || DJ_User_Ent == null)
        {
            Response.Redirect("/Login.aspx");
        }
        (Master.FindControl("changepwd") as HtmlAnchor).HRef = "/LocalTravelAgent/ChangePwd.aspx";
        base.OnInit(e);
    }
}
