using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TourEnterprise_TEStatistics : System.Web.UI.Page
{
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    int Index = 1;
    List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //pagerGot.CurrentPageIndex = 1;
            bind(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text);
        }
    }

    private void bind(string groupname,string entname,string begintime,string endtime)
    {
         ListRecord = bllrecord.GetRecordByAllCondition(groupname, entname, begintime, endtime, Master.CurrentTE.Id);
        rptTgRecord.DataSource = ListRecord;
        rptTgRecord.DataBind();
    }

    protected void rptTgRecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laNo = e.Item.FindControl("laNo") as Literal;
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
    protected void Button1_Click(object sender, EventArgs e)
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
}