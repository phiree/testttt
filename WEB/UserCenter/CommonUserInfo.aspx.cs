using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class UserCenter_CommonUserInfo : basepage
{
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        rptcu.DataSource = bllcommonuser.GetCommonUserByUserId((Guid)CurrentUser.ProviderUserKey);
        rptcu.DataBind();
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptcu.Items)
        {
            if ((item.FindControl("ckbselect") as CheckBox).Checked)
            {
                string id = (item.FindControl("hfid") as HiddenField).Value;
                bllcommonuser.deleteCommonUser(int.Parse(id));
            }
        }
        bind();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateCommonUser.aspx");
    }
}