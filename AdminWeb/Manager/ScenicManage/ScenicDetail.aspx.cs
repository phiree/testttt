using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Model;
using BLL;
/// <summary>
/// 查看景区详情:
/// 基本信息
/// 参与活动的申请照片 以及 相关资料
/// </summary>
public partial class Manager_ScenicDetail : basepage
{
    protected Scenic scenic;
    protected ContractImg contractimg;
    BLLScenic bllScenic = new BLLScenic();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLTicket bllticket = new BLLTicket();
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramId = Request["id"];
        int scenicId;
        if (!int.TryParse(paramId, out scenicId))
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        scenic = bllScenic.GetScenicById(scenicId);
        contractimg = bllScenic.GetContractImg(scenic.Id);
        BindPrice();
        //lblyj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 1).Price.ToString("0");
        //lblydj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 2).Price.ToString("0");
        //lblyhj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 3).Price.ToString("0");
        if (contractimg!=null)
            ContractImg.ImageUrl = "/ScenicImg/" + contractimg.Imgloc;

        if (!IsPostBack)
        {
            LoadOnLineCheck();
        }
    }
    ScenicCheckProgress checkprogress;

    private void BindPrice()
    {
        IList<Model.Ticket> tickets = bllticket.GetTicketByscId(scenic.Id);
        rptprice.DataSource = tickets;
        rptprice.DataBind();
    }

    /// <summary>
    /// 网上售票申请进度
    /// </summary>
    private void LoadOnLineCheck()
    {
        checkprogress = bllScenic.GetStatus(scenic.Id, ScenicModule.SellOnLine);
        if (checkprogress == null) return;
        pnlApplied.Visible = checkprogress.CheckStatus == CheckStatus.Applied;
        pnlPassed.Visible = checkprogress.CheckStatus == CheckStatus.Pass;
    }

    /// <summary>
    /// 通过
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPass_Click(object sender, EventArgs e)
    {
        UpdateStatus(CheckStatus.Pass, ScenicModule.SellOnLine);
        checkprogress = bllScenic.GetStatus(scenic.Id, ScenicModule.SellOnLine);
        LoadOnLineCheck();
        //更改该景区票的状态为释放
        Ticket ticket = new BLLTicket().GetTicketByscId(scenic.Id)[0];
        ticket.Lock = false;
        new BLLTicket().SaveOrUpdateTicket(ticket);
        //Response.Redirect("ScenicPrice.aspx?id=" + Request["id"] + "");
    }

    protected void btnNoPass_Click(object sender, EventArgs e)
    {
        UpdateStatus(CheckStatus.NotPass, ScenicModule.SellOnLine);
        checkprogress = bllScenic.GetStatus(scenic.Id, ScenicModule.SellOnLine);
        LoadOnLineCheck();
    }

    /// <summary>
    /// 更新状态
    /// </summary>
    /// <param name="status"></param>
    /// <param name="module"></param>
    private void UpdateStatus(CheckStatus status, ScenicModule module)
    {
        bllScenic.ChangeCheckStatus(scenic, CurrentMember, module, status);
    }
}