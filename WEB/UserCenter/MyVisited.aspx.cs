using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class UserCenter_MyVisited : basepage
{
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
    }

    private void bind()
    {
        System.Web.Security.MembershipUser mu = System.Web.Security.Membership.GetUser();
        Guid guid = new Guid(mu.ProviderUserKey.ToString());
        TourMembership tm = bllMember.GetMemberById(guid);
        TourMembership user = tm;
        //IList<TicketAssign> ilist=bllorderdetail.
        rptVisited.DataSource = bllticketassign.GetUsedRecord(user.IdCard);
        rptVisited.DataBind();
        int totalprice = 0;
        foreach (RepeaterItem item in rptVisited.Items)
        {
            totalprice += int.Parse((item.FindControl("vprice") as HtmlContainerControl).InnerHtml) * int.Parse((item.FindControl("vcount") as HtmlContainerControl).InnerHtml);
        }
        vtotalprice.InnerHtml = "合计消费:<span class='strongnum'>" + totalprice.ToString() + "</span>元";
        if (totalprice == 0)
        {
            vtotalexpain.InnerHtml = "<span class='strongnum'></span>";
        }
    }
    protected void rptVisited_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        System.Web.Security.MembershipUser mu = System.Web.Security.Membership.GetUser();
        Guid guid = new Guid(mu.ProviderUserKey.ToString());
        TourMembership tm = bllMember.GetMemberById(guid);
        TourMembership user = tm;
        if (e.Item.FindControl("vpricetype") != null)
        {
            HtmlContainerControl hc = (e.Item.FindControl("vpricetype") as HtmlContainerControl);
            if (hc.InnerHtml == (PriceType.PreOrder.ToString()))
            {
                (e.Item.FindControl("vpricetype") as HtmlContainerControl).InnerHtml = "网上预订";
            }
            else
            {
                (e.Item.FindControl("vpricetype") as HtmlContainerControl).InnerHtml = "在线购买";
            }

            HtmlContainerControl hc2 = (e.Item.FindControl("vcount") as HtmlContainerControl);
            (e.Item.FindControl("vcount") as HtmlContainerControl).InnerHtml = bllticketassign.GetUsedCount(user.IdCard, DateTime.Parse(hc2.InnerHtml)).ToString();
        }

    }
}