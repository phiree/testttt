using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenicManager_GroupTestatistics : System.Web.UI.Page
{
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLDJRoute BLLDJRoute = new BLLDJRoute();
    public int Index = 1;
    List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBeginTime.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            bindTgRecord(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text);
        }
    }

    private void bindTgRecord(string groupname, string entname, string begintime, string endtime)
    {
        if (ddlState.SelectedValue == "已验证")
            ListRecord = bllrecord.GetRecordByAllCondition(groupname, entname, begintime, endtime, Master.Scenic.Id);
        if (ddlState.SelectedValue == "未验证")
            ListRecord.AddRange(BindForeast(groupname, entname, begintime, endtime));
        if (ddlState.SelectedValue == "全部")
        {
            ListRecord = bllrecord.GetRecordByAllCondition(groupname, entname, begintime, endtime, Master.Scenic.Id);
            ListRecord.AddRange(BindForeast(groupname, entname, begintime, endtime));
        }
        //ListRecord = OrderByList(ListRecord);
        rptTgRecord.DataSource = ListRecord;
        rptTgRecord.DataBind();
    }


    private List<DJ_GroupConsumRecord> BindForeast(string groupname, string EntName, string BeginTime, string EndTime)
    {
        List<DJ_Route> ListRoute = BLLDJRoute.GetRouteByAllCondition(groupname, EntName, BeginTime, EndTime, Master.Scenic.Id).ToList();
        List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
        foreach (DJ_Route route in ListRoute)
        {
            DJ_GroupConsumRecord record = new DJ_GroupConsumRecord();
            int MaxLiveDay;
            List<DJ_Route> listWroute = bllrecord.GetLiveRouteByDay(out MaxLiveDay, 1, Master.Scenic, route);
            record.LiveDay = MaxLiveDay;
            record.Route = route;
            record.AdultsAmount = route.DJ_TourGroup.AdultsAmount;
            record.ChildrenAmount = route.DJ_TourGroup.ChildrenAmount;
            record.Enterprise = Master.Scenic;
            record.ConsumeTime = route.DJ_TourGroup.BeginDate.AddDays(route.DayNo - 1);
            ListRecord.Add(record);
        }
        return ListRecord;
    }
    protected void rptTgRecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GroupConsumRecord record = e.Item.DataItem as DJ_GroupConsumRecord;
            Literal laIsChecked = e.Item.FindControl("laIsChecked") as Literal;
            if (record.Id.Equals(Guid.Empty))
            {
                laIsChecked.Text = "未验证";
            }
            else
                laIsChecked.Text = "已验证";
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laGuiderCount = e.Item.FindControl("laGuiderCount") as Literal;
            Literal laAdultCount = e.Item.FindControl("laAdultCount") as Literal;
            Literal laChildrenCount = e.Item.FindControl("laChildrenCount") as Literal;
            int groupcount, adultcount, childrencount;
            bllrecord.GetCountInfoByETid(Master.Scenic.Id, out groupcount, out adultcount, out childrencount, ListRecord);
            laGuiderCount.Text = groupcount.ToString();
            laAdultCount.Text = adultcount.ToString();
            laChildrenCount.Text = childrencount.ToString();
        }
    }
}