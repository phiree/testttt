using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class UserCenter_Default : basepage
{
    BLLMembership bllMember = new BLLMembership();
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLOrder bllOrder = new BLLOrder();
    BLLHotelOrder bllHotelorder = new BLLHotelOrder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        System.Web.Security.MembershipUser mu = System.Web.Security.Membership.GetUser();
        Guid guid = new Guid(mu.ProviderUserKey.ToString());
        TourMembership tm = bllMember.GetMemberById(guid);

        TourMembership user = tm;
        //IList<TicketAssign> ilist=bllorderdetail.
        visitedrecord.InnerHtml = "有" + bllticketassign.GetUsedRecord(user.IdCard).Count + "条游玩记录";

        dpinfo.InnerHtml = "有" + bllOrder.GetListForUser(tm.Id).Count + "张订票信息";
        //notusedtp.InnerHtml = bllticketassign.GetUnusedCount(user.IdCard) + "张门票未使用";

        var orderlist = bllHotelorder.GetOrderList(tm.Id.ToString());
        hotelinfo.InnerHtml = "有" + orderlist == null ? "0" : orderlist.Count + "条酒店预定信息";

    }
}