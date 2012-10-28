using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TourManagerDpt_UserEdit : System.Web.UI.Page
{
    BLLDJ_User blldj_user = new BLLDJ_User();
    BLLDJMgrDpt bllDpt = new BLLDJMgrDpt();
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
        if (Request.QueryString["userid"] != null)
        {
            Guid userid;
            Guid.TryParse(Request.QueryString["userid"], out userid);
            DJ_User_Gov user = blldj_user.GetGov_UserById(userid);
            txtName.Text = user.Name;
            switch ((int)user.PermissionMask)
            {
                case 1: cbList.Items[0].Selected = true; break;
                case 2: cbList.Items[1].Selected = true; break;
                case 3: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; break;
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || cbList.SelectedItem == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名或权限未填写');", true);
            return;
        }
        DJ_User_Gov mgrUser = new DJ_User_Gov();
        if (Request.QueryString["userid"] != null)
        {
            mgrUser = blldj_user.GetGov_UserById(Guid.Parse(Request.QueryString["userid"]));
        }
        DJ_GovManageDepartment mgrDpt = bllDpt.GetMgrDpt(Guid.Parse(Master.dptid));
        mgrUser.GovDpt = mgrDpt;
        mgrUser.Name = txtName.Text;
        Model.DJ_User_GovPermission sat = 0;
        foreach (ListItem item in cbList.Items)
        {
            if (item.Selected)
            {
                Model.DJ_User_GovPermission permisson = (Model.DJ_User_GovPermission)Enum.Parse(typeof(Model.DJ_User_GovPermission), item.Text);
                sat = sat | permisson;
            }
        }
        mgrUser.PermissionMask = sat;
        mgrUser.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
        blldj_user.SaveOrUpdate(mgrUser);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功');window.location='/TourManagerDpt/UserManager.aspx'", true);
    }
}