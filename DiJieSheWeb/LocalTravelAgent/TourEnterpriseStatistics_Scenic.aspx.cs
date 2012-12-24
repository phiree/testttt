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
using System.Data;

public partial class LocalTravelAgent_TourEnterpriseStatistics_Scenic : System.Web.UI.Page
{
    int Index = 1;
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLDJEnterprise bllenterprise = new BLLDJEnterprise();
    List<Model.DJ_TourEnterprise> listEnt = new List<DJ_TourEnterprise>();
    int people_month_total;
    int people_year_total;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        total_report.Visible = true;
        detail_report.Visible = false;
        if (!Regex.Match(txtDate.Text.Trim(), "^[0-9]{4}年[0-9]{2}月$").Success)
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
        bool? IsVerified_City = null, IsVerified_Country = null;
        switch (int.Parse(ddlIsReward.SelectedValue))
        {
            case 0: IsVerified_City = null; IsVerified_Country = null; break;
            case 1: IsVerified_City = true; IsVerified_Country = null; break;
            case 2: IsVerified_City = false; IsVerified_Country = null; break;
            case 3: IsVerified_City = null; IsVerified_Country = true; break;
            case 4: IsVerified_City = null; IsVerified_Country = false; break;
            default:
                break;
        }
        listEnt = bllrecord.GetDJStaticsEnt(begintime, endtime, txtEntName.Text.Trim(), 1, Master.CurrentDJS.Id, IsVerified_City,IsVerified_Country).ToList();
        if (listEnt.Count == 1 && txtEntName.Text != "")
        {
            hfentId.Value = listEnt[0].Id.ToString();
            ShowEntDetailStatis(listEnt[0], endtime);
            return;
        }
        rptStatistic.DataSource = bindEntStatis(listEnt);
        rptStatistic.DataBind();
    }
    protected void rptStatistic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laPeople_Month_Total = e.Item.FindControl("laPeople_Month_Total") as Literal;
            Literal laPeople_Year_Total = e.Item.FindControl("laPeople_Year_Total") as Literal;
            laPeople_Month_Total.Text = people_month_total.ToString();
            laPeople_Year_Total.Text = people_year_total.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void btnOutput3_Click(object sender, EventArgs e)
    {
        if (!Regex.Match(txtDate.Text.Trim(), "^[0-9]{4}年[0-9]{2}月$").Success)
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
        bool? IsVerified_City = null, IsVerified_Country = null;
        switch (int.Parse(ddlIsReward.SelectedValue))
        {
            case 0: IsVerified_City = null; IsVerified_Country = null; break;
            case 1: IsVerified_City = true; IsVerified_Country = null; break;
            case 2: IsVerified_City = false; IsVerified_Country = null; break;
            case 3: IsVerified_City = null; IsVerified_Country = true; break;
            case 4: IsVerified_City = null; IsVerified_Country = false; break;
            default:
                break;
        }
        if (total_report.Visible)
        {
            listEnt = bllrecord.GetDJStaticsEnt(begintime, endtime, txtEntName.Text.Trim(), 1, Master.CurrentDJS.Id, IsVerified_City,IsVerified_Country).ToList();
            var result = bindEntStatis(listEnt);
            if (result.Count < 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('没有数据，无法使用导出功能！')", true);return;return;
            }
            //创建datatable
            DataTable tblDatas = new DataTable("Datas");
            tblDatas.Columns.Add("id", Type.GetType("System.String"));
            tblDatas.Columns.Add("qname", Type.GetType("System.String"));
            tblDatas.Columns.Add("mtotal", Type.GetType("System.String"));
            tblDatas.Columns.Add("ytotal", Type.GetType("System.String"));
            int i = 1;
            int t_month_total = 0;
            int t_year_total = 0;
            foreach (var item in result)
            {
                tblDatas.Rows.Add(new object[] { i++, item.Name, item.month_people,item.year_people});
                t_month_total += item.month_people;
                t_year_total += item.year_people;
            }
            tblDatas.Rows.Add(new object[] { "总计", "", t_month_total, 
                t_year_total });
            new ExcelOplib.ExcelOutput().Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","单位名称","本月景区游览人次","本年景区游览人次"
        }, Master.CurrentDJS.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "统计信息");
        }
        if (detail_report.Visible)
        {
            DJ_TourEnterprise ent = bllenterprise.GetDJS8id(hfentId.Value)[0];
            List<EntDetailStatis_Scenic> ListDetail = BindEntDetailStatis(ent, endtime);
            if (ListDetail.Count < 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('没有数据，无法使用导出功能！')", true);return;
            }
            List<string> titlelist = new List<string>() { "日期", "成人(景区游览人次)", "儿童(景区游览人次)"};
            DataTable dt = new DataTable();
            for (int i = 0; i < titlelist.Count; i++)
            {
                dt.Columns.Add(new DataColumn());
            }
            foreach (EntDetailStatis_Scenic statis in ListDetail)
            {
                DataRow dr = dt.NewRow();
                dr[0] = statis.Date;
                dr[1] = statis.Adult_Count;
                dr[2] = statis.Child_Count;
                dt.Rows.Add(dr);
            }
            new ExcelOplib.ExcelOutput().Download2Excel(dt, this.Page, titlelist, Master.CurrentDJS.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + ent.Name + "统计数据");
        }
    }

    private List<EntStatis_Scenic> bindEntStatis(List<DJ_TourEnterprise> listEnt)
    {
        List<EntStatis_Scenic> ListEntStatis = new List<EntStatis_Scenic>();
        foreach (DJ_TourEnterprise ent in listEnt)
        {
            EntStatis_Scenic entstatis = new EntStatis_Scenic();
            entstatis.Id = Index++;
            entstatis.Type = "景区";
            entstatis.Name = ent.Name;
            if (!Regex.Match(txtDate.Text.Trim(), "^[0-9]{4}年[0-9]{2}月$").Success)
            {
                txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
            }
            string begintime_month = DateTime.Parse(txtDate.Text.Trim()).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).Month + "-01";
            string endtime_month = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
            string begintime_year = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
            string endtime_year = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
            int People_month, Room_month, Bed_month;
            int People_year, Room_year, Bed_year;
            bllrecord.GetCountByStatics(begintime_month, endtime_month, txtEntName.Text.Trim(), 1, Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out People_month, out Room_month, out Bed_month);
            entstatis.month_people = People_month;
            people_month_total += People_month;
            bllrecord.GetCountByStatics(begintime_year, endtime_year, txtEntName.Text.Trim(), 1, Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out People_year, out Room_year, out Bed_year);
            entstatis.year_people = People_year;
            people_year_total += People_year;
            entstatis.entid = ent.Id;
            ListEntStatis.Add(entstatis);
        }
        return ListEntStatis;
    }

    private void ShowEntDetailStatis(DJ_TourEnterprise ent, string datetime)
    {
        detail_report.Visible = true;
        total_report.Visible = false;
        entName.InnerHtml = ent.Name + "统计列表";
        rptETDetail.DataSource = BindEntDetailStatis(ent, datetime);
        rptETDetail.DataBind();
    }

    public List<EntDetailStatis_Scenic> BindEntDetailStatis(DJ_TourEnterprise ent, string datetime)
    {
        List<EntDetailStatis_Scenic> ListEntDetailStatis = new List<EntDetailStatis_Scenic>();
        DateTime dt = DateTime.Parse(datetime).AddDays(-1);
        int allchild_total2 = 0, alladult_total2 = 0;
        bool? IsVerified_City = null, IsVerified_Country = null;
        switch (int.Parse(ddlIsReward.SelectedValue))
        {
            case 0: IsVerified_City = null; IsVerified_Country = null; break;
            case 1: IsVerified_City = true; IsVerified_Country = null; break;
            case 2: IsVerified_City = false; IsVerified_Country = null; break;
            case 3: IsVerified_City = null; IsVerified_Country = true; break;
            case 4: IsVerified_City = null; IsVerified_Country = false; break;
            default:
                break;
        }
        for (int i = 1; i <= dt.Month; i++)
        {
            List<DJ_GroupConsumRecord> ListRecord = bllrecord.GetByDate(dt.Year, i, ent.Id, Master.CurrentDJS.Id, IsVerified_City, IsVerified_Country);
            int allchild_total = 0, alladult_total = 0;
            foreach (DJ_GroupConsumRecord record in ListRecord)
            {
                EntDetailStatis_Scenic entDetail = new EntDetailStatis_Scenic();
                entDetail.Date = record.ConsumeTime.ToString("yyyy-MM-dd");
                entDetail.Adult_Count = record.AdultsAmount.ToString();
                entDetail.Child_Count = record.ChildrenAmount.ToString();
                allchild_total += record.ChildrenAmount;
                alladult_total += record.AdultsAmount;
                ListEntDetailStatis.Add(entDetail);
            }
            allchild_total2 += allchild_total;
            alladult_total2 += alladult_total;
            EntDetailStatis_Scenic entDetail_total = new EntDetailStatis_Scenic();
            entDetail_total.Date = i + "月总计";
            entDetail_total.Adult_Count = alladult_total.ToString();
            entDetail_total.Child_Count = allchild_total.ToString();
            ListEntDetailStatis.Add(entDetail_total);
        }
        EntDetailStatis_Scenic entDetail_total2 = new EntDetailStatis_Scenic();
        entDetail_total2.Date = "总计";
        entDetail_total2.Adult_Count = alladult_total2.ToString();
        entDetail_total2.Child_Count = allchild_total2.ToString();
        ListEntDetailStatis.Add(entDetail_total2);
        return ListEntDetailStatis;
    }


    protected void btnShowSearch_Click(object sender, EventArgs e)
    {
        if (!Regex.Match(txtDate.Text.Trim(), "^[0-9]{4}年[0-9]{2}月$").Success)
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
        DJ_TourEnterprise ent = bllenterprise.GetDJS8id(hfentId.Value)[0];
        ShowEntDetailStatis(ent, endtime);
    }

    protected void ddlIsReward_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
}


public class EntStatis_Scenic
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public int month_people { get; set; }
    public int year_people { get; set; }
    public int entid { get; set; }
}

public class EntDetailStatis_Scenic
{
    public string Date { get; set; }
    public string Adult_Count { get; set; }
    public string Child_Count { get; set; }
}