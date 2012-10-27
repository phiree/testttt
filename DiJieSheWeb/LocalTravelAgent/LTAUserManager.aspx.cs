using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class LocalTravelAgent_LTAUserManager : System.Web.UI.Page
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
        rptUser.DataSource = bllUser.GetAllLocal_User();
        rptUser.DataBind();
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LocalTravelAgent/LTAUserEdit.aspx");
    }
    protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            Guid userid = Guid.Parse(e.CommandArgument.ToString());
            DJ_User_TourEnterprise user= bllUser.GetByMemberId(userid);
            bllUser.DeleteGov_User(user);
        }
    }
    protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_User_TourEnterprise user = e.Item.DataItem as DJ_User_TourEnterprise;
            Literal laPermis = e.Item.FindControl("laPermis") as Literal;
            switch ((int)user.PermissionMask)
            {
                case 1: laPermis.Text = Model.DJ_User_TourEnterprisePermission.管理员.ToString(); break;
            }
            HtmlAnchor aedit = e.Item.FindControl("aedit") as HtmlAnchor;
            aedit.HRef = "/LocalTravelAgent/LTAUserManager.aspx?" + user.Id;
        }
    }
}