using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///basepage 的摘要说明
/// </summary>
public class basepage : System.Web.UI.Page
{
    public MembershipUser CurrentUser;
    public TourMembership CurrentMember;
    
    BLL.BLLMembership bllMember = new BLL.BLLMembership();
    protected bool NeedLogin { get; set; }
  
    protected override void OnLoad(EventArgs e)
    {
        CurrentUser = Membership.GetUser();
        if (CurrentUser != null)
        {
            CurrentMember = bllMember.GetMemberById((Guid)CurrentUser.ProviderUserKey);
            
        }
        else
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
        }

        base.OnLoad(e);
    }

}