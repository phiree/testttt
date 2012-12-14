using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.Security;
/// <summary>
/// 管理用户的帐号信息
/// </summary>
public partial class Manager_AccountDetail : System.Web.UI.Page
{
    public Model.TourMembership User;
    BLL.BLLMembership bllMember = new BLLMembership();
   public  Guid userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramUserId = Request["userid"];
       
        if (!Guid.TryParse(paramUserId, out userId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        User = bllMember.GetMemberById(userId);
        if (User == null)
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        if (!IsPostBack)
        {
            LoadRoles();
        }
    }

    private void LoadRoles()
    {
        cbxRoles.DataSource = System.Web.Security.Roles.GetAllRoles();
        cbxRoles.DataBind();

        foreach (string s in Roles.GetRolesForUser(User.Name))
        {
            foreach (ListItem item in cbxRoles.Items)
            {
                if (item.Text == s)
                {
                    item.Selected = true;
                    break;
                }
                
            }
        }
    }

    private void SaveRoles()
    {
      
        foreach (ListItem item in cbxRoles.Items)
        {

            if (item.Selected)
            {
                Roles.AddUserToRole(User.Name, item.Text);
            }
            else {
                Roles.RemoveUserFromRole(User.Name, item.Text);
            }


        }

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        SaveRoles();
        LoadRoles();
    }
}