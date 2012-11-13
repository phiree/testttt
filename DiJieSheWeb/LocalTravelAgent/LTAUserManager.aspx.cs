using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class LocalTravelAgent_LTAUserManager : basepageDJS
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
        rptUser.DataSource = bllUser.GetLocal_UserByLocalId(CurrentDJS.Id);
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
            bind();
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
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString();
                        break;
                    }
                case 2:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString();
                        break;
                    }
                case 3:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
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
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
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
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString();
                        break;
                    }
                case 8:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 9:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 10:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 11:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、" +
                            ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 12:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 13:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString()+"、"
                            +((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 14:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString() + "、" +
                            ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
                case 15:
                    {
                        laPermis.Text = ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 1)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 2)).ToString() + "、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 4)).ToString()+"、"
                            + ((Model.PermissionType)Enum.ToObject(typeof(Model.PermissionType), 8)).ToString();
                        break;
                    }
            }
            HtmlAnchor aedit = e.Item.FindControl("aedit") as HtmlAnchor;
            aedit.HRef = "/LocalTravelAgent/LTAUserEdit.aspx?userid=" + user.Id;
        }
    }
}