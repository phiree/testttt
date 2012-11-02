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
        rpt.DataSource = bllDJEnt.GetEntList_ExcludeScenic(string.Empty);
        rpt.DataBind();
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as DJ_TourEnterprise;
            Label lblAdmin = e.Item.FindControl("lblAdmin") as Label;
            DJ_User_TourEnterprise user = bllUser.GetUser_TEbyId(ent.Id, 15);
            Button btn = e.Item.FindControl("btnadmin") as Button;
            if (user != null)
            {
                lblAdmin.Text = user.Name;
                btn.Visible = false;

            }
            Button btnVerify = e.Item.FindControl("btnSetVerify") as Button;
            //if (ent.IsVeryfied)
            //{
            //    btnVerify.Text = "已认证";
            //}
            //else{
            //    btnVerify.Text = "尚未认证";
            //}
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
          
            string loginname = "entAdmin_" + entId;
            DJ_User_TourEnterprise djuserent = new DJ_User_TourEnterprise();
            djuserent.Enterprise = bllDJEnt.GetDJS8id(entId.ToString())[0];
            djuserent.Name = loginname;
            djuserent.PermissionType = PermissionType.报表查看员 | PermissionType.团队录入员 | PermissionType.信息编辑员 | PermissionType.用户管理员;
            djuserent.Password=  System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
            bllMember.CreateUpdateMember(djuserent);
        }

        if (e.CommandName.ToLower() == "setverify")
        {
            DJ_TourEnterprise ent = bllDJEnt.GetDJS8id(entId.ToString())[0];
            //ent.IsVeryfied = !ent.IsVeryfied;
            //bllDJEnt.Save(ent);
        }
        BindList();
            
    }
}