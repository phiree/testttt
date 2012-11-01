using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

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
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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


    #region 排序方法
    private List<dptStatistic> OrderByList(List<dptStatistic> ListRecord)
    {
        string[] orderbyStrs = Request.Cookies["orderstr"].Value.Split('_');
        int orderIndex = int.Parse(orderbyStrs[0]);
        string orderType = orderbyStrs[1];
        switch (orderIndex)
        {
            case 0:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.dptName).ToList() : ListRecord.OrderByDescending(x => x.dptName).ToList();
                    break;
                }
            case 1:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.month_total).ToList() : ListRecord.OrderByDescending(x => x.month_total).ToList();
                    break;
                }
            case 2:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.month_live).ToList() : ListRecord.OrderByDescending(x => x.month_live).ToList();
                    break;
                }
            case 3:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.month_visited).ToList() : ListRecord.OrderByDescending(x => x.month_visited).ToList();
                    break;
                }
            case 4:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.year_total).ToList() : ListRecord.OrderByDescending(x => x.year_total).ToList();
                    break;
                }
            case 5:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.year_live).ToList() : ListRecord.OrderByDescending(x => x.year_live).ToList();
                    break;
                }
            case 6:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.year_visited).ToList() : ListRecord.OrderByDescending(x => x.year_visited).ToList();
                    break;
                }
            default:
                break;
        }
        return ListRecord;

    }
    #endregion

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