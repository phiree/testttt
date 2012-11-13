using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
using System.Text.RegularExpressions;

public partial class LocalTravelAgent_TourEnterpriseStatistics : System.Web.UI.Page
{
    int Index = 1;
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
        if (!Regex.Match(txtDate.Text.Trim(), "^[0-9]{4}年[0-9]{2}月$").Success)
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
        listEnt = bllrecord.GetDJStaticsEnt(begintime, endtime, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id).ToList();
        rptStatistic.DataSource = bindEntStatis(listEnt);
        rptStatistic.DataBind();
    }
    protected void rptStatistic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            EntStatis ent = e.Item.DataItem as EntStatis;
            HtmlAnchor aname = e.Item.FindControl("aname") as HtmlAnchor;
            aname.HRef = "/LocalTravelAgent/TEDetailStatistics.aspx?year=" + DateTime.Parse(txtDate.Text.Trim()).Year + "&entid=" + ent.entid;
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


    private List<EntStatis> bindEntStatis(List<DJ_TourEnterprise> listEnt)
    {
        List<EntStatis> ListEntStatis = new List<EntStatis>();
        foreach (DJ_TourEnterprise ent in listEnt)
        {
            EntStatis entstatis = new EntStatis();
            entstatis.Id = Index++;
            entstatis.Type = (int)ent.Type == 1 ? "景区" : "宾馆";
            entstatis.Name = ent.Name;
            if (!Regex.Match(txtDate.Text.Trim(), "^[0-9]{4}年[0-9]{2}月$").Success)
            {
                txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
            }
            string begintime_month = DateTime.Parse(txtDate.Text.Trim()).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).Month + "-01";
            string endtime_month = DateTime.Parse(DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01").AddDays(-1).ToString("yyyy-MM-dd");
            string begintime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
            string endtime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
            int count_month, livecount_month, visitedcount_month;
            int count_year, livecount_year, visitedcount_year;
            bllrecord.GetCountByStatics(begintime_month, endtime_month, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out count_month, out livecount_month, out visitedcount_month);
            entstatis.month_total = count_month;
            entstatis.month_live = livecount_month;
            entstatis.month_visited = visitedcount_month;
            count_month_total += count_month;
            live_month_total += livecount_month;
            visited_month_total += visitedcount_month;
            bllrecord.GetCountByStatics(begintime_year, endtime_year, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out count_year, out livecount_year, out visitedcount_year);
            entstatis.year_total = count_year;
            entstatis.year_live = livecount_year;
            entstatis.year_visited = visitedcount_year;
            count_year_total += count_year;
            live_year_total += livecount_year;
            visited_year_total += visitedcount_year;
            entstatis.entid = ent.Id;
            ListEntStatis.Add(entstatis);
        }
        return ListEntStatis;
    }

    //private List<EntStatis> bindOrder(List<EntStatis> entstatis)
    //{
    //    string[] orderbyStrs = Request.Cookies["orderstr"].Value.Split('_');
    //    int orderIndex = int.Parse(orderbyStrs[0]);
    //    string orderType = orderbyStrs[1];
    //    switch (orderIndex)
    //    {
    //        case 0:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.Name).ToList() : entstatis.OrderByDescending(x => x.Name).ToList();
    //                break;
    //            }
    //        case 1:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.month_total).ToList() : entstatis.OrderByDescending(x => x.month_total).ToList();
    //                break;
    //            }
    //        case 2:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.month_live).ToList() : entstatis.OrderByDescending(x => x.month_live).ToList();
    //                break;
    //            }
    //        case 3:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.month_visited).ToList() : entstatis.OrderByDescending(x => x.month_visited).ToList();
    //                break;
    //            }
    //        case 4:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.year_total).ToList() : entstatis.OrderByDescending(x => x.year_total).ToList();
    //                break;
    //            }
    //        case 5:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.year_live).ToList() : entstatis.OrderByDescending(x => x.year_live).ToList();
    //                break;
    //            }
    //        case 6:
    //            {
    //                entstatis = orderType == "asc" ? entstatis.OrderBy(x => x.year_visited).ToList() : entstatis.OrderByDescending(x => x.year_visited).ToList();
    //                break;
    //            }
    //        default:
    //            break;
    //    }
    //    return entstatis;
    //}
}


public class EntStatis
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public int month_total { get; set; }
    public int month_live { get; set; }
    public int month_visited { get; set; }
    public int year_total { get; set; }
    public int year_live { get; set; }
    public int year_visited { get; set; }
    public int entid { get; set; }
}