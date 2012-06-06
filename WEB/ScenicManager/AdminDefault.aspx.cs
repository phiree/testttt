using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class AdminDefault :basepage
{
    BLLScenic bllscenic = new BLLScenic();
    TourMembershipProvider tourmembership = new TourMembershipProvider();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        //Model.ScenicAdmin user = new BLLMembership().GetScenicAdminByUserName(Login1.UserName);
        //Scenic scenic = user.Scenic;
        //if (!string.IsNullOrEmpty(scenic.Position))
        //{
        //    HttpCookie httpcookie = new HttpCookie("unitposition",scenic.Position);
        //    Response.Cookies.Add(httpcookie);
        //}
        //else
        //{
        //    HttpCookie httpcookie = new HttpCookie("unitposition", "120.159033,30.28376");
        //    Response.Cookies.Add(httpcookie);
        //}
        //Response.Redirect("UpdateScenticInfo.aspx");
    }
    protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        //Model.ScenicAdmin user = new BLLMembership().GetScenicAdmin(Login1.UserName);
        //if (user == null)
        //{
        //    //Response.Write("<script>alert('您不是后台用户')</script>");
        //    //Response.End();
        //    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "alert('您不是后台用户')", true);
        //    e.Cancel = true;
        //    return;
        //}
    }
}