using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class LocalTravelAgent_TourEnterpriseStatistics : System.Web.UI.Page
{
    int Index = 1;
    int totalMonth = 0, totalYear = 0;
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
        DateTime date;
        if(DateTime.TryParse(txtDate.Text,out date))
        {
        }
        else
        {
            txtDate.Text="";
        }
        listEnt = bllrecord.GetDJStaticsEnt(txtDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id).ToList();
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
            Literal laMonthCount = e.Item.FindControl("laMonthCount") as Literal;
            Literal laYearCount = e.Item.FindControl("laYearCount") as Literal;
            laType.Text = (int)ent.Type == 1 ? "景区" : "宾馆";
            DateTime date;
            if (!DateTime.TryParse(txtDate.Text, out date))
            {
                txtDate.Text = "";
            }
            if (laType.Text == "景点")
            {
                int monthcount= bllrecord.GetCountByStatics(txtDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, 1, true, ent.Id);
                laMonthCount.Text = monthcount.ToString();
                totalMonth += monthcount;
                int yearcount=bllrecord.GetCountByStatics(txtDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, 1, false, ent.Id);
                laYearCount.Text += yearcount.ToString();
                totalYear += yearcount;
            }
            if (laType.Text == "宾馆")
            {
                int monthcount = bllrecord.GetCountByStatics(txtDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, 2, true, ent.Id);
                laMonthCount.Text = monthcount.ToString();
                totalMonth += monthcount;
                int yearcount=bllrecord.GetCountByStatics(txtDate.Text, txtEntName.Text.Trim(), int.Parse(ddlType.SelectedValue), Master.CurrentDJS.Id, 2, false, ent.Id);
                laYearCount.Text = yearcount.ToString();
                totalYear += yearcount;
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laTotalMonth = e.Item.FindControl("laTotalMonth") as Literal;
            Literal laTotalYear = e.Item.FindControl("laTotalYear") as Literal;
            laTotalMonth.Text = totalMonth.ToString();
            laTotalYear.Text = totalYear.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }
}