using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class LocalTravelAgent_Groups_RecommentEnt : System.Web.UI.UserControl
{
    public string AreaCode { get; set; }
    public string redirtRecEntList { get; set; }
    BLLDJ_GovManageDepartment BllGov = new BLLDJ_GovManageDepartment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRecommendEnt();
        }
    }
    private void BindRecommendEnt()
    {
        List<Model.DJ_GovManageDepartment> ListGov = BllGov.GetGovDptByName("").ToList();
        if (ddlArea.SelectedValue == "市级")
        {
            ListGov = ListGov.Where(x => x.Area.Level == AreaLevel.市).ToList();
        }
        if (ddlArea.SelectedValue == "区县")
        {
            ListGov = ListGov.Where(x => x.Area.Level == AreaLevel.区县).ToList();
        }
        rptRecomEnt.DataSource = ListGov;
        rptRecomEnt.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BindRecommendEnt();
    }
    protected void rptRecomEnt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GovManageDepartment Gov = e.Item.DataItem as DJ_GovManageDepartment;
            HtmlAnchor redirtLink = e.Item.FindControl("redirtLink") as HtmlAnchor;
            redirtLink.HRef = redirtRecEntList + "?dptid=" + Gov.Id;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        var collection = BllGov.GetGovDptByName("");
        DataTable dt=new DataTable();
        DataColumn dc = new DataColumn("col1");
        dt.Columns.Add(dc);
        dc = new DataColumn("col2");
        dt.Columns.Add(dc);
        foreach (var item in collection)
        {
            DataRow dr=dt.NewRow();
            dr[0] = item.Name;
            dr[1] = "奖励政策";
            dt.Rows.Add(dr);
        }
        ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, new List<string>() { "名称", "奖励政策" });
    }
}