using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class LocalTravelAgent_DptDetailStatistic : System.Web.UI.Page
{
    string Year;
    string dptid;
    int totalLmonth_child = 0, totalVmonth_child = 0, totalLmonth_audlt = 0, totalVmonth_audlt = 0, totalLyear_child = 0,totalVyear_child = 0,totalLyear_adult = 0, totalVyear_adult = 0;
    BLLDJ_GovManageDepartment bllgovdepart = new BLLDJ_GovManageDepartment();
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
        dptid = Request.QueryString["dptid"];
        ETName.InnerHtml = bllgovdepart.GetById(Guid.Parse(dptid)).Name;
    }
    protected void rptETDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Year = Request.QueryString["year"];
        dptid = Request.QueryString["dptid"];
        DJ_GovManageDepartment depart=bllgovdepart.GetById(Guid.Parse(dptid));
        Literal laMonthVTotal = e.Item.FindControl("laMonthVTotal") as Literal;
        Literal laMonthLTotal = e.Item.FindControl("laMonthLTotal") as Literal;
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            totalLmonth_audlt = 0;
            totalLmonth_child = 0;
            totalVmonth_audlt = 0;
            totalVmonth_child = 0;
            month m = e.Item.DataItem as month;
            Repeater rptETMonthDetail = e.Item.FindControl("rptETMonthDetail") as Repeater;
            rptETMonthDetail.ItemDataBound += new RepeaterItemEventHandler(rptETMonthDetail_ItemDataBound);
            rptETMonthDetail.DataSource = bllRecord.GetByDate(int.Parse(Year), m.MonthIndex, depart.Area.Code,Master.CurrentDJS.Id);
            rptETMonthDetail.DataBind();
            laMonthVTotal.Text = "成人" + totalVmonth_audlt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalVmonth_child.ToString();
            laMonthLTotal.Text = "成人" + totalLmonth_audlt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalLmonth_child.ToString();
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laYearVTotal = e.Item.FindControl("laYearVTotal") as Literal;
            Literal laYearLTotal = e.Item.FindControl("laYearLTotal") as Literal;
            laYearVTotal.Text = "成人" + totalVyear_adult.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalVyear_child.ToString();
            laYearLTotal.Text = "成人" + totalLyear_adult.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalLyear_child.ToString();
        }
    }

    protected void rptETMonthDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GroupConsumRecord record = e.Item.DataItem as DJ_GroupConsumRecord;
            Literal laVisitedCount = e.Item.FindControl("laVisitedCount") as Literal;
            Literal laLiveCount = e.Item.FindControl("laLiveCount") as Literal;
            if (record.LiveDay>0)
            {
                totalLmonth_audlt += record.AdultsAmount * record.LiveDay;
                totalLmonth_child += record.ChildrenAmount * record.LiveDay;
                totalLyear_child += record.ChildrenAmount * record.LiveDay;
                totalLyear_adult += record.AdultsAmount * record.LiveDay;
                laLiveCount.Text = "成人" + (record.AdultsAmount * record.LiveDay).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + (record.ChildrenAmount * record.LiveDay).ToString();
                laVisitedCount.Text = "成人0" + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童0";
            }
            else
            {
                totalVmonth_audlt += record.AdultsAmount ;
                totalVmonth_child += record.ChildrenAmount ;
                totalVyear_adult += record.AdultsAmount ;
                totalVyear_child += record.ChildrenAmount ;
                laVisitedCount.Text = "成人" + record.AdultsAmount.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + record.ChildrenAmount.ToString();
                laLiveCount.Text = "成人0" + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童0";
            }
            Literal laMonthVTotal = e.Item.Parent.Parent.FindControl("laMonthVTotal") as Literal;
            Literal laMonthLTotal = e.Item.Parent.Parent.FindControl("laMonthLTotal") as Literal;
            laMonthVTotal.Text = "成人" + totalVmonth_audlt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalVmonth_child.ToString();
            laMonthLTotal.Text = "成人" + totalLmonth_audlt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;" + "儿童" + totalLmonth_child.ToString();
        }
    }
}

