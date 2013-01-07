using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;

public partial class TourEnterprise_TEUser : basepage
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
            mgrUser.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
        }
        mgrUser.Enterprise = Master.CurrentTE;
        mgrUser.Name = txtName.Text;
        Model.PermissionType sat = 0;
        int result, result2;
        for (int i = 0; i < cbList.Items.Count; i++)
        {
            if (cbList.Items[i].Selected)
            {
                Model.PermissionType permisson = new PermissionType();
                switch (i)
                {
                    case 0: permisson = Model.PermissionType.信息编辑员; sat = sat | permisson; break;
                    case 1: permisson = Model.PermissionType.报表查看员; break;
                    case 2: permisson = Model.PermissionType.用户管理员; break;
                    default:
                        break;
                }
                sat = sat | permisson;
            }
        }
        int.TryParse(mgrUser.PermissionType.ToString(), out result);
        int.TryParse(sat.ToString(), out result2);
        if (result == 7 && result2 != 7)
        {
            IList<DJ_User_TourEnterprise> Listuser = blldj_user.GetUser_TEbyId(Master.CurrentTE.Id, 7);
            if (Listuser != null && Listuser.Count <= 1)
            {
                ShowNotification("目前仅有这一个超级管理员，无法更改权限");
                return;
            }
        }
        mgrUser.PermissionType = sat;

        string message;
        blldj_user.SaveOrUpdate(mgrUser, out message);
        if (message != "")
        {
            ShowNotification(message);
        }
        else
            ShowNotification("提示", "保存成功", "/TourEnterprise/TEUserManager.aspx");
    }
}