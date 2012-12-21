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

public partial class LocalTravelAgent_TourEnterpriseStatistics_Hotel : System.Web.UI.Page
{
    int Index = 1;
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLDJEnterprise bllenterprise = new BLLDJEnterprise();
    List<Model.DJ_TourEnterprise> listEnt = new List<DJ_TourEnterprise>();
    int people_month_total, room_month_total, bed_month_total;
    int people_year_total, room_year_total, bed_year_total;
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
        bool? IsVerified = null;
        if (ddlIsReward.SelectedValue == "是")
        {
            IsVerified = true;
        }
        if (ddlIsReward.SelectedValue == "否")
        {
            IsVerified = false;
        }
        listEnt = bllrecord.GetDJStaticsEnt(begintime, endtime, txtEntName.Text.Trim(), 4, Master.CurrentDJS.Id, IsVerified).ToList();
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
            Literal laRoom_Month_Total = e.Item.FindControl("laRoom_Month_Total") as Literal;
            Literal laBed_Month_Total = e.Item.FindControl("laBed_Month_Total") as Literal;
            Literal laPeople_Year_Total = e.Item.FindControl("laPeople_Year_Total") as Literal;
            Literal laRoom_Year_Total = e.Item.FindControl("laRoom_Year_Total") as Literal;
            Literal laBed_Year_Total = e.Item.FindControl("laBed_Year_Total") as Literal;
            laPeople_Month_Total.Text = people_month_total.ToString();
            laRoom_Month_Total.Text = room_month_total.ToString();
            laBed_Month_Total.Text = bed_month_total.ToString();
            laPeople_Year_Total.Text = people_year_total.ToString();
            laRoom_Year_Total.Text = room_year_total.ToString();
            laBed_Year_Total.Text = bed_year_total.ToString();
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
        bool? IsVerified = null;
        if (ddlIsReward.SelectedValue == "是")
        {
            IsVerified = true;
        }
        if (ddlIsReward.SelectedValue == "否")
        {
            IsVerified = false;
        }
        if (total_report.Visible)
        {
            listEnt = bllrecord.GetDJStaticsEnt(begintime, endtime, txtEntName.Text.Trim(), 4, Master.CurrentDJS.Id, IsVerified).ToList();
            var result = bindEntStatis(listEnt);
            //创建datatable
            DataTable tblDatas = new DataTable("Datas");
            tblDatas.Columns.Add("id", Type.GetType("System.String"));
            tblDatas.Columns.Add("qname", Type.GetType("System.String"));
            tblDatas.Columns.Add("mtotal", Type.GetType("System.String"));
            tblDatas.Columns.Add("mhotel", Type.GetType("System.String"));
            tblDatas.Columns.Add("mplay", Type.GetType("System.String"));
            tblDatas.Columns.Add("ytotal", Type.GetType("System.String"));
            tblDatas.Columns.Add("yhotel", Type.GetType("System.String"));
            tblDatas.Columns.Add("yplay", Type.GetType("System.String"));
            int i = 1;
            int t_month_total = 0;
            int t_month_live = 0;
            int t_month_visited = 0;
            int t_year_total = 0;
            int t_year_live = 0;
            int t_year_visited = 0;
            foreach (var item in result)
            {
                tblDatas.Rows.Add(new object[] { i++, item.Name, item.month_people, 
                item.month_room,item.month_appendbed,item.year_people,item.year_room,item.year_appendbed });
                t_month_total += item.month_people;
                t_month_live += item.month_room;
                t_month_visited += item.month_appendbed;
                t_year_total += item.year_people;
                t_year_live += item.year_room;
                t_year_visited += item.year_appendbed;
            }
            tblDatas.Rows.Add(new object[] { "总计", "", t_month_total, 
                t_month_live,t_month_visited,t_year_total,t_year_live,t_year_visited });
            ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","单位名称","本月住宿人天数","本月房间数","本月加床数","本年住宿人天数","本年房间数","本年加床数"
        }, Master.CurrentDJS.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "统计信息");
        }
        if (detail_report.Visible)
        {
            DJ_TourEnterprise ent = bllenterprise.GetDJS8id(hfentId.Value)[0];
            List<EntDetailStatis> ListDetail= BindEntDetailStatis(ent, endtime);
            List<string> titlelist = new List<string>() { "日期", "成人(住宿人天数)", "儿童(住宿人天数)", "房间数", "加床数" };
            DataTable dt = new DataTable();
            for (int i = 0; i < titlelist.Count; i++)
            {
                dt.Columns.Add(new DataColumn());
            }
            foreach (EntDetailStatis statis in ListDetail)
            {
                DataRow dr = dt.NewRow();
                dr[0] = statis.Date;
                dr[1] = statis.AllPeople.Split('/')[0];
                dr[2] = statis.AllPeople.Split('/')[1];
                dr[3] = statis.Room;
                dr[4] = statis.AppendBed;
                dt.Rows.Add(dr);
            }
            ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, titlelist, Master.CurrentDJS.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" +ent.Name+ "统计数据");
        }
    }

    private List<EntStatis> bindEntStatis(List<DJ_TourEnterprise> listEnt)
    {
        List<EntStatis> ListEntStatis = new List<EntStatis>();
        foreach (DJ_TourEnterprise ent in listEnt)
        {
            EntStatis entstatis = new EntStatis();
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
            bllrecord.GetCountByStatics(begintime_month, endtime_month, txtEntName.Text.Trim(), 4, Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out People_month, out Room_month, out Bed_month);
            entstatis.month_people = People_month;
            entstatis.month_room = Room_month;
            entstatis.month_appendbed = Bed_month;
            people_month_total += People_month;
            room_month_total += Room_month;
            bed_month_total += Bed_month;
            bllrecord.GetCountByStatics(begintime_year, endtime_year, txtEntName.Text.Trim(), 4, Master.CurrentDJS.Id, (int)ent.Type, ent.Id, out People_year, out Room_year, out Bed_year);
            entstatis.year_people = People_year;
            entstatis.year_room = Room_year;
            entstatis.year_appendbed = Bed_year;
            people_year_total += People_year;
            room_year_total += Room_year;
            bed_year_total += Bed_year;
            entstatis.entid = ent.Id;
            ListEntStatis.Add(entstatis);
        }
        return ListEntStatis;
    }

    private void ShowEntDetailStatis(DJ_TourEnterprise ent, string datetime)
    {
        detail_report.Visible = true;
        total_report.Visible = false;
        entName.InnerHtml = ent.Name+"统计列表";
        rptETDetail.DataSource = BindEntDetailStatis(ent, datetime);
        rptETDetail.DataBind();
    }

    public List<EntDetailStatis> BindEntDetailStatis(DJ_TourEnterprise ent, string datetime)
    {
        List<EntDetailStatis> ListEntDetailStatis = new List<EntDetailStatis>();
        DateTime dt = DateTime.Parse(datetime).AddDays(-1);
        int allchild_total2 = 0, alladult_total2 = 0, room_total2 = 0, appendbed_total2 = 0;
        for (int i = 1; i <= dt.Month; i++)
        {
            List<DJ_GroupConsumRecord> ListRecord = bllrecord.GetByDate(dt.Year, i, ent.Id, Master.CurrentDJS.Id);
            int allchild_total = 0, alladult_total = 0, room_total = 0, appendbed_total = 0;
            foreach (DJ_GroupConsumRecord record in ListRecord)
            {
                EntDetailStatis entDetail = new EntDetailStatis();
                entDetail.Date = record.ConsumeTime.ToString("yyyy-MM-dd");
                entDetail.AllPeople = (record.AdultsAmount * record.LiveDay).ToString() + "/" + (record.ChildrenAmount * record.LiveDay).ToString();
                entDetail.Room = record.RoomNum;
                entDetail.AppendBed = record.AppendBed;
                allchild_total += (record.ChildrenAmount * record.LiveDay);
                alladult_total += record.AdultsAmount * record.LiveDay;
                room_total += record.RoomNum;
                appendbed_total += record.AppendBed;
                ListEntDetailStatis.Add(entDetail);
            }
            allchild_total2 += allchild_total;
            alladult_total2 += alladult_total;
            room_total2 += room_total;
            appendbed_total2 += appendbed_total;
            EntDetailStatis entDetail_total = new EntDetailStatis();
            entDetail_total.Date = i + "月总计";
            entDetail_total.AllPeople = alladult_total + "/" + allchild_total;
            entDetail_total.Room = room_total;
            entDetail_total.AppendBed = appendbed_total;
            ListEntDetailStatis.Add(entDetail_total);
        }
        EntDetailStatis entDetail_total2 = new EntDetailStatis();
        entDetail_total2.Date = "总计";
        entDetail_total2.AllPeople = alladult_total2 + "/" + allchild_total2;
        entDetail_total2.Room = room_total2;
        entDetail_total2.AppendBed = appendbed_total2;
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
}


public class EntStatis
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public int month_people { get; set; }
    public int month_room { get; set; }
    public int month_appendbed { get; set; }
    public int year_people { get; set; }
    public int year_room { get; set; }
    public int year_appendbed { get; set; }
    public int entid { get; set; }
}

public class EntDetailStatis
{
    public string Date { get; set; }
    public string AllPeople { get; set; }
    public int Room { get; set; }
    public int AppendBed { get; set; }
}