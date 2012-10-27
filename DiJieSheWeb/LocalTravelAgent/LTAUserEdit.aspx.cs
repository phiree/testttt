using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class LocalTravelAgent_LTAUserEdit : System.Web.UI.Page
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
            //switch ((int)user.PermissionMask)
            //{
            //    case 1: cbList.Items[0].Selected = true; break;
            //}
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || cbList.SelectedItem == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('用户名或权限未填写');", true);
            return;
        }
        DJ_User_TourEnterprise mgrUser = new DJ_User_TourEnterprise();
        if (Request.QueryString["userid"] != null)
        {
            mgrUser = blldj_user.GetByMemberId(Guid.Parse(Request.QueryString["userid"]));
        }
        mgrUser.Enterprise = Master.CurrentDJS;
        mgrUser.Name = txtName.Text;
        //Model.DJ_User_TourEnterprisePermission sat = 0;
        //foreach (ListItem item in cbList.Items)
        //{
        //    if (item.Selected)
        //    {
        //        Model.DJ_User_TourEnterprisePermission permisson = (Model.DJ_User_TourEnterprisePermission)Enum.Parse(typeof(Model.DJ_User_TourEnterprisePermission), item.Text);
        //        sat = sat | permisson;
        //    }
        //}
        //mgrUser.PermissionMask = sat;
        mgrUser.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
        blldj_user.SaveOrUpdate(mgrUser);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功');window.location='/LocalTravelAgent/LTAUserManager.aspx'", true);
    }
}