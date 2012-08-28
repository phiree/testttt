using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenticManager_OnlineSell_OnlinePrice : bpScenicManager
{

    BLLTicket bllTicket = new BLLTicket();
    BLLTicketPrice bllTp = new BLLTicketPrice();
    BLLScenic bllscenic = new BLLScenic();

    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentScenic = Master.Scenic;
        hidden_scid.Value = CurrentScenic.Id.ToString();
        if (!IsPostBack)
        {
            LoadPrice();
        }
    }

    //加载 显示 其价格.
    private void LoadPrice()
    {
        IList<Model.Ticket> tickets = bllTicket.GetTicketByscId(CurrentScenic.Id);
        rptPrice.DataSource = tickets;
        rptPrice.DataBind();
        stateurl.HRef = Session["stateurl"].ToString();
    }

    /// <summary>
    /// 保存景区的三种门票
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOK_Click(object sender, EventArgs e)
    {

        //Model.Ticket ticket = bllTicket.GetTicketByscId(CurrentScenic.Id)[0];

        ////更新该景区票状态为锁，无法显示在首页上
        //ticket.Lock = true;
        //bllTicket.SaveOrUpdateTicket(ticket);

        //TicketPrice tpNormal = new TicketPrice();
        //tpNormal.PriceType = PriceType.Normal;
        //tpNormal.Price = 1;// Convert.ToDecimal(tbxPrice.Text.Trim());

        //tpNormal.Ticket = ticket;
        //bllTp.SaveOrUpdateTicketPrice(tpNormal);

        //TicketPrice tpPayOnline = new TicketPrice();
        //tpPayOnline.PriceType = PriceType.PayOnline;
        //tpPayOnline.Price = 1;// Convert.ToDecimal(tbxPayOnline.Text.Trim());
        //tpPayOnline.Ticket = ticket;
        //bllTp.SaveOrUpdateTicketPrice(tpPayOnline);

        //TicketPrice tpPreorder = new TicketPrice();
        //tpPreorder.PriceType = PriceType.PreOrder;
        //tpPreorder.Price = 1;// Convert.ToDecimal(tbxPreOrder.Text.Trim());
        //tpPreorder.Ticket = ticket;
        //bllTp.SaveOrUpdateTicketPrice(tpPreorder);
        //ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(CurrentScenic.Id, 1);
        //if (scp != null)
        //{
        //    scp.CheckStatus = CheckStatus.NotApplied;
        //    bllscenic.UpdateCheckState(scp);
        //}
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "notice", "alert('操作成功!')", true);

    }
}