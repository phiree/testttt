using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Model;

public partial class m : System.Web.UI.MasterPage
{
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
            tm=new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey);
            if (tm is DJ_User_TourEnterprise)
            {
                laETName.Text = (tm as DJ_User_TourEnterprise).Enterprise.Name;
            }
            if (tm is DJ_User_Gov)
            {
                laETName.Text = (tm as DJ_User_Gov).GovDpt.Name;
            }
        }
    }
}
