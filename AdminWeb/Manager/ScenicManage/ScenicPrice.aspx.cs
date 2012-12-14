using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_ScenicManage_ScenicPrice : basepage
{
    protected Scenic scenic;
   
    BLLScenic bllScenic = new BLLScenic();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //这里注释掉是因为前台审核价格需要的是显示价格列表，需要重做
        //string paramId = Request["id"];
        //int scenicId;
        //if (!int.TryParse(paramId, out scenicId))
        //{
        //    ErrHandler.Redirect(ErrType.ParamIllegal);
        //}
        //scenic = bllScenic.GetScenicById(scenicId);
        //csp = bllcsp.GetcspByscid(scenic.Id);
        //if (csp != null)
        //    imgcontract.ImageUrl = "/ScenicImg/" + csp.PriceContract;
        //txtyj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 1).Price.ToString("0");
        //txtydj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 2).Price.ToString("0");
        //txtyhj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 3).Price.ToString("0");
    }
    ScenicCheckProgress checkprogress;

    /// <summary>
    /// 网上售票申请进度
    /// </summary>
    private void LoadOnLineCheck()
    {
        checkprogress = bllScenic.GetStatus(scenic.Id, ScenicModule.SellOnLine);
        if (checkprogress == null) return;
        pnlPassed.Visible = checkprogress.CheckStatus == CheckStatus.Pass;
    }

    /// <summary>
    /// 通过审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPass_Click(object sender, EventArgs e)
    {
        UpdateStatus(CheckStatus.Pass, ScenicModule.SellOnLine);
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
    protected void btnNoPass_Click(object sender, EventArgs e)
    {
        UpdateStatus(CheckStatus.NotPass, ScenicModule.SellOnLine);
        checkprogress = bllScenic.GetStatus(scenic.Id, ScenicModule.SellOnLine);
        LoadOnLineCheck();
    }
}