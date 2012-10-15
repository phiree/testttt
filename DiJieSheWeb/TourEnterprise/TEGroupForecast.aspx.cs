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
    int Index = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            case "type_1": bindRptTgInfo(3); break;
            case "type_2": bindRptTgInfo(7); break;
            case "type_3": bindRptTgInfo(30); break;
            case "type_4": bindRptTgInfo(1000); break;
        }
    }

    private void bindRptTgInfo(double daycount)
    {
        DateTime foredatetime = DateTime.Now.AddDays(daycount);
        rptTgInfo.DataSource=BLLDJRoute.GetTgByTime(foredatetime, Master.CurrentTE.Id);
        rptTgInfo.DataBind();
    }

    protected void rptTgInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laArriveTime = e.Item.FindControl("ArriveTime") as Literal;
            DJ_TourGroup group = e.Item.DataItem as DJ_TourGroup;
            List<DJ_Route> ListRoute = group.Routes.Where(x => x.Enterprise.Id == Master.CurrentTE.Id).ToList<DJ_Route>();
            laArriveTime.Text = group.BeginDate.AddDays(ListRoute[Index].DayNo - 1).ToString("yyyy年MM月dd日");
            Index++;
        }
    }
}