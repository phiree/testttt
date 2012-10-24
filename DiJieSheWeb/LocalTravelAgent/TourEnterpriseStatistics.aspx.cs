using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class LocalTravelAgent_TourEnterpriseStatistics : System.Web.UI.Page
{
    int Index = 1;
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        DateTime date;
        if(DateTime.TryParse(txtDate.Text,out date))
        {
        }
        else
        {
            txtDate.Text="";
        }
        rptStatistic.DataSource = bllrecord.GetDJStaticsEnt(date.ToString(), txtEntName.Text.Trim(), Master.CurrentDJS.Id);
        rptStatistic.DataBind();
    }
    protected void rptStatistic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laNo = e.Item.FindControl("laNo") as Literal;
            laNo.Text = Index++.ToString();
        }
    }
}