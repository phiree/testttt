using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class qumobile_Default : basepage
{
    BLLScenic bllscenic = new BLLScenic();
    TourMembershipProvider tourmembership = new TourMembershipProvider();
    protected void Page_Load(object sender, EventArgs e)
    {
        //ValidPermission();
    }
    Model.ScenicAdmin user;

    private void ValidPermission()
    {

        user = new BLLMembership().GetScenicAdmin((Guid)tourmembership.GetUser(scenicManagerLogin.UserName, true).ProviderUserKey);
        if (user == null)
        {
            lblMessage.Text = "用户名或密码错误";
        }
        else
        {
            Scenic scenic = user.Scenic;
            Response.Redirect("/qumobile/CheckTicket.aspx");
        }
    }


    protected void scenicManagerLogin_LoggedIn(object sender, EventArgs e)
    {
        ValidPermission();
    }
}