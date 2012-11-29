using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using BLL;

public partial class LocalTravelAgent_TEDetailStatistics : System.Web.UI.Page
{
    string Year;
    int entid;
    int totalmonth_child = 0, totalmonth_audlt = 0, totalyear_child = 0, totalyear_adult = 0;
    BLLDJEnterprise blldjent = new BLLDJEnterprise();
    BLLDJConsumRecord bllRecord = new BLLDJConsumRecord();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        List<month> List = new List<month>();
        for (int i = 1; i < 13; i++)
        {
            month m = new month(i);
            List.Add(m);
        }
        rptETDetail.DataSource = List;
        rptETDetail.DataBind();
        Year = Request.QueryString["year"];
        entid = int.Parse(Request.QueryString["entid"]);
        ETName.InnerHtml = blldjent.GetDJS8id(entid.ToString())[0].Name;
    }
    protected void rptETDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Year = Request.QueryString["year"];
        entid = int.Parse(Request.QueryString["entid"]);
        Literal laMonthTotal = e.Item.FindControl("laMonthTotal") as Literal;
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            totalmonth_child = 0;
            totalmonth_audlt = 0;
            month m = e.Item.DataItem as month;
            Repeater rptETMonthDetail = e.Item.FindControl("rptETMonthDetail") as Repeater;
            rptETMonthDetail.ItemDataBound += new RepeaterItemEventHandler(rptETMonthDetail_ItemDataBound);
            rptETMonthDetail.DataSource = bllRecord.GetByDate(int.Parse(Year), m.MonthIndex, entid, Master.CurrentDJS.Id);
            rptETMonthDetail.DataBind();
            laMonthTotal.Text = "成人" + totalmonth_audlt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalmonth_child.ToString();
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laYearTotal = e.Item.FindControl("laYearTotal") as Literal;
            laYearTotal.Text = "成人" + totalyear_adult + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalyear_child;
        }
    }

    protected void rptETMonthDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GroupConsumRecord record = e.Item.DataItem as DJ_GroupConsumRecord;
            Literal laCountInfo = e.Item.FindControl("laCountInfo") as Literal;
            if (blldjent.GetDJS8id(entid.ToString())[0].Type == EnterpriseType.景点)
            {
                totalmonth_audlt += record.AdultsAmount;
                totalmonth_child += record.ChildrenAmount;
                totalyear_child += record.ChildrenAmount;
                totalyear_adult += record.AdultsAmount;
                laCountInfo.Text = "成人" + record.AdultsAmount.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + record.ChildrenAmount.ToString();
            }
            if (blldjent.GetDJS8id(entid.ToString())[0].Type == EnterpriseType.宾馆)
            {
                totalmonth_audlt += record.AdultsAmount * record.LiveDay;
                totalmonth_child += record.ChildrenAmount * record.LiveDay;
                totalyear_adult += record.AdultsAmount * record.LiveDay;
                totalyear_child += record.ChildrenAmount * record.LiveDay;
                laCountInfo.Text = "成人" + (record.AdultsAmount * record.LiveDay).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + (record.ChildrenAmount * record.LiveDay).ToString();
            }
            Literal laMonthTotal = e.Item.Parent.Parent.FindControl("laMonthTotal") as Literal;
            laMonthTotal.Text = "成人" + totalmonth_audlt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalmonth_child.ToString();
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        List<ExcelTable> listExcel = new List<ExcelTable>();
        totalmonth_child = 0; totalmonth_audlt = 0; totalyear_child = 0; totalyear_adult = 0;
        Year = Request.QueryString["year"];
        entid = int.Parse(Request.QueryString["entid"]);
        for (int i = 1; i < 13; i++)
        {
            List<DJ_GroupConsumRecord> listRecord = bllRecord.GetByDate(int.Parse(Year), i, int.Parse(Request.QueryString["entid"]), Master.CurrentDJS.Id);
            foreach (DJ_GroupConsumRecord record in listRecord)
            {
                ExcelTable et = new ExcelTable();
                et.date = record.ConsumeTime.ToString("yyyy-MM-dd");
                if (blldjent.GetDJS8id(entid.ToString())[0].Type == EnterpriseType.景点)
                {
                    totalmonth_audlt += record.AdultsAmount;
                    totalmonth_child += record.ChildrenAmount;
                    totalyear_child += record.ChildrenAmount;
                    totalyear_adult += record.AdultsAmount;
                    et.detail = "成人" + record.AdultsAmount.ToString() + "儿童" + record.ChildrenAmount.ToString();
                    listExcel.Add(et);
                }
                if (blldjent.GetDJS8id(entid.ToString())[0].Type == EnterpriseType.宾馆)
                {
                    totalmonth_audlt += record.AdultsAmount * record.LiveDay;
                    totalmonth_child += record.ChildrenAmount * record.LiveDay;
                    totalyear_adult += record.AdultsAmount * record.LiveDay;
                    totalyear_child += record.ChildrenAmount * record.LiveDay;
                    et.detail = "成人" + (record.AdultsAmount * record.LiveDay).ToString() + "儿童" + (record.ChildrenAmount * record.LiveDay).ToString();
                    listExcel.Add(et);
                }
            }
            ExcelTable etotal = new ExcelTable();
            etotal.date = i + "月份小计";
            etotal.detail = "成人" + totalmonth_audlt.ToString() + "儿童" + totalmonth_child.ToString();
            listExcel.Add(etotal);
        }
        ExcelTable etyear = new ExcelTable();
        etyear.date = "总计";
        etyear.detail = "成人" + totalyear_adult.ToString() + "儿童" + totalyear_child.ToString();
        listExcel.Add(etyear);
        DataTable dt = new DataTable("ExcelData");
        dt.Columns.Add("date", Type.GetType("System.String"));
        dt.Columns.Add("detail", Type.GetType("System.String"));
        foreach (ExcelTable et in listExcel)
        {
            dt.Rows.Add(new object[] { et.date, et.detail });
        }
        ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, new List<string>() { "日期", "游玩人数或住宿人天数" },
            ETName.InnerHtml + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "详细统计报表");
    }
}



public class ExcelTable
{
    public string date { get; set; }
    public string detail { get; set; }
}
