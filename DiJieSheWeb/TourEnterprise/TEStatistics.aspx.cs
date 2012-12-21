using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Linq.Expressions;
using System.IO;
using System.Data;

public partial class TourEnterprise_TEStatistics : basepage
{
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLDJRoute BLLDJRoute = new BLLDJRoute();
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    int Index = 1;
    List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitTime();
            BindLiveStatistic();
        }
    }

    private void InitTime()
    {
        DateTime dt;
        if (!DateTime.TryParse(txtTime.Text, out dt))
        {
            dt = DateTime.Now;
            txtTime.Text = DateTime.Now.ToString("yyyy年MM月");
        }
        else
        {
            if (dt > DateTime.Now)
            {
                dt = DateTime.Now;
                txtTime.Text = DateTime.Now.ToString("yyyy年MM月");
            }
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BindLiveStatistic();
    }

    private void BindLiveStatistic()
    {
        InitTime();
        report_total.Visible = true;
        report_detail.Visible = false;
        List<DJ_DijiesheInfo> ListRecord= bllrecord.SelectFromRecord("", txtEntName.Text.Trim(), "", txtTime.Text, Master.CurrentTE.Id);
        if (ListRecord.Count == 1&&txtEntName.Text!="")
        {
            ShowDetailReport(ListRecord[0].Id);
            return;
        }
        
        rptTgRecord.DataSource = BindLive();
        rptTgRecord.DataBind();
    }

    private List<LiveStatistic> BindLive()
    {
        List<DJ_DijiesheInfo> ListRecord = bllrecord.SelectFromRecord("", txtEntName.Text.Trim(), "", txtTime.Text, Master.CurrentTE.Id);
        List<LiveStatistic> ListLive = new List<LiveStatistic>();
        int Index = 1;
        foreach (var djs in ListRecord)
        {
            LiveStatistic LiveStatistic = new LiveStatistic();
            LiveStatistic.Index = Index++;
            LiveStatistic.EntName = djs.Name;
            LiveStatistic.djsId = djs.Id.ToString();
            foreach (var item in bllrecord.GetRecordByAllCondition("", djs.Name, DateTime.Parse(txtTime.Text).ToString(), DateTime.Parse(txtTime.Text).AddMonths(1).ToString(), Master.CurrentTE.Id))
            {
                LiveStatistic.RoomCount_Month += item.RoomNum;
                LiveStatistic.AppendBed_Month += item.AppendBed;
                LiveStatistic.LiveCount_Month += item.LiveDay;
            }
            foreach (var item in bllrecord.GetRecordByAllCondition("", djs.Name, (DateTime.Parse(txtTime.Text).Year.ToString()) + "-01-01", DateTime.Parse(txtTime.Text).AddMonths(1).ToString(), Master.CurrentTE.Id))
            {
                LiveStatistic.RoomCount_Year += item.RoomNum;
                LiveStatistic.AppendBed_Year += item.AppendBed;
                LiveStatistic.LiveCount_Year += item.LiveDay;
            }
            ListLive.Add(LiveStatistic);
        }
        return ListLive;
    }



    protected void BtnCreatexls_Click(object sender, EventArgs e)
    {
        if (report_total.Visible)
        {
            List<LiveStatistic> listLive = BindLive();
            if (listLive.Count < 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('没有数据，无法使用导出功能！')", true);return;
            }
            List<string> titlelist = new List<string>() { "序号", "旅行社名称", "", "入住天数(本月)", "房间数(本月)", "加床数(本月)", "入住天数(本年)","房间数(本年)","加床数(本年)" };
            DataTable dt = new DataTable();
            for (int i = 0; i < titlelist.Count; i++)
            {
                dt.Columns.Add(new DataColumn());
            }
            foreach (var item in listLive)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Index;
                dr[1] = item.EntName;
                dr[2] = item.LiveCount_Month;
                dr[3] = item.RoomCount_Month;
                dr[4] = item.AppendBed_Month;
                dr[5] = item.LiveCount_Year;
                dr[6] = item.RoomCount_Year;
                dr[7] = item.AppendBed_Year;
                dt.Rows.Add(dr);
            }
            new ExcelOplib.ExcelOutput().Download2Excel(dt, this.Page, titlelist, Master.CurrentTE.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "已入住统计列表");
        }
        if (report_detail.Visible)
        {
            DJ_TourEnterprise ent = bllEnt.GetDJS8id(hfdetail.Value)[0];
            List<DJ_GroupConsumRecord> listRecord = bllrecord.GetRecordByAllCondition("", ent.Name, (DateTime.Parse(txtTime.Text).Year.ToString()) + "-01-01", DateTime.Parse(txtTime.Text).AddMonths(1).ToString(), Master.CurrentTE.Id);
            if (listRecord.Count < 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('没有数据，无法使用导出功能！')", true);return;
            }
            List<string> titlelist = new List<string>() { "序号", "入住时间", "团队名称", "旅行社名称", "成人(人数)","儿童(人数)", "入住天数", "房间数", "加床数" };
            DataTable dt = new DataTable();
            for (int i = 0; i < titlelist.Count; i++)
            {
                dt.Columns.Add(new DataColumn());
            }
            int index=1;
            foreach (var item in listRecord)
            {
                DataRow dr = dt.NewRow();
                dr[0] = index++;
                dr[1] = item.ConsumeTime;
                dr[2] = item.Route.DJ_TourGroup.Name;
                dr[3] = item.Route.DJ_TourGroup.DJ_DijiesheInfo.Name;
                dr[4] = item.AdultsAmount;
                dr[5] = item.ChildrenAmount;
                dr[6] = item.LiveDay;
                dr[7] = item.RoomNum;
                dr[8] = item.AppendBed;
                dt.Rows.Add(dr);
            }
            new ExcelOplib.ExcelOutput().Download2Excel(dt, this.Page, titlelist, Master.CurrentTE.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "已入住统计详细列表");
        }
    }



    public void CreateExcels(List<DJ_GroupConsumRecord> WListRecord, List<DJ_GroupConsumRecord> YListRecord, string FileName)
    {
        if (YListRecord.Count < 1)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('没有数据，无法使用导出功能！')", true);return;
        }
        List<string> titlelist = new List<string>() { "序号", "住宿时间", "团队名称", "旅行社名称", "住宿天数", "人数", "验证状态" };
        DataTable dt = new DataTable();
        for (int i = 0; i < titlelist.Count; i++)
        {
            dt.Columns.Add(new DataColumn());
        }
        foreach (DJ_GroupConsumRecord record in WListRecord)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Index;
            dr[1] = record.ConsumeTime;
            dr[2] = record.Route.DJ_TourGroup.Name;
            dr[3] = record.Route.DJ_TourGroup.DJ_DijiesheInfo.Name;
            dr[4] = record.LiveDay;
            dr[5] = "成人" + record.AdultsAmount + "儿童" + record.ChildrenAmount;
            dr[6] = "未验证";
            dt.Rows.Add(dr);
            Index++;
        }
        foreach (DJ_GroupConsumRecord record in YListRecord)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Index;
            dr[1] = record.ConsumeTime;
            dr[2] = record.Route.DJ_TourGroup.Name;
            dr[3] = record.Route.DJ_TourGroup.DJ_DijiesheInfo.Name;
            dr[4] = record.LiveDay;
            dr[5] = "成人" + record.AdultsAmount + "儿童" + record.ChildrenAmount;
            dr[6] = "已验证";
            dt.Rows.Add(dr);
            Index++;
        }
        int groupcount, adultcount, childrencount;
        bllrecord.GetCountInfoByETid(Master.CurrentTE.Id, out groupcount, out adultcount, out childrencount, ListRecord);
        DataRow drend = dt.NewRow();
        drend[0] = "共接待团对数" + groupcount + "其中包括成人" + adultcount + "儿童" + childrencount;
        dt.Rows.Add(drend);
        new ExcelOplib.ExcelOutput().Download2Excel(dt, this.Page, titlelist, Master.CurrentTE.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "统计数据");
    }

    public void ShowDetailReport(object djsId)
    {
        InitTime();
        report_total.Visible = false;
        report_detail.Visible = true;
        DJ_TourEnterprise ent= bllEnt.GetDJS8id(djsId.ToString())[0];
        rptDetail.DataSource= bllrecord.GetRecordByAllCondition("", ent.Name, (DateTime.Parse(txtTime.Text).Year.ToString()) + "-01-01", DateTime.Parse(txtTime.Text).AddMonths(1).ToString(), Master.CurrentTE.Id);
        rptDetail.DataBind();
    }

    protected void btndetail_Click(object sender, EventArgs e)
    {
        ShowDetailReport(hfdetail.Value);
    }
}

public class LiveStatistic
{
    public int Index { get; set; }
    public string djsId { get; set; }
    public string EntName { get; set; }
    public int LiveCount_Month { get; set; }
    public int RoomCount_Month { get; set; }
    public int AppendBed_Month { get; set; }
    public int LiveCount_Year { get; set; }
    public int RoomCount_Year { get; set; }
    public int AppendBed_Year { get; set; }
}