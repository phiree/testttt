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
    BLLDJ_GovManageDepartment blldpt = new BLLDJ_GovManageDepartment();
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
        report_total.Visible = true;
        report_detail.Visible = false;
        DateTime selectTime;
        if (!DateTime.TryParse(txtDate.Text.Trim(), out selectTime))
        {
            txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        }
        string begintime, endtime;
        begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        endtime = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year +"-"+ DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
        List<DJ_GovManageDepartment> ListGov = bllrecord.GetDptRecord(begintime, endtime, txtEntName.Text, Master.CurrentDJS.Id);
        if (ListGov.Count == 1 && txtEntName.Text != "")
        {
            hfdetail.Value = ListGov[0].Id.ToString();
            btndetail_Click(null, null);
        }
        rptDpt.DataSource = bindDptStatistic(ListGov);
        rptDpt.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bind();
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
            string endtime_year = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year +"-"+ DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
            string begintime_month = DateTime.Parse(txtDate.Text.Trim()).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).Month + "-01";
            string endtime_month = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year+"-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
            int People_month, Room_month, AppendBed_month,Visited_month;
            int People_year, Room_year, AppendBed_year, Visited_year;
            bllrecord.GetDetailDptCount(begintime_month, endtime_month, Gov.Area.Code, Master.CurrentDJS.Id, out People_month, out Room_month, out AppendBed_month,out Visited_month);
            dpt.month_people = People_month;
            dpt.month_room = Room_month;
            dpt.month_appendbed = AppendBed_month;
            dpt.month_visited = Visited_month;
            bllrecord.GetDetailDptCount(begintime_year, endtime_year, Gov.Area.Code, Master.CurrentDJS.Id, out People_year, out Room_year, out AppendBed_year, out Visited_year);
            dpt.year_people = People_year;
            dpt.year_room = Room_year;
            dpt.year_appendbed = AppendBed_year;
            dpt.year_visited = Visited_year;
            dpt.DptId = Gov.Id;
            ListDpt.Add(dpt);
        }
        return ListDpt;
    }

    protected void btnOutput3_Click(object sender, EventArgs e)
    {
        if (report_total.Visible)
        {
            string begintime, endtime;
            begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
            endtime = DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Year + "-" + DateTime.Parse(txtDate.Text.Trim()).AddMonths(1).Month + "-01";
            List<DJ_GovManageDepartment> ListGov = bllrecord.GetDptRecord(begintime, endtime, txtEntName.Text, Master.CurrentDJS.Id);
            List<dptStatistic> ListDpt= bindDptStatistic(ListGov);

            List<string> titlelist = new List<string>() { "序号", "管理部门名称", "住宿人天数(本月)", "房间数(本月)", "加床数(本月)","景区浏览人次(本月)","住宿人天数(本年)","房间数(本年)","加床数(本年)","景区浏览人次(本年)" };
            DataTable dt = new DataTable();
            for (int i = 0; i < titlelist.Count; i++)
            {
                dt.Columns.Add(new DataColumn());
            }
            foreach (dptStatistic statis in ListDpt)
            {
                DataRow dr = dt.NewRow();
                dr[0] = statis.Id;
                dr[1] = statis.dptName;
                dr[2] = statis.month_people;
                dr[3] = statis.month_room;
                dr[4] = statis.month_appendbed;
                dr[5] = statis.month_visited;
                dr[6] = statis.year_people;
                dr[7] = statis.year_room;
                dr[8] = statis.year_appendbed;
                dr[9] = statis.year_visited;
                dt.Rows.Add(dr);
            }
            ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, titlelist, Master.CurrentDJS.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "管理部门统计数据");
        }
        if (report_detail.Visible)
        {
            DJ_GovManageDepartment dpt= blldpt.GetById(Guid.Parse(hfdetail.Value));
            List<dptDetail> ListdptDetail= BinddptDetail(dpt, txtDate.Text);
            List<string> titlelist = new List<string>() { "日期", "成人住宿天数", "儿童住宿天数", "房间数", "加床数", "成人景区浏览人次","儿童景区游览人次" };
            DataTable dt = new DataTable();
            for (int i = 0; i < titlelist.Count; i++)
            {
                dt.Columns.Add(new DataColumn());
            }
            foreach (var dptDetail in ListdptDetail)
            {
                DataRow dr = dt.NewRow();
                dr[0] = dptDetail.Date;
                dr[1] = dptDetail.People.Split('/')[0];
                dr[2] = dptDetail.People.Split('/')[1];
                dr[3] = dptDetail.Room;
                dr[4] = dptDetail.Appendbed;
                dr[5] = dptDetail.Visited.Split('/')[0];
                dr[6] = dptDetail.Visited.Split('/')[1];
                dt.Rows.Add(dr);
            }
            ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, titlelist, Master.CurrentDJS.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" +dpt.Name+ "统计数据");
        }
        //DateTime selectTime;
        //if (!DateTime.TryParse(txtDate.Text.Trim(), out selectTime))
        //{
        //    txtDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        //}
        //string begintime, endtime;
        //begintime = DateTime.Parse(txtDate.Text.Trim()).Year + "-01-01";
        //endtime = DateTime.Parse(txtDate.Text.Trim()).Year + "-12-30";
        //List<DJ_GovManageDepartment> ListGov = bllrecord.GetDptRecord(begintime, endtime, txtEntName.Text, Master.CurrentDJS.Id);
        //var result = bindDptStatistic(ListGov);
        ////创建datatable
        //DataTable tblDatas = new DataTable("Datas");
        //tblDatas.Columns.Add("id", Type.GetType("System.String"));
        //tblDatas.Columns.Add("name", Type.GetType("System.String"));
        //tblDatas.Columns.Add("mtotal", Type.GetType("System.String"));
        //tblDatas.Columns.Add("mhotel", Type.GetType("System.String"));
        //tblDatas.Columns.Add("mplay", Type.GetType("System.String"));
        //tblDatas.Columns.Add("ytotal", Type.GetType("System.String"));
        //tblDatas.Columns.Add("yhotel", Type.GetType("System.String"));
        //tblDatas.Columns.Add("yplay", Type.GetType("System.String"));
        //int i = 1;
        //foreach (var item in result)
        //{
        //    tblDatas.Rows.Add(new object[] { i++, item.dptName, item.month_total, 
        //        item.month_live,item.month_visited,item.year_total,item.year_live,item.year_visited });
        //}
        //ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
        //    "序号","旅游管理部门名称","本月总人数","本月住宿人天数","本月游玩人数","本年总人数","本年住宿人天数","本年游玩人数"
        //}, Master.CurrentDJS.Name+"["+DateTime.Today.ToString("yyyy-MM-dd") +"]"+ "统计信息");
    }

    private List<dptDetail> BinddptDetail(DJ_GovManageDepartment dpt, string datetime)
    {
        List<dptDetail> ListdptDetail = new List<dptDetail>();
        int adult_live_year = 0, child_live_year = 0, room_year = 0, appendbed_year = 0, adult_visited_year=0,child_visited_year = 0;
        for (int i=1 ; i <=12; i++)
        {
            List<DJ_GroupConsumRecord> record = bllrecord.GetByDate(DateTime.Parse(datetime).Year, i, dpt.Area.Code, Master.CurrentDJS.Id).ToList();
            int adult_live_month = 0, child_live_month = 0, room_month = 0, appendbed_month = 0, adult_visited_month = 0,child_visited_month=0;
            
            foreach (var r in record)
            {
                dptDetail detail = new dptDetail();
                detail.Date = r.ConsumeTime.ToString("yyyy-MM-dd");
                if (r.Enterprise.Type == EnterpriseType.宾馆)
                {
                    detail.People = (r.AdultsAmount * r.LiveDay) + "/" + (r.ChildrenAmount * r.LiveDay);
                    detail.Room = r.RoomNum;
                    detail.Appendbed = r.AppendBed;
                    adult_live_month += r.AdultsAmount * r.LiveDay;
                    child_live_month += r.ChildrenAmount * r.LiveDay;
                    room_month += r.RoomNum;
                    appendbed_month += r.AppendBed;
                    detail.Visited = "0/0";
                }
                if (r.Enterprise.Type == EnterpriseType.景点)
                {
                    detail.Visited = r.AdultsAmount + "/" + r.ChildrenAmount;
                    detail.People = "0/0";
                    adult_visited_month += r.AdultsAmount;
                    child_visited_month += r.ChildrenAmount;
                }
                ListdptDetail.Add(detail);
            }
            dptDetail detail2 = new dptDetail();
            detail2.Date = i + "月份总计";
            detail2.People = adult_live_month + "/" + child_live_month;
            detail2.Room = room_month;
            detail2.Appendbed = appendbed_month;
            detail2.Visited = adult_visited_month + "/" + child_visited_month;
            ListdptDetail.Add(detail2);
            adult_live_year += adult_live_month;
            child_live_year += child_live_month;
            room_year += room_month;
            appendbed_year += appendbed_month;
            adult_visited_year += adult_visited_month;
            child_visited_year += child_visited_month;
        }
        dptDetail detail3 = new dptDetail();
        detail3.Date = "总计";
        detail3.People = adult_live_year + "/" + child_live_year;
        detail3.Room = room_year;
        detail3.Appendbed = appendbed_year;
        detail3.Visited = adult_visited_year + "/" + child_visited_year;
        ListdptDetail.Add(detail3);
        return ListdptDetail;
    }

    protected void btndetail_Click(object sender, EventArgs e)
    {
        DJ_GovManageDepartment dpt= blldpt.GetById(Guid.Parse(hfdetail.Value));
        dptname.InnerHtml = dpt.Name + "统计列表";
        report_total.Visible = false;
        report_detail.Visible = true;
        rptETDetail.DataSource = BinddptDetail(dpt, txtDate.Text);
        rptETDetail.DataBind();
    }
}

public class dptStatistic
{
    public int Id { get; set; }
    public string dptName { get; set; }
    public int month_people { get; set; }
    public int month_room { get; set; }
    public int month_appendbed { get; set; }
    public int month_visited { get; set; }
    public int year_people { get; set; }
    public int year_room { get; set; }
    public int year_appendbed { get; set; }
    public int year_visited { get; set; }
    public Guid DptId { get; set; }
}

public class dptDetail
{
    public string Date { get; set; }
    public string People { get; set; }
    public int Room { get; set; }
    public int Appendbed { get; set; }
    public string Visited { get; set; }
}