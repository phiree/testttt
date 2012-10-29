using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        DateTime begintieme, endtime;
        if(!DateTime.TryParse(txtBeginDate.Text, out begintieme))
        {
            txtBeginDate.Text="";
        }
        if (!DateTime.TryParse(txtEndDate.Text, out endtime))
        {
            txtEndDate.Text = "";
        }
        if (ddlDateStatistic.SelectedValue == "本月")
        {
            txtBeginDate.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "01";
            txtEndDate.Text = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.AddMonths(1).Month + "01").AddDays(-1).ToString("yyyy-MM-dd");
        }
        rptDpt.DataSource = bllrecord.GetDptRecord(txtBeginDate.Text, txtEndDate.Text, txtEntName.Text, Master.CurrentDJS.Id);
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
            Literal laTotalCount = e.Item.FindControl("laTotalCount") as Literal;
            Literal laLiveCount = e.Item.FindControl("laLiveCount") as Literal;
            Literal laVisitedCount = e.Item.FindControl("laVisitedCount") as Literal;
            DateTime begintieme, endtime;
            if(!DateTime.TryParse(txtBeginDate.Text, out begintieme))
            {
                txtBeginDate.Text="";
            }
            if (!DateTime.TryParse(txtEndDate.Text, out endtime))
            {
                txtEndDate.Text = "";
            }
            int totalcount, livevount, visitedcount;
            bllrecord.GetDetailDptCount(txtBeginDate.Text, txtEndDate.Text, GovManager.Area.Code, Master.CurrentDJS.Id, out totalcount, out livevount, out visitedcount);
            laTotalCount.Text = totalcount.ToString();
            laLiveCount.Text = livevount.ToString();
            laVisitedCount.Text = visitedcount.ToString();
        }
    }
}