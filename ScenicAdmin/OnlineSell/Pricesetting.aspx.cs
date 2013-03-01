using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_OnlineSell_Pricesetting2 : bpScenicManager
{
    BLLScenic bllscenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        Scenic scenic = Master.Scenic;
        scenicname.InnerHtml = scenic.Name;
        if (scenic.Tickets.Count > 0)
        {
            weldiv.Visible = false;
        }
        else
        {
            weldiv.Visible = true;
        }
        ScenicCheckProgress scp = BllScenic.GetCheckProgressByscidandmouid(scenic.Id, 1);
        if (scp.CheckStatus == CheckStatus.NotApplied || scp.CheckStatus == CheckStatus.NotPass || scp.CheckStatus == CheckStatus.Pass)
        {
            step_1.Style.Add("visibility", "visible");
            //step_2.Style.Add("visibility", "hidden");
            //step_3.Style.Add("visibility", "hidden");
            //step_4.Style.Add("visibility", "hidden");
            //astep_2.Attributes.Add("class", "unable");
            //astep_2.Attributes.Remove("href");
            //astep_3.Attributes.Add("class", "unable");
            //astep_3.Attributes.Remove("href");
            btnApply.OnClientClick = "return btnunable()";
        }
        if (scp.CheckStatus == CheckStatus.Applied_1)
        {
            step_1.Style.Add("visibility", "hidden");
            //step_2.Style.Add("visibility", "visible");
            //step_3.Style.Add("visibility", "hidden");
            //step_4.Style.Add("visibility", "hidden");
            //astep_3.Attributes.Add("class", "unable");
            //astep_3.Attributes.Remove("href");
            btnApply.OnClientClick = "return btnunable()";
        }
        if (scp.CheckStatus == CheckStatus.Applied_2)
        {
            step_1.Style.Add("visibility", "hidden");
            //step_2.Style.Add("visibility", "hidden");
            //step_3.Style.Add("visibility", "visible");
            step_4.Style.Add("visibility", "hidden");
            btnApply.OnClientClick = "return btnunable()";
        }
        if (scp.CheckStatus == CheckStatus.Applied_3)
        {
            step_1.Style.Add("visibility", "hidden");
            //step_2.Style.Add("visibility", "hidden");
            //step_3.Style.Add("visibility", "hidden");
            step_4.Style.Add("visibility", "visible");
            btnApply.Enabled = true;
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(CurrentScenic.Id, (int)Model.ScenicModule.SellOnLine);
        if (scp == null)
            bllscenic.Apply(CurrentScenic, CurrentMember, ScenicModule.SellOnLine);
        else
            bllscenic.Apply(CurrentScenic, CurrentMember, ScenicModule.SellOnLine, scp.Id);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('上传票价成功');window.location='PriceState.aspx'", true);
    }
}