using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 管理部门信息修改
/// </summary>
public partial class Admin_ManageDptEdit : basepage
{
    bool IsNew = false;
    DJ_GovManageDepartment CurrentMgrDpt;
    BLLArea bllArea = new BLLArea();
    BLLDJMgrDpt bllMgrDpt = new BLLDJMgrDpt();
    protected void Page_Load(object sender, EventArgs e)
    {
        string param = Request["dptId"];
        Guid dptId;
        if (!Guid.TryParse(param, out dptId))
        {
            IsNew = true;
            CurrentMgrDpt = new DJ_GovManageDepartment();
        }
        else
        {
            CurrentMgrDpt = bllMgrDpt.GetMgrDpt(dptId);
        }
        if (!IsPostBack)
        {
            if (!IsNew)
            {
                LoadForm();
            }
        }

    }

    private void LoadForm()
    {
        tbxAdress.Text = CurrentMgrDpt.Address;
        ddlarea.Areacode=CurrentMgrDpt.Area.Code;
        tbxName.Text = CurrentMgrDpt.Name;
        tbxPhone.Text = CurrentMgrDpt.Phone;
      
    }
    private void UpdateForm()
    {
        CurrentMgrDpt.Address = tbxAdress.Text;
        CurrentMgrDpt.Area = bllArea.GetAreaByCode(ddlarea.Areacode.Trim());
        CurrentMgrDpt.Name = tbxName.Text;
        CurrentMgrDpt.Phone = tbxPhone.Text;
        CurrentMgrDpt.seoname = tbxAdmin.Text;
        bllMember.CreateUpdateDptAdmin(CurrentMgrDpt);
    }

    private bool Validatedata(out string message)
    {
        message = string.Empty;
        if (string.IsNullOrEmpty(tbxName.Text))
        {
            message = "请填写名称!";
            return false;
        }
        //if (!string.IsNullOrEmpty(tbxPhone.Text))
        //{
        //    message = "请填写联系号码!";
        //    return false;
        //}
        //if (!string.IsNullOrEmpty(tbxAdress.Text))
        //{
        //    message = "请填写详细地址!";
        //    return false;
        //}
        return true;
    }
    public void Save()
    {
        UpdateForm();
        bllMgrDpt.Save(CurrentMgrDpt);
        if (IsNew)
        {
            Response.Redirect("ManageDptEdit.aspx?dptid=" + CurrentMgrDpt.Id);
            
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "suc", "alert('操作成功')", true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        bool result = Validatedata(out message);
        if (!result)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('"+message+"')",true);
            return;
        }
        Save();
    }
    BLLMembership bllMember = new BLLMembership();

  

}