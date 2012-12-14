using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Model;
using BLL;
using System.Web.Security;

public partial class TourManagerDpt_UserManager : basepageMgrDpt
{
    public int Index = 1;
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
        rptUser.DataSource = blldj_user.GetGov_UserByGovId(CurrentDpt.Id);
        rptUser.DataBind();
    }
    protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_User_Gov user = e.Item.DataItem as DJ_User_Gov;
            Literal laPermis = e.Item.FindControl("laPermis") as Literal;
            switch ((int)user.PermissionType)
            {
                case 1:
                    {
                        laPermis.Text = "行业管理员";
                        break;
                    }
                case 2:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString();
                        break;
                    }
                case 3:
                    {
                        laPermis.Text = "行业管理员" +"、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString();
                        break;
                    }
                case 4:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString();
                        break;
                    }
                case 5:
                    {
                        laPermis.Text = "行业管理员" +"、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString();
                        break;
                    }
                case 6:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString();
                        break;
                    }
                case 7:
                    {
                        laPermis.Text = "行业管理员" +"、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString();
                        break;
                    }
            }
            HtmlAnchor aedit = e.Item.FindControl("aedit") as HtmlAnchor;
            aedit.HRef = "/TourManagerDpt/UserEdit.aspx?userid=" + user.Id;
        }
    }
    protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid userid = Guid.Parse(e.CommandArgument.ToString());
        DJ_User_Gov user = blldj_user.GetGov_UserById(userid);
        if (e.CommandName == "delete")
        {
            int result;
            int.TryParse(user.PermissionType.ToString(), out result);
            if ((Guid)CurrentUser.ProviderUserKey == userid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('不得删除本人');", true);
                return;
            }
            else if (result == 7)
            {
                IList<DJ_User_Gov> Listuser = blldj_user.GetGov_UserBygovId(CurrentDpt.Id, 7);
                if (Listuser != null && Listuser.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('目前仅有这一个超级管理员，无法删除')", true);
                    return;
                }
            }
            blldj_user.DeleteGov_User(user);
            bind();
        }
        if (e.CommandName == "reset")
        {
            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
            string message;
            blldj_user.SaveOrUpdate(user, out message);
            if ((Guid)CurrentUser.ProviderUserKey == user.Id)
            {
                FormsAuthentication.SignOut();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('重置成功，重置后的密码为123456');window.location='/Login.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('重置成功，重置后的密码为123456')", true);
            }
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/TourManagerDpt/UserEdit.aspx");
    }
}