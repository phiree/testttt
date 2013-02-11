using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenicManager_OnlineSell_PriceState : bpScenicManager
{
    BLLScenic bllscenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        redirect();
    }

    private void redirect()
    {
        ScenicCheckProgress scp= bllscenic.GetCheckProgressByscidandmouid(Master.Scenic.Id, 1);
        if (scp == null)
        {
            scp = new ScenicCheckProgress();
            scp.CheckStatus = CheckStatus.NotApplied;
            scp.Module = ScenicModule.SellOnLine;
            scp.Scenic = CurrentScenic;
            scp.CheckTime = DateTime.Now;
            bllscenic.UpdateCheckState(scp);
        }
        if (scp.CheckStatus == CheckStatus.NotApplied || scp.CheckStatus == CheckStatus.Applied_1 || scp.CheckStatus == CheckStatus.Applied_2 || scp.CheckStatus == CheckStatus.Applied_3)
        {
            Response.Redirect("/ScenicManager/OnlineSell/Pricesetting.aspx");
        }
        else
        {
            Response.Redirect("/ScenicManager/OnlineSell/TicketApply.aspx");
        }
    }
}