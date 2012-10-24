using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class TourEnterprise_TEGroupForecast : System.Web.UI.Page
{
    BLLDJRoute BLLDJRoute = new BLLDJRoute();
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    int Index = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BtnSearch_Click(null, null);
        }
    }

    private void bind(string groupname,string EntName,string BeginTime,string EndTime)
    {
        rptTgInfo.DataSource = BLLDJRoute.GetRouteByAllCondition(groupname, EntName, BeginTime, EndTime,Master.CurrentTE.Id);
        rptTgInfo.DataBind();
    }
    protected void rptTgInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laArriveTime = e.Item.FindControl("ArriveTime") as Literal;
            Literal laNo = e.Item.FindControl("laNo") as Literal;
            laNo.Text = Index++.ToString();
            DJ_Route route = e.Item.DataItem as DJ_Route;
            laArriveTime.Text = route.DJ_TourGroup.BeginDate.AddDays(route.DayNo - 1).ToString("yyyy年MM月dd日");
            int MaxLiveDay;
            List<DJ_Route> listWroute = bllrecord.GetLiveRouteByDay(out MaxLiveDay, 1, Master.CurrentTE, route);
            Literal laLiveCount = e.Item.FindControl("laLiveCount") as Literal;
            laLiveCount.Text = MaxLiveDay.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DateTime BeginTime,EndTime;
        if (DateTime.TryParse(txtBeginTime.Text, out BeginTime) && DateTime.TryParse(txtEndTime.Text, out EndTime))
        {
            if (BeginTime > EndTime)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('起始时间大于终止时间')", true);
                txtBeginTime.Text = "";
                txtEndTime.Text = "";
            }
        }
        else
        {
            txtBeginTime.Text = "";
            txtEndTime.Text = "";
        }
        bind(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text);
    }
}