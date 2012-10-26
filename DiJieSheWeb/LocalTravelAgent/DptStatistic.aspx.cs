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
        rptDpt.DataSource = bllrecord.GetDptRecord(begintime, endtime, txtEntName.Text, Master.CurrentDJS.Id);
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
            DJ_GovManageDepartment GovManager = e.Item.DataItem as DJ_GovManageDepartment;
            Literal laTotal_Month = e.Item.FindControl("laTotal_Month") as Literal;
            Literal laLive_Month = e.Item.FindControl("laLive_Month") as Literal;
            Literal laVisited_Month = e.Item.FindControl("laVisited_Month") as Literal;
            Literal laTotal_Year = e.Item.FindControl("laTotal_Year") as Literal;
            Literal laLive_Year = e.Item.FindControl("laLive_Year") as Literal;
            Literal laVisited_Year = e.Item.FindControl("laVisited_Year") as Literal;
            HtmlAnchor anamehref = e.Item.FindControl("anamehref") as HtmlAnchor;
            anamehref.HRef = "/LocalTravelAgent/DptDetailStatistic.aspx?dptid=" + GovManager.Id + "&year=" + DateTime.Parse(txtDate.Text.Trim()).Year;
            string begintime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
            string endtime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
            string begintime_month = DateTime.Parse(txtDate.Text.Trim()).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).Month + "-01";
            string endtime_month = DateTime.Parse(DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01").AddDays(-1).ToString("yyyy-MM-dd");
            int totalcount_month, livevount_month, visitedcount_month;
            int totalcount_year, livevount_year, visitedcount_year;
            bllrecord.GetDetailDptCount(begintime_month, endtime_month, GovManager.Area.Code, Master.CurrentDJS.Id, out totalcount_month, out livevount_month, out visitedcount_month);
            laTotal_Month.Text = totalcount_month.ToString();
            laLive_Month.Text = livevount_month.ToString();
            laVisited_Month.Text = visitedcount_month.ToString();
            bllrecord.GetDetailDptCount(begintime_year, endtime_year, GovManager.Area.Code, Master.CurrentDJS.Id, out totalcount_year, out livevount_year, out visitedcount_year);
            laTotal_Year.Text = totalcount_year.ToString();
            laLive_Year.Text = livevount_year.ToString();
            laVisited_Year.Text = visitedcount_year.ToString();
        }
    }
}