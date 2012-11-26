using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
using System.Data;

public partial class LocalTravelAgent_DptStatistic : System.Web.UI.Page
{
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    public int Index = 1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Cookies.Add(new HttpCookie("orderstr", "0_desc"));
            bind();
        }
    }

    private void bind()
    {
        DateTime selectTime;
        if (!DateTime.TryParse(txtDate.Text.Trim(),out selectTime))
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
        List<DJ_GovManageDepartment> ListGov= bllrecord.GetDptRecord(begintime, endtime, txtEntName.Text, Master.CurrentDJS.Id);
        rptDpt.DataSource = bindDptStatistic(ListGov);
        rptDpt.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void rptDpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            dptStatistic GovManager = e.Item.DataItem as dptStatistic;
            HtmlAnchor anamehref = e.Item.FindControl("anamehref") as HtmlAnchor;
            anamehref.HRef = "/LocalTravelAgent/DptDetailStatistic.aspx?dptid=" + GovManager.DptId + "&year=" + DateTime.Parse(txtDate.Text.Trim()).Year;
        }
    }


    private List<dptStatistic> bindDptStatistic(List<DJ_GovManageDepartment> ListGov)
    {
        List<dptStatistic> ListDpt = new List<dptStatistic>();
        foreach (DJ_GovManageDepartment Gov in ListGov)
        {
            dptStatistic dpt = new dptStatistic();
            dpt.Id = Index++;
            dpt.dptName = Gov.Name;
            DateTime selectTime;
            if (!DateTime.TryParse(txtDate.Text.Trim(), out selectTime))
            {
                txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
            }
            string begintime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
            string endtime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
            string begintime_month = DateTime.Parse(txtDate.Text.Trim()).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).Month + "-01";
            string endtime_month = DateTime.Parse(DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01").AddDays(-1).ToString("yyyy-MM-dd");
            int totalcount_month, livevount_month, visitedcount_month;
            int totalcount_year, livevount_year, visitedcount_year;
            bllrecord.GetDetailDptCount(begintime_month, endtime_month, Gov.Area.Code, Master.CurrentDJS.Id, out totalcount_month, out livevount_month, out visitedcount_month);
            dpt.month_total = totalcount_month;
            dpt.month_live = livevount_month;
            dpt.month_visited = visitedcount_month;
            bllrecord.GetDetailDptCount(begintime_year, endtime_year, Gov.Area.Code, Master.CurrentDJS.Id, out totalcount_year, out livevount_year, out visitedcount_year);
            dpt.year_total = totalcount_year;
            dpt.year_live = livevount_year;
            dpt.year_visited = visitedcount_year;
            dpt.DptId = Gov.Id;
            ListDpt.Add(dpt);
        }
        return ListDpt;
    }

    protected void btnOutput3_Click(object sender, EventArgs e)
    {
        DateTime selectTime;
        if (!DateTime.TryParse(txtDate.Text.Trim(), out selectTime))
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
        List<DJ_GovManageDepartment> ListGov = bllrecord.GetDptRecord(begintime, endtime, txtEntName.Text, Master.CurrentDJS.Id);
        var result = bindDptStatistic(ListGov);
        //创建datatable
        DataTable tblDatas = new DataTable("Datas");
        tblDatas.Columns.Add("id", Type.GetType("System.String"));
        tblDatas.Columns.Add("name", Type.GetType("System.String"));
        tblDatas.Columns.Add("mtotal", Type.GetType("System.String"));
        tblDatas.Columns.Add("mhotel", Type.GetType("System.String"));
        tblDatas.Columns.Add("mplay", Type.GetType("System.String"));
        tblDatas.Columns.Add("ytotal", Type.GetType("System.String"));
        tblDatas.Columns.Add("yhotel", Type.GetType("System.String"));
        tblDatas.Columns.Add("yplay", Type.GetType("System.String"));
        int i = 1;
        foreach (var item in result)
        {
            tblDatas.Rows.Add(new object[] { i++, item.dptName, item.month_total, 
                item.month_live,item.month_visited,item.year_total,item.year_live,item.year_visited });
        }
        ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","旅游管理部门名称","本月总人数","本月住宿人天数","本月游玩人数","本年总人数","本年住宿人天数","本年游玩人数"
        }, Master.CurrentDJS.Name+"["+DateTime.Today.ToString("yyyy-MM-dd") +"]"+ "统计信息");
    }
}

public class dptStatistic
{
    public int Id { get; set; }
    public string dptName { get; set; }
    public int month_total { get; set; }
    public int month_live { get; set; }
    public int month_visited { get; set; }
    public int year_total { get; set; }
    public int year_live { get; set; }
    public int year_visited { get; set; }
    public Guid DptId { get; set; }
}