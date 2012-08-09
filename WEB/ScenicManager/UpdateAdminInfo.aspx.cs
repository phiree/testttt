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
    BLLMembership bllmembership = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtusername.Text = CurrentMember.Name;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (bllmembership.GetMember(txtusername.Text.Trim()) != null && CurrentMember.Name != txtusername.Text.Trim())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名已经存在,请重新填写');", true);
            return;
        }
        else
        {
            TourMembership tm = CurrentMember;
            tm.Name = txtusername.Text.Trim();
            tm.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtpwd2.Text.Trim(), "MD5");
            new BLLMembership().updateinfo(tm);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('修改成功');", true);
        }
    }
}