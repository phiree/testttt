using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    /// <summary>
    /// 根据不同用户类型跳转到不同路径
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        BLLMembership bllMember = new BLLMembership();
        TourMembership member = bllMember.GetMember(Membership.GetUser().UserName);
        if(member.GetType()==typeof(DJ_User_Gov))
        {}
        else if (member.GetType() == typeof(DJ_User_TourEnterprise))
        {
            DJ_User_TourEnterprise userEnt = (DJ_User_TourEnterprise)member;
            if (userEnt.GetType() == typeof(DJ_DijiesheInfo))
            {
                Response.Redirect("/LocalTravelAgent/");
            }
            else
            {
                Response.Redirect("/TourEnterprise/");
            }
        }
        else if ((member.GetType() == typeof(DJ_User_Gov)))
        {
            Response.Redirect("/TourManagerDpt/");
        }
        else if (member.Name == "admin")
        {
            Response.Redirect("/Admin/");
        }
        else
        {
            ErrHandler.Redirect(ErrType.AccessDenied);
        }
        
        
    }
  
}