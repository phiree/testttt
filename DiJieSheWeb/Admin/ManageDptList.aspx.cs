using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
/// <summary>
/// 各级旅游管理企业的数据导入 和 用户指派
/// </summary>
public partial class Admin_ManageDptList : System.Web.UI.Page
{
    BLLDJMgrDpt bllDpt = new BLLDJMgrDpt();
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
}