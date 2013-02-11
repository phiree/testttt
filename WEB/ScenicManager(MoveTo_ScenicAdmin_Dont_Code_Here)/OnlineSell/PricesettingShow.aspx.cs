using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class ScenicManager_OnlineSell_PricesettingShow : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        redirect();
    }


    private void redirect()
    {
        Scenic scenic = Master.Scenic;
        if (scenic.Tickets.Count > 0)
        {
            Response.Redirect("/ScenicManager/OnlineSell/PriceState.aspx");
        }
        else
        {
            Response.Redirect("/ScenicManager/OnlineSell/Pricesetting.aspx");
        }
    }
}