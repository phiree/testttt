using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;

public partial class LocalTravelAgent_LTAUserEdit : basepageDJS
{
    BLLDJ_User blldj_user = new BLLDJ_User();
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
            DJ_User_TourEnterprise user = blldj_user.GetByMemberId(userid);
            txtName.Text = user.Name;
            switch ((int)user.PermissionType)
            {
                case 1: cbList.Items[0].Selected = true; break;
                case 2: cbList.Items[1].Selected = true; break;
                case 3: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; break;
                case 4: cbList.Items[2].Selected = true; break;
                case 5: cbList.Items[0].Selected = true; cbList.Items[2].Selected = true; break;
                case 6: cbList.Items[1].Selected = true; cbList.Items[2].Selected = true; break;
                case 7: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; cbList.Items[2].Selected = true; break;
                case 8: cbList.Items[3].Selected = true; break;
                case 9: cbList.Items[0].Selected = true; cbList.Items[3].Selected = true; break;
                case 10: cbList.Items[1].Selected = true; cbList.Items[3].Selected = true; break;
                case 11: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; cbList.Items[3].Selected = true; break;
                case 12: cbList.Items[2].Selected = true; cbList.Items[3].Selected = true; break;
                case 13: cbList.Items[0].Selected = true; cbList.Items[2].Selected = true; cbList.Items[3].Selected = true; break;
                case 14: cbList.Items[1].Selected = true; cbList.Items[2].Selected = true; cbList.Items[3].Selected = true; break;
                case 15: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; cbList.Items[2].Selected = true; cbList.Items[3].Selected = true; break;
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || cbList.SelectedItem == null)
        {
            ShowNotification("用户名或权限未填写");
            return;
        }
        DJ_User_TourEnterprise mgrUser = new DJ_User_TourEnterprise();
        if (Request.QueryString["userid"] != null)
        {
            mgrUser = blldj_user.GetByMemberId(Guid.Parse(Request.QueryString["userid"]));
        }
        else
        {
            mgrUser.Password=FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
        }
        mgrUser.Enterprise = Master.CurrentDJS;
        mgrUser.Name = txtName.Text;
        Model.PermissionType sat = 0;
        int result, result2;
        foreach (ListItem item in cbList.Items)
        {
            if (item.Selected)
            {
                Model.PermissionType permisson = (Model.PermissionType)Enum.Parse(typeof(Model.PermissionType), item.Text.Substring(0,item.Text.IndexOf('(')));
                sat = sat | permisson;
            }
        }
        int.TryParse(mgrUser.PermissionType.ToString(), out result);
        int.TryParse(sat.ToString(), out result2);
        if (result == 15&&result2!=15)
        {
            IList<DJ_User_TourEnterprise> Listuser = blldj_user.GetUser_TEbyId(CurrentDJS.Id, 15);
            if (Listuser != null && Listuser.Count <= 1)
            {
                ShowNotification("目前仅有这一个超级管理员，无法更改权限");
                return;
            }
        }
        mgrUser.PermissionType = sat;
        
        string message;
        blldj_user.SaveOrUpdate(mgrUser,out message);
        if (message != "")
        {
            ShowNotification(message);
        }
        else
            ShowNotification("提示", "保存成功", "/LocalTravelAgent/LTAUserManager.aspx");
    }
}