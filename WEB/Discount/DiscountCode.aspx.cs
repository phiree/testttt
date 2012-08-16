using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class DiscountCode : basepage
{
    BLLDiscountCode blldc = new BLLDiscountCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CurrentUser.UserName))
        {
            Response.Redirect("ShowMessage.aspx?type=1");
        }
        Model.DiscountCode dc = blldc.GetDiscountCodeByDisCode(DisCode.Text.Trim());
        if (dc == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "notfound", "alert('未找到您输入的注册码，请重新确认！')", true);
            return;
        }
        if (!string.IsNullOrEmpty(dc.IdCard))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('该优惠码已经被注册')", true);
        }
        else
        {
            Model.TourMembership user = new BLLMembership().GetUserByUserId((Guid)CurrentUser.ProviderUserKey);
            dc.MemberId = user.Id;
            dc.IdCard = user.IdCard;
            blldc.updateDiscountCode(dc);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('优惠码注册成功')", true);
        }
    }
}