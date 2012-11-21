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
    BLLMembership membership = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }

    private void Bind()
    {
        var userlist_init = GetUsers();
        var userlist_result = new List<User8admin>();
        for (int i = 0; i < userlist_init.Count; i++)
        {
            var user8admin = new User8admin();
            user8admin.Name = userlist_init[i].Name;
            switch (userlist_init[i].GetType().ToString())
            {
                case "Model.DJ_User_Gov":
                    user8admin.Type = "管理部门管理员";
                    break;
                case "Model.DJ_User_TourEnterprise":
                    user8admin.Type = "旅游企业管理员";
                    break;
                default:
                    break;
            }
            userlist_result.Add(user8admin);
        }
        rptUsers.DataSource = userlist_result;
        rptUsers.DataBind();
    }
    private IList<TourMembership> GetUsers()
    {
        IList<TourMembership> users = membership.GetAllUsers();

        return users;
    }

    public class User8admin
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}