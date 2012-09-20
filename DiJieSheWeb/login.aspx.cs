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
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
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
        
    }
  
}