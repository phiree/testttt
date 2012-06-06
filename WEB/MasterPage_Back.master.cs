using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;
public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BindLink();
    }
    private void BindLink()
    {
        //20120405 SST 修改前版本
        //MembershipUser mu = Membership.GetUser();
        //if (mu == null) return;

        //Model.TourMembership member = new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey);
        //hrefScenicAdmin.Visible = Roles.IsUserInRole(member.Name, "ScenicAdmin");
        //hrefSiteAdmin.Visible = Roles.IsUserInRole(member.Name, "SiteAdmin");

        //20120405 SST 修改后版本 添加第三方登录
        //MembershipUser mu = Membership.GetUser();
        //TourMembership member = BLLFactory.CreateBLLMember().GetMemberByOpenid(HiddenOpenid.Value, Model.Opentype.Tencent);
        //if (mu == null && member == null)
        //{
        //    return;
        //}
        ////第三方登录
        //if (mu == null && member != null)   
        //{
        //    hrefScenicAdmin.Visible = false;
        //    hrefSiteAdmin.Visible = false;
        //}
        ////本地登录
        //else if (mu != null && member == null)
        //{
        //    member = BLLFactory.CreateBLLMember().GetMemberById((Guid)mu.ProviderUserKey);
        //    hrefScenicAdmin.Visible = Roles.IsUserInRole(member.Name, "ScenicAdmin");
        //    hrefSiteAdmin.Visible = Roles.IsUserInRole(member.Name, "SiteAdmin");
        //}
    }
}
