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
        tbxAreaCode.Text = CurrentMgrDpt.Area.Code;
   
        tbxName.Text = CurrentMgrDpt.Name;
        tbxPhone.Text = CurrentMgrDpt.Phone;
      
    }
    private void UpdateForm()
    {
        CurrentMgrDpt.Address = tbxAdress.Text;
        CurrentMgrDpt.Area = bllArea.GetAreaByCode(tbxAreaCode.Text.Trim());
        CurrentMgrDpt.Name = tbxName.Text;
        CurrentMgrDpt.Phone = tbxPhone.Text;
    }

    public void Save()
    {
       

        UpdateForm();

        bllMgrDpt.Save(CurrentMgrDpt);
        if (IsNew)
        {
            Response.Redirect("ManageDptEdit.aspx?dptid=" + CurrentMgrDpt.Id);
        }
       


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }

}