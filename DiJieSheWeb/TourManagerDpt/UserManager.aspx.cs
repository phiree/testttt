using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Model;
using BLL;

public partial class TourManagerDpt_UserManager : System.Web.UI.Page
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
        rptUser.DataSource = blldj_user.GetAllGov_User();
        rptUser.DataBind();
    }
    protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_User_Gov user = e.Item.DataItem as DJ_User_Gov;
            Literal laPermis = e.Item.FindControl("laPermis") as Literal;
            //switch ((int)user.PermissionMask)
            //{
            //    case 1:
            //        {
            //            laPermis.Text = "行业管理员";
            //            break;
            //        }
            //    case 2:
            //        {
            //            laPermis.Text = "信息维护员";
            //            break;
            //        }
            //    case 3:
            //        {
            //            laPermis.Text = "行业管理员、信息维护员";
            //            break;
            //        }
            //}
            HtmlAnchor aedit = e.Item.FindControl("aedit") as HtmlAnchor;
            aedit.HRef = "/TourManagerDpt/UserEdit.aspx?userid=" + user.Id;
        }
    }
    protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            Guid userid = Guid.Parse(e.CommandArgument.ToString());
            DJ_User_Gov user = blldj_user.GetGov_UserById(userid);
            blldj_user.DeleteGov_User(user);
            bind();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/TourManagerDpt/UserEdit.aspx");
    }
}