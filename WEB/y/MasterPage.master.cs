using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;

public partial class qumobile_MasterPage : MasterPage
{
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        if (Membership.GetUser() != null && bllMember.GetScenicAdmin((Guid)Membership.GetUser().ProviderUserKey)!=null)
        {
            //title.InnerHtml = "旅游在线-" + bllMember.GetScenicAdmin((Guid)Membership.GetUser().ProviderUserKey).Scenic.Name + "景区后台";
        }
    }
}
