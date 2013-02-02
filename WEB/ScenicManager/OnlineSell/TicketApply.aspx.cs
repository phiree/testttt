using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_OnlineSell_TicketApply : bpScenicManager
{
    BLLScenic bllscenic = new BLLScenic();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLTicket bllticket = new BLLTicket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPrice();
            bind();
        }
    }

    private void BindPrice()
    {
        IList<Model.TicketBase> tickets = bllticket.GetTicketByscId(CurrentScenic.Id);
        rptprice.DataSource = tickets;
        rptprice.DataBind();
    }
    private void bind()
    {
        ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(Master.Scenic.Id, 1);
        if (scp.CheckStatus == CheckStatus.Pass)
        {
            passdiv.Visible = true;
            applyingdiv.Visible = false;
            failurediv.Visible = false;
        }
        if (scp.CheckStatus == CheckStatus.Applied)
        {
            passdiv.Visible = false;
            applyingdiv.Visible = true;
            failurediv.Visible = false;
        }
        if (scp.CheckStatus == CheckStatus.NotPass)
        {
            passdiv.Visible = false;
            applyingdiv.Visible = false;
            failurediv.Visible = true;
        }
    }
}