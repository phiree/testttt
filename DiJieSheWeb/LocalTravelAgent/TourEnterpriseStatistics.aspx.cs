using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_TourEnterpriseStatistics : System.Web.UI.Page
{
    int Index = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void bind()
    {

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