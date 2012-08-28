using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_OnlineSell_Pricesetting : bpScenicManager
{
    BLLScenic bllscenic = new BLLScenic();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLTicket bllticket = new BLLTicket();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["stateurl"] = Request.Url;
        CurrentScenic = Master.Scenic;
        if (Request.QueryString["update"] == null)               //修改标志位
            loadstate();
        else
        {
            panelchangeprice.Visible = true;
            panelpassstate.Visible = false;
            panelshing.Visible = false;
            panelnotpass.Visible = false;
        }
    }

    private void BindPrice()
    {
        IList<Model.Ticket> tickets = bllticket.GetTicketByscId(CurrentScenic.Id);
        rptprice.DataSource = tickets;
        rptprice.DataBind();
    }

    private void loadstate()
    {
        ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(CurrentScenic.Id, (int)Model.ScenicModule.SellOnLine);
        if (scp != null)
        {
            panelpassstate.Visible = scp.CheckStatus == CheckStatus.Pass;
            panelshing.Visible = scp.CheckStatus == CheckStatus.Applied;
            panelnotpass.Visible = scp.CheckStatus == CheckStatus.NotPass;
            panelchangeprice.Visible = scp.CheckStatus == CheckStatus.NotApplied;
            BindPrice();
            //lblyj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 1).Price.ToString("0") + "元";
            //lblydj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0") + "元";
            //lblyhj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 3).Price.ToString("0") + "元";
        }
        else
        {
            panelchangeprice.Visible = true;
            panelpassstate.Visible = false;
            panelshing.Visible = false;
            panelnotpass.Visible = false;
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(CurrentScenic.Id, (int)Model.ScenicModule.SellOnLine);
        if (scp == null)
            bllscenic.Apply(CurrentScenic, CurrentMember, ScenicModule.SellOnLine);
        else
            bllscenic.Apply(CurrentScenic, CurrentMember, ScenicModule.SellOnLine, scp.Id);
        loadstate();
    }
}