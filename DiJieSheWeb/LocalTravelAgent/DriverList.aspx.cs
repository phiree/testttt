﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_DriverList : basepageDJS
{
    BLL.BLLDJGroup_Worker bllgroupworker = new BLL.BLLDJGroup_Worker();
    BLL.BLLWorker bllworker = new BLL.BLLWorker();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbxBelong.Text = CurrentDJS.Name;
            BindList();
        }
    }

    private void BindList()
    {
        var driver_source = bllworker.GetWorkers8Multi(null, null, null, null, null, Model.DJ_GroupWorkerType.司机, CurrentDJS.Id.ToString());
        rptDrivers.DataSource = driver_source;
        rptDrivers.DataBind();
    }

    //清除输入痕迹
    protected void ClearTxt()
    {
        txtName_add.Text = string.Empty;
        txtPhone_add.Text = string.Empty;
        txtId_add.Text = string.Empty;
        txtDriverid_add.Text = string.Empty;
        tbxBelong.Text = string.Empty;
    }

    //检查完整性
    protected bool CheckComplete()
    {
        if (string.IsNullOrEmpty(txtName_add.Text))
        {
            ShowNotification("姓名未填写");
            return false;
        }
        if (string.IsNullOrEmpty(txtId_add.Text))
        {
            ShowNotification("身份证号码未填写!");
            return false;
        }
        if (hfIdcardError.Value != "验证通过")
        {
            ShowNotification(hfIdcardError.Value);
            return false;
        }
        if (string.IsNullOrEmpty(txtDriverid_add.Text))
        {
            ShowNotification("驾驶证号未填写!");
            return false;
        }
        return true;
    }

    //查找
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }

    //快速添加
    protected void btnQuickadd_Click(object sender, EventArgs e)
    {
        if (!CheckComplete()) return;
        string message = string.Empty;
        bllgroupworker.SaveData(txtName_add.Text, txtPhone_add.Text, txtId_add.Text,
            txtDriverid_add.Text,tbxBelong.Text, Model.DJ_GroupWorkerType.司机, CurrentDJS,out message);
        if (!string.IsNullOrEmpty(message))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + message + "')", true);
        }
        else
        {
            BindList();
            ClearTxt();
            ShowNotification("保存成功");
        }
    }

    

}