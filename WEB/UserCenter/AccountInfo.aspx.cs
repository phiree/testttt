using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class UserCenter_AccountInfo : System.Web.UI.Page
{
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.Security.MembershipUser mu = System.Web.Security.Membership.GetUser();
            Guid guid = new Guid(mu.ProviderUserKey.ToString());
            TourMembership tm = bllMember.GetMemberById(guid);
            User user = (User)tm;
            txtBoxLoginname.Text = user.Name;
            txtBoxName.Text = user.RealName;
            txtBoxIdcard.Text = user.IdCard;
            txtBoxAddress.Text = user.Address;
            txtBoxPhone.Text = user.Phone;
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        System.Web.Security.MembershipUser mu = System.Web.Security.Membership.GetUser();
        Guid guid = new Guid(mu.ProviderUserKey.ToString());
        TourMembership tm = bllMember.GetMemberById(guid);
        User user = (User)tm;
        user.Name = txtBoxLoginname.Text.Trim();
        user.RealName = txtBoxName.Text.Trim();
        user.IdCard = txtBoxIdcard.Text.Trim();
        user.Address = txtBoxAddress.Text.Trim();
        user.Phone = txtBoxPhone.Text.Trim();
        bllMember.CreateUpdateMember(user);
        Page.ClientScript.RegisterStartupScript(typeof(Button), "buttonsave", "alert('修改成功')",true);
    }
}