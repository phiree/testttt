using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class LocalTravelAgent_TourEnterpriseStatistics : System.Web.UI.Page
{
    int Index = 1;
    int totalVisited = 0, totalLive = 0;
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    List<Model.DJ_TourEnterprise> listEnt = new List<DJ_TourEnterprise>();
    int count_month_total, live_month_total, visited_month_total;
    int count_year_total, live_year_total, visited_year_total;
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
        if(!DateTime.TryParse(txtDate.Text.Trim(),out selectTime))
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
        listEnt = bllrecord.GetDJStaticsEnt(begintime,endtime, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id).ToList();
        rptStatistic.DataSource = listEnt;
        rptStatistic.DataBind();
    }
    protected void rptStatistic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as Model.DJ_TourEnterprise;
            Literal laNo = e.Item.FindControl("laNo") as Literal;
            laNo.Text = Index++.ToString();
            Literal laType = e.Item.FindControl("laType") as Literal;
            Literal laCount_Month = e.Item.FindControl("laCount_Month") as Literal;
            Literal laLive_Month = e.Item.FindControl("laLive_Month") as Literal;
            Literal laVisited_Month = e.Item.FindControl("laVisited_Month") as Literal;
            Literal laCount_Year = e.Item.FindControl("laCount_Year") as Literal;
            Literal laLive_Year = e.Item.FindControl("laLive_Year") as Literal;
            Literal laVisited_Year = e.Item.FindControl("laVisited_Year") as Literal;
            

            laType.Text = (int)ent.Type == 1 ? "景区" : "宾馆";
            HtmlAnchor aname = e.Item.FindControl("aname") as HtmlAnchor;
            aname.HRef = "/LocalTravelAgent/TEDetailStatistics.aspx?year=" + DateTime.Parse(txtDate.Text.Trim()).Year + "&entid=" + ent.Id;
            string begintime_month = DateTime.Parse(txtDate.Text.Trim()).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).Month + "-01";
            string endtime_month = DateTime.Parse(DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01").AddDays(-1).ToString("yyyy-MM-dd");
            string begintime_year = DateTime.Parse(txtDate.Text.Trim()).Year+"-01-01";
            string endtime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
            int count_month, livecount_month, visitedcount_month;
            int count_year, livecount_year, visitedcount_year;
            bllrecord.GetCountByStatics(begintime_month, endtime_month, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out count_month, out livecount_month, out visitedcount_month);
            laCount_Month.Text = count_month.ToString();
            laLive_Month.Text = livecount_month.ToString();
            laVisited_Month.Text = visitedcount_month.ToString();
            count_month_total += count_month;
            live_month_total += livecount_month;
            visited_month_total += visitedcount_month;
            bllrecord.GetCountByStatics(begintime_year, endtime_year, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out count_year, out livecount_year, out visitedcount_year);
            laCount_Year.Text = count_year.ToString();
            laLive_Year.Text = livecount_year.ToString();
            laVisited_Year.Text = visitedcount_year.ToString();
            count_year_total += count_year;
            live_year_total += livecount_year;
            visited_year_total += visitedcount_year;
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laCount_Month_Total = e.Item.FindControl("laCount_Month_Total") as Literal;
            Literal laLive_Month_Total = e.Item.FindControl("laLive_Month_Total") as Literal;
            Literal laVisited_Month_Total = e.Item.FindControl("laVisited_Month_Total") as Literal;
            Literal laCount_Year_Total = e.Item.FindControl("laCount_Year_Total") as Literal;
            Literal laLive_Year_Total = e.Item.FindControl("laLive_Year_Total") as Literal;
            Literal laVisited_Year_Total = e.Item.FindControl("laVisited_Year_Total") as Literal;
            laCount_Month_Total.Text = count_month_total.ToString();
            laLive_Month_Total.Text = live_month_total.ToString();
            laVisited_Month_Total.Text = visited_month_total.ToString();
            laCount_Year_Total.Text = count_year_total.ToString();
            laLive_Year_Total.Text = live_year_total.ToString();
            laVisited_Year_Total.Text = visited_year_total.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }
}