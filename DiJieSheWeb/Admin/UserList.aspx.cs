using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 用户管理(不仅仅是地接社用户)
/// </summary>
public partial class Admin_UserList : System.Web.UI.Page
{
    BLLMembership membership=new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }
 
    private void Bind()
    {
        rptUsers.DataSource = GetUsers();
        rptUsers.DataBind();
    }  
    private IList<TourMembership> GetUsers()
    {
        IList<TourMembership> users = membership.GetAllUsers();

        return users;
    }
}