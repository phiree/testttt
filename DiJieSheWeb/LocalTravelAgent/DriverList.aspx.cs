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
        var driver_source = bllworker.Get8Multi(null, txtName.Text, null, txtIdcardid.Text, txtDrivercardid.Text, Model.DJ_GroupWorkerType.司机, null, CurrentDJS.Id.ToString());
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

    //protected void rptDrivers_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Header)
    //    {
    //        LinkButton lkbtnSort = (LinkButton)e.Item.FindControl(e.CommandName.Trim());
    //        if (ViewState[e.CommandName.Trim()] == null)
    //        {
    //            ViewState[e.CommandName.Trim()] = "ASC";
    //            lkbtnSort.Text = lkbtnSort.Text + "↑";
    //        }
    //        else
    //        {
    //            if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
    //            {
    //                ViewState[e.CommandName.Trim()] = "DESC";
    //                if (lkbtnSort.Text.IndexOf("↑") != -1)
    //                    lkbtnSort.Text = lkbtnSort.Text.Replace("↑", "↓");
    //                else
    //                    lkbtnSort.Text = lkbtnSort.Text + "↓";
    //            }
    //            else
    //            {
    //                ViewState[e.CommandName.Trim()] = "ASC";
    //                if (lkbtnSort.Text.IndexOf("↓") != -1)
    //                    lkbtnSort.Text = lkbtnSort.Text.Trim().Replace("↓", "↑");
    //                else
    //                    lkbtnSort.Text = lkbtnSort.Text + "↑";
    //            }
    //        }
    //        ViewState["text"] = lkbtnSort.Text;
    //        ViewState["id"] = e.CommandName.Trim();
    //        IList<Model.DJ_Group_Worker> workerlist = 
    //            bllworker.Get8Multi(null, txtName.Text, null, txtIdcardid.Text, txtDrivercardid.Text, Model.DJ_GroupWorkerType.司机, null, null);
    //        switch (e.CommandName.Trim())
    //        {
    //            case "lblname":
    //                if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
    //                    workerlist = workerlist.OrderBy(x => x.Name).ToList();
    //                else
    //                    workerlist = workerlist.OrderByDescending(x => x.Name).ToList();
    //                break;
    //            case "lblphone":
    //                if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
    //                    workerlist = workerlist.OrderBy(x => x.Phone).ToList();
    //                else
    //                    workerlist = workerlist.OrderByDescending(x => x.Phone).ToList();
    //                break;
    //            case "lblidcard":
    //                if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
    //                    workerlist = workerlist.OrderBy(x => x.IDCard).ToList();
    //                else
    //                    workerlist = workerlist.OrderByDescending(x => x.IDCard).ToList();
    //                break;
    //            case "lbldriver":
    //                if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
    //                    workerlist = workerlist.OrderBy(x => x.SpecificIdCard).ToList();
    //                else
    //                    workerlist = workerlist.OrderByDescending(x => x.SpecificIdCard).ToList();
    //                break;
    //        }
    //        rptDrivers.DataSource = workerlist;
    //        rptDrivers.DataBind();
    //    }
    //}

    //protected void rptDrivers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Header)
    //    {
    //        if (ViewState["id"] != null)
    //        {
    //            LinkButton lkbtnSort = (LinkButton)e.Item.FindControl(ViewState["id"].ToString().Trim());
    //            lkbtnSort.Text = ViewState["text"].ToString();
    //        }
    //    }
    //}
}