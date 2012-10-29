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
        if (!DateTime.TryParse(txtBeginDate.Text, out begintieme))
        {
            txtBeginDate.Text = "";
        }
        if (!DateTime.TryParse(txtEndDate.Text, out endtime))
        {
            txtEndDate.Text = "";
        }
        listEnt = bllrecord.GetDJStaticsEnt(txtBeginDate.Text, txtEndDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id).ToList();
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
            Literal laVisitedCount = e.Item.FindControl("laVisitedCount") as Literal;
            Literal laLiveCount = e.Item.FindControl("laLiveCount") as Literal;
            laType.Text = (int)ent.Type == 1 ? "景区" : "宾馆";
            HtmlAnchor aname = e.Item.FindControl("aname") as HtmlAnchor;
            aname.HRef = "/LocalTravelAgent/TEDetailStatistics.aspx?year=" + DateTime.Now.Year + "&entid=" + ent.Id;
            DateTime begintieme, endtime;
            if (!DateTime.TryParse(txtBeginDate.Text, out begintieme))
            {
                txtBeginDate.Text = "";
            }
            if (!DateTime.TryParse(txtEndDate.Text, out endtime))
            {
                txtEndDate.Text = "";
            }
            if (laType.Text == "景区")
            {
                int monthcount = bllrecord.GetCountByStatics(txtBeginDate.Text, txtEndDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, 1, ent.Id);
                laVisitedCount.Text = monthcount.ToString();
                laLiveCount.Text = "0";
                totalVisited += monthcount;
            }
            if (laType.Text == "宾馆")
            {
                int monthcount = bllrecord.GetCountByStatics(txtBeginDate.Text, txtEndDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, 2, ent.Id);
                laVisitedCount.Text = "0";
                laLiveCount.Text = monthcount.ToString();
                totalLive += monthcount;
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laTotalVisitedCount = e.Item.FindControl("laTotalVisitedCount") as Literal;
            Literal laTotalLiveCount = e.Item.FindControl("laTotalLiveCount") as Literal;
            laTotalVisitedCount.Text = totalVisited.ToString();
            laTotalLiveCount.Text = totalLive.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }
}