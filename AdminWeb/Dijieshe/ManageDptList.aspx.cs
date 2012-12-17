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
            ViewState["area"] = 1;
            BindList();
        }
    }
    private void BindList()
    {
        string area = ViewState["area"].ToString();
        if (area != "1")
        {
            IList<DJ_GovManageDepartment> dptList = bllDpt.GetMgrDptList(ddlarea.Areacode.Trim());
            gv.DataSource = dptList;
            gv.DataBind();
            if (gv.Rows.Count > 0)
            {
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            gv.Style.Add("border-collapse", "inherit !important");
            gv.Style.Add("border-spacing", "2px");
        }
        else
        {
            btn_All_Click(null, null);
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        ViewState["area"] = 1;
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
            Button btnResetPwd = e.Row.FindControl("resetPwd") as Button;
            if (member != null)
            {
                lblAdmin.Text = member.Name;
                btnSetAdmin.Visible = false;
            }
            else
            {
                btnResetPwd.Visible = false;
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('生成成功!')", true);
                break;
            case "resetpwd":
                mgrDpt = bllDpt.GetMgrDpt(govId);
                bllMember.CreateUpdateDptAdmin(mgrDpt);
                BindList();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('重置成功!')", true);
                break;
            default: break;
        }
    }
    protected void btn_All_Click(object sender, EventArgs e)
    {
        ViewState["area"] = 1;
        IList<DJ_GovManageDepartment> dptList = bllDpt.GetMgrDptList("");
        gv.DataSource = dptList;
        gv.DataBind();
        if (gv.Rows.Count > 0)
        {
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        gv.Style.Add("border-collapse", "inherit !important");
        gv.Style.Add("border-spacing", "2px");
    }
}