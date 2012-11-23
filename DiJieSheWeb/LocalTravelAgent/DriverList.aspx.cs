using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_DriverList : basepageDJS
{
    BLL.BLLDJGroup_Worker bllworker = new BLL.BLLDJGroup_Worker();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
    }

    //检查完整性
    protected bool CheckComplete()
    {
        if (string.IsNullOrEmpty(txtName_add.Text))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('姓名未填写!')", true);
            return false;
        }
        if (string.IsNullOrEmpty(txtId_add.Text))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('身份证号码未填写!')", true);
            return false;
        }
        if (string.IsNullOrEmpty(txtDriverid_add.Text))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('驾驶证号未填写!')", true);
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
        bllworker.SaveData(txtName_add.Text, txtPhone_add.Text, txtId_add.Text,
            txtDriverid_add.Text,CurrentDJS.Name, Model.DJ_GroupWorkerType.司机, CurrentDJS,out message);
        if (!string.IsNullOrEmpty(message))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + message + "')", true);
        }
        else
        {
            BindList();
            ClearTxt();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功')", true);
        }
    }

    

}