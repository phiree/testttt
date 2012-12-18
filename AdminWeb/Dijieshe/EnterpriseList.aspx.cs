using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using CommonLibrary;
/// <summary>
/// 政府部门数据导入
/// </summary>
public partial class Admin_EnterpriseList : System.Web.UI.Page
{
    BLLDJ_User bllUser = new BLLDJ_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    protected void BindList()
    {
        rpt.DataSource = bllDJEnt.GetEntList_ExcludeScenic(txtEntName.Text,ddlType.SelectedValue, string.Empty);
        rpt.DataBind();
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as DJ_TourEnterprise;
            Label lblAdmin = e.Item.FindControl("lblAdmin") as Label;
            Button btnadmin = e.Item.FindControl("btnadmin") as Button;
            Button btnreset = e.Item.FindControl("btnreset") as Button;
            IList<DJ_User_TourEnterprise> members = bllUser.GetUser_TEbyId(ent.Id, 15);
            if (members.Count >= 1)
            {
                lblAdmin.Text = members[0].Name;
                btnadmin.Visible = false;
            }
            else
            {
                lblAdmin.Visible = false;
                btnreset.Visible = false;
            }
            Label lblVerify = e.Item.FindControl("lblVerify") as Label;

            string state = string.Format("{0},{1},{2}", ent.ProvinceVeryfyState.ToString()
            , ent.CityVeryfyState.ToString()
                , ent.CountryVeryfyState.ToString());
            lblVerify.Text = state;


        }
    }
    BLLDJ_User bllDjUser = new BLLDJ_User();
    BLLDJEnterprise bllDJEnt = new BLLDJEnterprise();
    BLLMembership bllMember = new BLLMembership();
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int entId = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName.ToLower() == "addadmin")
        {
            DJ_TourEnterprise ent = bllDJEnt.GetDJS8id(entId.ToString())[0];
            if (string.IsNullOrEmpty(ent.SeoName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "accountcannotnull", "alert('该企业还没有seoname，请先填写seoname');", true);
                return;
            }
            if (bllMember.GetMember(ent.SeoName) != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "accountcannotnull", "alert('用户名重复，请检查seoname是否重复');", true);
                return;
            }
            string loginname = ent.SeoName;
            DJ_User_TourEnterprise djuserent = new DJ_User_TourEnterprise();
            djuserent.Enterprise = bllDJEnt.GetDJS8id(entId.ToString())[0];
            djuserent.Name = loginname;
            djuserent.PermissionType = PermissionType.报表查看员 | PermissionType.团队录入员 | PermissionType.信息编辑员 | PermissionType.用户管理员;
            djuserent.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
            bllMember.CreateUpdateMember(djuserent);
        }

        if (e.CommandName.ToLower() == "resetpwd")
        {
            DJ_TourEnterprise ent = bllDJEnt.GetDJS8id(entId.ToString())[0];
            bllMember.ResetEntAdmin(ent);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "accountcannotnull", "alert('重置密码成功');", true);
        }
        BindList();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
}