using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class TourEnterprise_TEUserManager : basepage
{
    public int Index = 1;
    BLLDJ_User bllUser = new BLLDJ_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        rptUser.DataSource = bllUser.GetLocal_UserByLocalId(Master.CurrentTE.Id);
        rptUser.DataBind();
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/TourEnterprise/TEUser.aspx");
    }
    protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid userid = Guid.Parse(e.CommandArgument.ToString());
        DJ_User_TourEnterprise user = bllUser.GetByMemberId(userid);
        if (e.CommandName == "delete")
        {
            int result;
            int.TryParse(user.PermissionType.ToString(), out result);
            if ((Guid)CurrentUser.ProviderUserKey == user.Id)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('不得删除本人')", true);
                return;
            }
            else if (result == 7)
            {
                IList<DJ_User_TourEnterprise> Listuser = bllUser.GetUser_TEbyId(Master.CurrentTE.Id, 7);
                if (Listuser != null && Listuser.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('目前仅有这一个超级管理员，无法删除')", true);
                    return;
                }
            }
            bllUser.DeleteGov_User(user);
            bind();
        }
        if (e.CommandName == "reset")
        {
            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
            string message;
            bllUser.SaveOrUpdate(user, out message);
            if ((Guid)CurrentUser.ProviderUserKey == user.Id)
            {
                FormsAuthentication.SignOut();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('重置成功，重置后的密码为123456');window.location='/LTALogin.aspx'", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('重置成功，重置后的密码为123456')", true);
        }
    }
    protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_User_TourEnterprise user = e.Item.DataItem as DJ_User_TourEnterprise;
            Literal laPermis = e.Item.FindControl("laPermis") as Literal;
            switch ((int)user.PermissionType)
            {
                case 1:
                    {
                        laPermis.Text = "信息统计员";
                        break;
                    }
                case 2:
                    {
                        laPermis.Text = "信息验证员";
                        break;
                    }
                case 3:
                    {
                        laPermis.Text = "信息统计员" + "、"
                            + "信息验证员";
                        break;
                    }
                case 4:
                    {
                        laPermis.Text = "用户管理员";
                        break;
                    }
                case 5:
                    {
                        laPermis.Text = "信息统计员" + "、"
                            + "用户管理员";
                        break;
                    }
                case 6:
                    {
                        laPermis.Text = "信息验证员" + "、"
                            + "用户管理员";
                        break;
                    }
                case 7:
                    {
                        laPermis.Text = "信息统计员" + "、"
                            + "信息验证员" + "、"
                            + "用户管理员";
                        break;
                    }
            }
            HtmlAnchor aedit = e.Item.FindControl("aedit") as HtmlAnchor;
            aedit.HRef = "/TourEnterprise/TEUser.aspx?userid=" + user.Id;
        }
    }
}