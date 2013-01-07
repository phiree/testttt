using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.Security;
using System.Web.UI.HtmlControls;

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
        BLLDJ_User blldj_user = new BLLDJ_User();
        DJ_User_TourEnterprise DJ_User_TE = null;
        if (mu != null)
        {
            DJ_User_TE = new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey) as DJ_User_TourEnterprise;
        }
        if (mu == null || mu.UserName == string.Empty || DJ_User_TE == null || DJ_User_TE.Enterprise is DJ_DijiesheInfo)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {
            currentTE = DJ_User_TE.Enterprise;
        }
        int perType = (int)DJ_User_TE.PermissionType;
        if (perType == 1 || perType == 3 || perType == 5 || perType == 7)
        {
            li_1.Visible = true;
            li_3.Visible = true;
        }
        else
        {
            li_1.Visible = false;
            li_3.Visible = false;
        }
        if (perType == 2 || perType == 3 || perType == 6 || perType == 7)
        {
            li_2.Visible = true;
        }
        else
            li_2.Visible = false;
        if (perType == 4 || perType == 5 || perType == 6 || perType == 7)
        {
            li_5.Visible = true;
        }
        else
            li_5.Visible = false;

        (Master.FindControl("changepwd") as HtmlAnchor).HRef = "/TourEnterprise/TEChangePwd.aspx";
        (Master.FindControl("changedetails") as HtmlAnchor).HRef = "/TourEnterprise/TEInfo.aspx";
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
