using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Model;
/// <summary>
/// 各级旅游管理企业的数据导入 和 用户指派
/// </summary>
public partial class Admin_ManageDptList : System.Web.UI.Page
{
    BLLDJMgrDpt bllDpt = new BLLDJMgrDpt();
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }
    private void BindList()
    {
        IList<DJ_GovManageDepartment> dptList = bllDpt.GetMgrDptList(tbxAreaCode.Text.Trim());
        gv.DataSource = dptList;
        gv.DataBind();
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        BindList();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DJ_GovManageDepartment mgrDpt = e.Row.DataItem as DJ_GovManageDepartment;
            TourMembership member = bllMember.GetMgrDptAdmin(mgrDpt.Id,7);
            Label lblAdmin = e.Row.FindControl("lblAdmin") as Label;
            Button btnSetAdmin = e.Row.FindControl("btnSetAdmin") as Button;
            if (member != null)
            {
                lblAdmin.Text = member.Name;
                btnSetAdmin.Visible = false;
            }
        }
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Guid govId = Guid.Parse(e.CommandArgument.ToString());
        switch (e.CommandName.ToLower())
        {
            case "setadmin":
                DJ_GovManageDepartment mgrDpt = bllDpt.GetMgrDpt(govId);
                bllMember.CreateUpdateDptAdmin(mgrDpt);
                BindList();
                break;
            default: break;
        }
    }
}