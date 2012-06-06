using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_UploadAdminInfo : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TourMembership tm = CurrentMember;
        tm.Name = txtusername.Text.Trim();
        tm.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtpwd.Text.Trim(), "MD5");
        new BLLMembership().updateinfo(tm);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('修改成功');", true);
    }
}