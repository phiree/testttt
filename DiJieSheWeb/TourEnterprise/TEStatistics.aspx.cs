using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Linq.Expressions;

public partial class TourEnterprise_TEStatistics : System.Web.UI.Page
{
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLDJRoute BLLDJRoute = new BLLDJRoute();
    int Index = 1;
    List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Cookies.Add(new HttpCookie("orderstr", "0_desc"));
            txtBeginTime.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            bind(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text);
        }
    }

    private void bind(string groupname,string entname,string begintime,string endtime)
    {
        
        if(ddlState.SelectedValue=="已认证")
            ListRecord = bllrecord.GetRecordByAllCondition(groupname, entname, begintime, endtime, Master.CurrentTE.Id);
        if(ddlState.SelectedValue=="未认证")
            ListRecord.AddRange(BindForeast(groupname, entname, begintime, endtime));
        if (ddlState.SelectedValue == "全部")
        {
            ListRecord = bllrecord.GetRecordByAllCondition(groupname, entname, begintime, endtime, Master.CurrentTE.Id);
            ListRecord.AddRange(BindForeast(groupname, entname, begintime, endtime));
        }
        ListRecord= OrderByList(ListRecord);
        rptTgRecord.DataSource = ListRecord;
        rptTgRecord.DataBind();
    }

    protected void rptTgRecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GroupConsumRecord record = e.Item.DataItem as DJ_GroupConsumRecord;
            Literal laNo = e.Item.FindControl("laNo") as Literal;
            Literal laIsChecked = e.Item.FindControl("laIsChecked") as Literal;
            if (record.Id.Equals(Guid.Empty))
            {
                laIsChecked.Text = "未验证";
            }
            else
                laIsChecked.Text = "已验证";
            laNo.Text = Index++.ToString();
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laGuiderCount = e.Item.FindControl("laGuiderCount") as Literal;
            Literal laAdultCount = e.Item.FindControl("laAdultCount") as Literal;
            Literal laChildrenCount = e.Item.FindControl("laChildrenCount") as Literal;
            int groupcount,adultcount,childrencount;
            bllrecord.GetCountInfoByETid(Master.CurrentTE.Id, out groupcount, out adultcount, out childrencount, ListRecord);
            laGuiderCount.Text = groupcount.ToString();
            laAdultCount.Text = adultcount.ToString();
            laChildrenCount.Text = childrencount.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DateTime BeginTime, EndTime;
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

    private List<DJ_GroupConsumRecord> BindForeast(string groupname, string EntName, string BeginTime, string EndTime)
    {
        List<DJ_Route> ListRoute = BLLDJRoute.GetRouteByAllCondition(groupname, EntName, BeginTime, EndTime, Master.CurrentTE.Id).ToList();
        List<DJ_GroupConsumRecord> ListRecord=new List<DJ_GroupConsumRecord>();
        foreach (DJ_Route route in ListRoute)
        {
            DJ_GroupConsumRecord record = new DJ_GroupConsumRecord();
            int MaxLiveDay;
            List<DJ_Route> listWroute = bllrecord.GetLiveRouteByDay(out MaxLiveDay, 1, Master.CurrentTE, route);
            record.LiveDay = MaxLiveDay;
            record.Route = route;
            record.AdultsAmount = route.DJ_TourGroup.AdultsAmount;
            record.ChildrenAmount = route.DJ_TourGroup.ChildrenAmount;
            record.Enterprise = Master.CurrentTE;
            record.ConsumeTime = route.DJ_TourGroup.BeginDate.AddDays(route.DayNo-1);
            ListRecord.Add(record);
        }
        return ListRecord;
    }

    #region 排序方法
    private List<DJ_GroupConsumRecord> OrderByList(List<DJ_GroupConsumRecord> ListRecord)
    {
        string[] orderbyStrs = Request.Cookies["orderstr"].Value.Split('_');
        int orderIndex = int.Parse(orderbyStrs[0]);
        string orderType = orderbyStrs[1];
        switch (orderIndex)
        {
            case 0:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.ConsumeTime).ToList() : ListRecord.OrderByDescending(x => x.ConsumeTime).ToList();
                    break;
                }
            case 1:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.Route.DJ_TourGroup.Name).ToList() : ListRecord.OrderByDescending(x => x.Route.DJ_TourGroup.Name).ToList();
                    break;
                }
            case 2:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name).ToList() : ListRecord.OrderByDescending(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name).ToList();
                    break;
                }
            case 3:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.LiveDay).ToList() : ListRecord.OrderByDescending(x => x.LiveDay).ToList();
                    break;
                }
            case 4:
                {
                    ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.AdultsAmount).OrderBy(x => x.ChildrenAmount).ToList() : ListRecord.OrderByDescending(x => x.AdultsAmount).OrderByDescending(x => x.ChildrenAmount).ToList();
                    break;
                }
            default:
                break;
        }
        return ListRecord;
                        
    }
    #endregion
}