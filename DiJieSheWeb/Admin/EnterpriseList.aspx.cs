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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    protected void BindList()
    {
        rpt.DataSource = bllDJEnt.GetDjs8all();
        rpt.DataBind();
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as DJ_TourEnterprise;
            TextBox tbx = e.Item.FindControl("tbxUserName") as TextBox;
            DJ_User_TourEnterprise user = bllDjUser.GetUser_TEbyId(ent.Id);
            Button btn = e.Item.FindControl("btnadmin") as Button;
            if (user != null)
            {
                tbx.Text = user.Name;
                btn.Visible = false;

            }
        }
    }
    BLLDJ_User bllDjUser = new BLLDJ_User();
    BLLDJEnterprise bllDJEnt = new BLLDJEnterprise();
    BLLMembership bllMember = new BLLMembership();
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "addadmin")
        {
            Guid entId = Guid.Parse(e.CommandArgument.ToString());
            string hashcode = Math.Abs(entId.GetHashCode()).ToString() ;
            string loginname = "entAdmin_" + hashcode.Substring(hashcode.Length - 4, 4);
            DJ_User_TourEnterprise djuserent = new DJ_User_TourEnterprise();
            djuserent.Enterprise = bllDJEnt.GetDJS8id(entId.ToString())[0];
            djuserent.Name = loginname;
            djuserent.Password=  System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");

            bllMember.CreateUpdateMember(djuserent);
            BindList();
            


        }
    }
}