using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.Security;

public partial class TourManagerDpt_UserEdit : basepageMgrDpt
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
            switch ((int)user.PermissionType)
            {
                case 1: cbList.Items[0].Selected = true; break;
                case 2: cbList.Items[1].Selected = true; break;
                case 3: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; break;
                case 4: cbList.Items[2].Selected = true; break;
                case 5: cbList.Items[0].Selected = true; cbList.Items[2].Selected = true; break;
                case 6: cbList.Items[1].Selected = true; cbList.Items[2].Selected = true; break;
                case 7: cbList.Items[1].Selected = true; cbList.Items[2].Selected = true; cbList.Items[0].Selected = true; break;
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || cbList.SelectedItem == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "s", "alert('用户名或权限未填写');", true);
            return;
        }
        DJ_User_Gov mgrUser = new DJ_User_Gov();

        //修改用户
        if (Request.QueryString["userid"] != null)
        {
            mgrUser = blldj_user.GetGov_UserById(Guid.Parse(Request.QueryString["userid"]));
        }
        //新增用户
        else
        {
            if (blldj_user.GetGov_UserByName(txtName.Text) != null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('对不起,该用户名已被注册!')", true);
                return;
            }
            mgrUser.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
        }
        //整理用户数据
        DJ_GovManageDepartment mgrDpt = bllDpt.GetMgrDpt(Guid.Parse(Master.dptid));
        mgrUser.GovDpt = mgrDpt;
        mgrUser.Name = txtName.Text;
        Model.PermissionType sat = 0;
        foreach (ListItem item in cbList.Items)
        {
            if (item.Selected)
            {
                Model.PermissionType permisson = (Model.PermissionType)Enum.Parse(typeof(Model.PermissionType), item.Text.Substring(0, item.Text.IndexOf('(')));
                sat = sat | permisson;
            }
        }
        int result, result2;
        int.TryParse(mgrUser.PermissionType.ToString(), out result);
        int.TryParse(sat.ToString(), out result2);
        if (result == 7 && result2 != 7)
        {
            IList<DJ_User_Gov> Listuser = blldj_user.GetGov_UserBygovId(CurrentDpt.Id, 7);
            if (Listuser != null && Listuser.Count <= 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('目前仅有这一个超级管理员，无法更改权限')", true);
                return;
            }
        }
        mgrUser.PermissionType = sat;
        string message;
        blldj_user.SaveOrUpdate(mgrUser,out message);
        if (message != "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "s", "alert('" + message + "')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "s", "alert('保存成功');window.location='/TourManagerDpt/UserManager.aspx'", true);
    }
}