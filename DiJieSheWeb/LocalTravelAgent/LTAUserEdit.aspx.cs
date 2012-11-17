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
        Model.PermissionType sat = 0;
        foreach (ListItem item in cbList.Items)
        {
            if (item.Selected)
            {
                Model.PermissionType permisson = (Model.PermissionType)Enum.Parse(typeof(Model.PermissionType), item.Text.Substring(0,item.Text.IndexOf('(')));
                sat = sat | permisson;
            }
        }
        mgrUser.PermissionType = sat;
        blldj_user.SaveOrUpdate(mgrUser);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功');window.location='/LocalTravelAgent/LTAUserManager.aspx'", true);
    }
}