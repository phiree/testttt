using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_PromAudit :basepage
{
    BLL.BLLBackManager bllManager = new BLL.BLLBackManager();
    BLL.BLLProm bllProm = new BLL.BLLProm();
    BLL.BLLUserVoteAmount bllEarnvote = new BLL.BLLUserVoteAmount();
    BLL.BLLMembership bllMembership = new BLL.BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    private void BindList()
    {
        int pageIndex = GetPageIndex();
        long totalRecord;
        IList<Model.PromotionStatic> promList = bllManager.GetPromList("", pageIndex, pager.PageSize, out totalRecord);
        pager.RecordCount = (int)totalRecord;
        rpt.DataSource = promList;
        rpt.DataBind();
    }

    private int GetPageIndex()
    {
        string paramPageIndex = Request[pager.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "validate")
        {
            //验证按钮的事件
            string[] strArgs = e.CommandArgument.ToString().Split('|');
            Guid userid =new Guid(strArgs[1]);
            int promId = int.Parse(strArgs[0]);
            Model.PromotionStatic prom = bllProm.GetPromById(promId)[0];
            prom.Validated = true;
            bllProm.UpdatePromInfo(prom);
            bllEarnvote.EarnVote(bllMembership.GetUserByUserId(userid), Model.EarnWay.PromoteLink);
            BindList();
        }
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //如果已经验证通过，则隐藏按钮
            Button btnValidate = e.Item.FindControl("btnValidate") as Button;
            btnValidate.Visible = !((Model.PromotionStatic)e.Item.DataItem).Validated;
        }
    }
}