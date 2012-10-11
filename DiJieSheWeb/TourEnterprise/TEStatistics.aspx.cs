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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pagerGot.CurrentPageIndex = 1;
            bind();
        }
    }
    protected void rbolistSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        string type = rbolistSelect.SelectedValue;
        switch (type)
        {
            case "type_1": bindRptTERecord(30); break;
            case "type_2": bindRptTERecord(90); break;
            case "type_3": bindRptTERecord(180); break;
            case "type_4": bindRptTERecord(360); break;
        }
    }

    private void bindRptTERecord(int day)
    {
        int pageIndex = GetPageIndex();
        int pageSize = pagerGot.PageSize;
        int totalRecord;
        List<DJ_TourGroup> ListTg = bllrecord.GetFeRecordByETId(Master.CurrentTE.Id, day, pageIndex, pageSize, out totalRecord).ToList();
        pagerGot.RecordCount = totalRecord;
        rptTgRecord.DataSource = ListTg;
        rptTgRecord.DataBind();
    }

    private int GetPageIndex()
    {
        string paramPageIndex = Request[pagerGot.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
    protected void rptTgRecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laGuiderCount = e.Item.FindControl("laGuiderCount") as Literal;
            Literal laAdultCount = e.Item.FindControl("laAdultCount") as Literal;
            Literal laChildrenCount = e.Item.FindControl("laChildrenCount") as Literal;
            int groupcount,adultcount,childrencount;
            bllrecord.GetCountInfoByETid(Master.CurrentTE.Id,out groupcount,out adultcount,out childrencount);
            laGuiderCount.Text = groupcount.ToString();
            laAdultCount.Text = adultcount.ToString();
            laChildrenCount.Text = childrencount.ToString();
        }
    }
}