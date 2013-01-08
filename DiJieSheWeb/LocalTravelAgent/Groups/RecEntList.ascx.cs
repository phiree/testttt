using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

public partial class LocalTravelAgent_Groups_RecEntList : System.Web.UI.UserControl
{
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    BLLDJ_GovManageDepartment bllGov = new BLLDJ_GovManageDepartment();
    public int Index = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindRecEnt();
        }
    }

    private void bindRecEnt()
    {
        rptRecList.DataSource = GetList();
        rptRecList.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bindRecEnt();
    }

    private List<DJ_TourEnterprise> GetList()
    {
        Guid dptid;
        Guid.TryParse(Request.QueryString["dptid"], out dptid);
        DJ_GovManageDepartment Gov = bllGov.GetById(dptid);
        List<DJ_TourEnterprise> ListEnt = new List<DJ_TourEnterprise>();
        if (ddlArea.SelectedValue == "全部")
            ListEnt = bllEnt.GetRewardEntList(string.Empty,Gov, null, RewardType.已纳入).ToList();
        if (ddlArea.SelectedValue == "景区")
            ListEnt = bllEnt.GetRewardEntList(string.Empty,Gov, EnterpriseType.景点, RewardType.已纳入).ToList();
        if (ddlArea.SelectedValue == "宾馆")
            ListEnt = bllEnt.GetRewardEntList(string.Empty,Gov, EnterpriseType.宾馆, RewardType.已纳入).ToList();
        return ListEnt;
    }
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        var collection = GetList();
        if (collection.Count < 1)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('没有数据，无法使用导出功能！')", true);return;return;
        }
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("col1");
        dt.Columns.Add(dc);
        dc = new DataColumn("col2");
        dt.Columns.Add(dc);
        foreach (var item in collection)
        {
            DataRow dr = dt.NewRow();
            dr[0] = item.Type;
            dr[1] = item.Name;
            dt.Rows.Add(dr);
        }
        new ExcelOplib.ExcelOutput().Download2Excel(dt, this.Page, new List<string>() { "类型", "名称" }, "详细奖励名单"+"[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" );
    }
}