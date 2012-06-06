using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class UserCenter_Default :  basepage
{
    BLLMembership bllMember = new BLLMembership();
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
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
        User user = (User)tm;
        //IList<TicketAssign> ilist=bllorderdetail.
        visitedrecord.InnerHtml="有"+ bllticketassign.GetUsedRecord(user.IdCard).Count+"条游玩记录";

        dpinfo.InnerHtml = "有" + bllticketassign.GetDdCount(user.IdCard) + "张订票信息";
        notusedtp.InnerHtml = bllticketassign.GetUsedCount(user.IdCard) + "张门票未使用";
    }
}