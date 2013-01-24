using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class UserCenter_UseDetail : basepage
{
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    private void bind()
    {
        int odid = int.Parse(Request.QueryString["odid"]);
        OrderDetail od = bllorderdetail.GetOrderDetailByodid(odid);
        scenicname.InnerHtml = od.TicketPrice.Ticket.Scenic.Name;
        ticketcount.InnerHtml = od.Quantity.ToString();
        Repeater1.DataSource = bllticketassign.GetByodid(odid);
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("usename") != null)
        {
             string idcard= (e.Item.FindControl("idcard") as HtmlContainerControl).InnerHtml;
             TourMembership tm = bllMember.GetMemberById((Guid)CurrentUser.ProviderUserKey);
             TourMembership user = tm;
             if (user.IdCard == idcard)
                 (e.Item.FindControl("usename") as HtmlContainerControl).InnerHtml = user.Name;
             else
             {
                 (e.Item.FindControl("usename") as HtmlContainerControl).InnerHtml = bllcommonuser.GetCommonUserByUserIdandidcard(user.Id, idcard).Name;
             }
        }
    }
}