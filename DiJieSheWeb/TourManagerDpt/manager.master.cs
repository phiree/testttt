using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using BLL;
using Model;

public partial class TourManagerDpt_manager : System.Web.UI.MasterPage
{
    public string dptid { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    private void bind()
    {

        MembershipUser mu = Membership.GetUser();
        BLLDJ_User blldj_user = new BLLDJ_User();
        Model.TourMembership tm = new Model.TourMembership();
        if (mu != null)
        {
            tm = new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey);
            if (tm is DJ_User_TourEnterprise)
            {
                dptid = (tm as DJ_User_TourEnterprise).Enterprise.Id.ToString();
                //laETName.Text = (tm as DJ_User_TourEnterprise).Enterprise.Name;
            }
            if (tm is DJ_User_Gov)
            {
                dptid = (tm as DJ_User_Gov).GovDpt.Id.ToString();
                int perType=(int)(tm as DJ_User_Gov).PermissionType;
                if (perType == 1 || perType == 3 || perType == 5 || perType == 7)
                {
                    li_1.Visible = true;
                    li_2.Visible = true;
                }
                else
                {
                    li_1.Visible = false;
                    li_2.Visible = false;
                }
                if (perType == 2 || perType == 3 || perType == 6 || perType == 7)
                {
                    li_3.Visible = true;
                }
                else
                {
                    li_3.Visible = false;
                }
                if (perType == 4 || perType == 5 || perType == 6 || perType == 7)
                {
                    li_4.Visible = true;
                }
                else
                {
                    li_4.Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("/Login.aspx");
        }
        (Master.FindControl("changepwd") as HtmlAnchor).HRef = "/TourManagerDpt/ChangePwd.aspx";
        (Master.FindControl("changedetails") as HtmlAnchor).HRef = "/TourManagerDpt/ChangeDetails.aspx?dptId=" + dptid;
    }
}
