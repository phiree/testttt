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
    private DJ_DijiesheInfo Currentdjs;

    public DJ_DijiesheInfo CurrentDJS
    {
        get { return Currentdjs; }
        set { Currentdjs = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        MembershipUser mu = Membership.GetUser();
        BLLDJ_User blldj_user = new BLLDJ_User();
        DJ_User_TourEnterprise DJ_User_TourEnterprise = null;
        if (mu != null)
        {
            DJ_User_TourEnterprise = new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey) as DJ_User_TourEnterprise;
        }
        if (mu == null || mu.UserName == string.Empty || DJ_User_TourEnterprise == null || !(DJ_User_TourEnterprise.Enterprise is DJ_DijiesheInfo))
        {
            Response.Redirect("/Login.aspx");
        }
        int perType=(int)DJ_User_TourEnterprise.PermissionType;
        if (perType == 1 || perType == 3 || perType == 5 || perType == 9 || perType == 7 || perType == 11 || perType == 13 || perType == 15)
            li_1.Visible = true;
        else
            li_1.Visible = false;
        if (perType == 2 || perType == 3 || perType == 6 || perType == 10 || perType == 7 || perType == 11 || perType == 14 || perType == 15)
        {
            li_3.Visible = true;
            li_4.Visible = true;
        }
        else
        {
            li_3.Visible = false;
            li_4.Visible = false;
        }
        if (perType == 4 || perType == 5 || perType == 6 || perType == 12 || perType == 7 || perType == 14 || perType == 13 || perType == 15)
        {
            li_6.Visible = true;
        }
        else
        {
            li_6.Visible = false;
        }
        if (perType == 8 || perType == 9 || perType == 10 || perType == 12 || perType == 11 || perType == 13 || perType == 14 || perType == 15)
        {
            li_2.Visible = true;
            li_5.Visible = true;
            li_7.Visible = true;
            li_8.Visible = true;
        }
        else
        {
            li_2.Visible = false;
            li_5.Visible = false;
            li_7.Visible = false;
            li_8.Visible = false;
        }
        CurrentDJS = DJ_User_TourEnterprise.Enterprise as DJ_DijiesheInfo;
        (Master.FindControl("changepwd") as HtmlAnchor).HRef = "/LocalTravelAgent/ChangePwd.aspx";
        (Master.FindControl("changedetails") as HtmlAnchor).HRef = "/localtravelagent/djsedit.aspx";
        base.OnInit(e);
    }
}
