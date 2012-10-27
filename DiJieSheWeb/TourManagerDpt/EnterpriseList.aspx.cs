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
public partial class TourManagerDpt_EnterpriseList : basepageMgrDpt
{
    public int i = 1;
    public int j = 1;
    public int k = 1;
    BLLDJEnterprise bllDjEnt = new BLLDJEnterprise();
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
        var restaurant_ = bllDJEnt.GetEntList_ExcludeScenic(CurrentDpt.Area.Code);
        if (!string.IsNullOrEmpty(txtName.Text))
        {
            restaurant_ = restaurant_.Where(x => x.Name.Split(new string[] { txtName.Text }, StringSplitOptions.None).Count() > 1).ToList();
        }
        if (ddlStar.SelectedItem.Text != "所有")
        {
            //restaurant_ = restaurant_.Where(x => x.IsVeryfied == (ddlStar.SelectedItem.Text == "是" ? true : false)).ToList();
        }
        if (ddlType.SelectedItem.Text != "所有")
        {
            restaurant_ = restaurant_.Where(x => x.Type == (Model.EnterpriseType)Enum.Parse(typeof(Model.EnterpriseType), ddlType.SelectedItem.Text)).ToList();
        }
        rptRestaurant.DataSource = restaurant_.Where(x => x.Type == Model.EnterpriseType.饭店).ToList();
        rptRestaurant.DataBind();
        rptHotel.DataSource = restaurant_.Where(x => x.Type == Model.EnterpriseType.宾馆).ToList();
        rptHotel.DataBind();
        rptShoppingp.DataSource = restaurant_.Where(x => x.Type == Model.EnterpriseType.购物点).ToList();
        rptShoppingp.DataBind();
    }

    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as DJ_TourEnterprise;
           
            Button btnVerify = e.Item.FindControl("btnSetVerify") as Button;
            Label laIsVerify = e.Item.FindControl("laIsVerify") as Label;
            Label labAccount = e.Item.FindControl("labAccount") as Label;
            //if (ent.IsVeryfied)
            //{
            //    btnVerify.Attributes.CssStyle.Add("color", "#009383");
            //    btnVerify.Text = "已纳入";
            //    laIsVerify.Text = "已纳入";
            //}
            //else{
            //    btnVerify.Attributes.CssStyle.Add("color", "Red");
            //    btnVerify.Text = "未纳入";
            //    laIsVerify.Text = "未纳入";
            //}
            if (ent is DJ_DijiesheInfo)
            {
                e.Item.Visible = false;
            }
            Button BtnCreate = e.Item.FindControl("BtnCreate") as Button;
            Button BtnUpdate = e.Item.FindControl("BtnUpdate") as Button;
            TextBox laAccount = e.Item.FindControl("laAccount") as TextBox;
            HiddenField hfuserid = e.Item.FindControl("hfuserid") as HiddenField;
            
            DJ_User_TourEnterprise user= bllUser.GetUser_TEbyId(ent.Id,15);
            if (user != null)
            {
                laAccount.Visible = true;
                laAccount.Text = user.Name;
                BtnCreate.Visible = false;
                BtnUpdate.Visible = true;
                hfuserid.Value = user.Id.ToString();
                labAccount.Text = user.Name;
            }
            else
            {
                laAccount.Visible = false;
                BtnCreate.Visible = true;
                BtnUpdate.Visible = false;
            }
            //权限判断
            DJ_User_Gov govUser = (DJ_User_Gov)CurrentMember;
            //switch ((int)govUser.PermissionMask)
            //{
            //    case 2: btnVerify.Visible = false; laIsVerify.Visible = true; BtnCreate.Visible = false; BtnUpdate.Visible = false; laAccount.Visible = false; labAccount.Visible = true; break;
            //}
        }
    }
    BLLDJ_User bllDjUser = new BLLDJ_User();
    BLLDJEnterprise bllDJEnt = new BLLDJEnterprise();
    BLLMembership bllMember = new BLLMembership();
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int entId = int.Parse(e.CommandArgument.ToString());

       
        if (e.CommandName.ToLower() == "setverify")
        {
            DJ_TourEnterprise ent = bllDJEnt.GetDJS8id(entId.ToString())[0];
            //ent.IsVeryfied = !ent.IsVeryfied;
            bllDJEnt.Save(ent);
        }

        if (e.CommandName.ToLower() == "setadmin")
        {
            DJ_TourEnterprise ent = bllDjEnt.GetDJS8id(entId.ToString())[0];
            string loginname =ent.Seoname;
            DJ_User_TourEnterprise mgrUser = new DJ_User_TourEnterprise();
            mgrUser.Enterprise = ent;
            mgrUser.Name = loginname;
            mgrUser.PermissionType = PermissionType.报表查看员 | PermissionType.团队录入员 | PermissionType.信息编辑员 | PermissionType.用户管理员;
            mgrUser.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
            bllMember.CreateUpdateMember(mgrUser);
        }
        if (e.CommandName.ToLower() == "updateadmin")
        {
            TextBox laAccount = e.Item.FindControl("laAccount") as TextBox;
            HiddenField hfuserid = e.Item.FindControl("hfuserid") as HiddenField;
            Model.DJ_User_TourEnterprise user= bllUser.GetByMemberId(Guid.Parse(hfuserid.Value));
            user.Name = laAccount.Text.Trim();
            bllUser.SaveOrUpdate(user);
        }
        BindList();
           
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
}