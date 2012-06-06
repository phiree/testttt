using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class Manager_RoleManage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoles();
        }
    }
    private void BindRoles()
    {
        string[] allRoles = Roles.GetAllRoles();
        rptRoles.DataSource = allRoles;
        rptRoles.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string roleName=tbxRoleName.Text.Trim();
        if (Roles.RoleExists(roleName))
        {
            tbxRoleName.Text = "角色名已经存在,不能重复添加";
            return;
        }
        Roles.CreateRole(tbxRoleName.Text.Trim());
        BindRoles();
   
    }
    protected void rptRoles_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "delete")
        {
            string roleName =(string) e.CommandArgument;
            Roles.DeleteRole(roleName);
            BindRoles();
        }
    }
}