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
    BLLMembership bllmem = new BLLMembership();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtusername.Text.Trim()) || string.IsNullOrWhiteSpace(txtpwd.Text.Trim())
            || string.IsNullOrWhiteSpace(txtnewpwd1.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请将信息填写完整！');", true);
            return;
        }
        else
        {
            TourMembership user = bllmem.GetMember(txtusername.Text.Trim());
            if (user == null || user.Name==CurrentMember.Name)
            {
                TourMembership tm = CurrentMember;
                tm.Name = txtusername.Text.Trim();
                //tm.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtpwd.Text.Trim(), "MD5");
                if (tm.Password == System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtpwd.Text.Trim(), "MD5"))
                {
                    if (txtnewpwd1.Text.Trim() == txtnewpwd2.Text.Trim())
                    {
                        tm.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtnewpwd1.Text.Trim(), "MD5");
                        bllmem.updateinfo(tm);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('修改成功');", true);
                        Response.Redirect("/scenicmanager");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('旧密码错误，无法修改！');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('该用户名已存在，请重新输入！');", true);
                return;
            }
        }
    }
}