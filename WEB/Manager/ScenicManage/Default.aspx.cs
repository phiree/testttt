using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Model;
using CommonLibrary;

public partial class Manager_ScenicinList : System.Web.UI.Page
{
    BLL.BLLBackManager bllmanager = new BLL.BLLBackManager();
    BLL.BLLScenic bllScenic = new BLL.BLLScenic();
    BLL.BLLArea bllArea = new BLL.BLLArea();
    BLL.BLLScenicAdmin bllscenicadmin = new BLL.BLLScenicAdmin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindList(); 
        }
    }
    private void BindArea()
    {
        ddlArea.DataSource = bllArea.GetSubArea("330000");
        ddlArea.DataTextField = "Name";
        ddlArea.DataValueField = "Code";
        ddlArea.DataBind();
    }
    private void BindList()
    {
        IList<Model.Scenic> scenicList = bllmanager.GetScenicList(" where s.Area.Code=" + ddlArea.SelectedValue);
        rptScenic.DataSource = scenicList;
        rptScenic.DataBind();
    }
    //protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (e.CommandName.ToLower() == "validate")
    //    {
    //        //验证按钮的事件
    //        int scenicId = int.Parse(e.CommandArgument.ToString());
    //        Model.Scenic scenic = bllScenic.GetScenicById(scenicId);

    //        bllScenic.UpdateScenicInfo(scenic);
    //        BindList();
    //    }
    //}
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Scenic Scenic = (Model.Scenic)e.Item.DataItem;
            //如果已经验证通过，则隐藏按钮

            if (Scenic.CheckProgress != null)
            {
                Repeater rpt_CheckProgress = e.Item.FindControl("rpt_CheckProgress") as Repeater;
                rpt_CheckProgress.DataSource = Scenic.CheckProgress;
                rpt_CheckProgress.DataBind();
            }

            if (bllscenicadmin.GetScenicAdminByScidandtype(Scenic.Id, 7) == null)
            {
                (e.Item.FindControl("btnmake") as Button).Visible = true;
                (e.Item.FindControl("lblaccount") as Label).Visible = false;
                (e.Item.FindControl("btncz") as Button).Visible = false;
            }
            else
            {
                (e.Item.FindControl("btnmake") as Button).Visible = false;
                (e.Item.FindControl("lblaccount") as Label).Visible = true;
                (e.Item.FindControl("btncz") as Button).Visible = true;
                string account=bllscenicadmin.GetScenicAdminByScidandtype(Scenic.Id, 7).Membership.Name;
                (e.Item.FindControl("lblaccount") as Label).Text = "帐号名" + account;
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
    protected void rptScenic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "make")
        {
            int scid = int.Parse(e.CommandArgument.ToString());
            ScenicAdmin sa = new ScenicAdmin();
            sa.AdminType = ScenicAdminType.景区资料员|ScenicAdminType.检票员|ScenicAdminType.景区财务;
            sa.Scenic = bllScenic.GetScenicById(scid);
            if (!string.IsNullOrEmpty(sa.Scenic.SeoName))
            {
                string loginname = new MakeAccount().automakeaccount(sa.Scenic.SeoName);
                new BLL.BLLMembership().CreateUser("", "", "", "", loginname, "123456");
                TourMembership tour = new BLL.BLLMembership().GetMember(loginname);
                sa.Membership = tour;
                bllscenicadmin.SaveOrUpdate(sa);
            }
        }
        if (e.CommandName == "reset")
        {
            int scid = int.Parse(e.CommandArgument.ToString());
            ScenicAdmin sa = bllscenicadmin.GetScenicAdminByScidandtype(scid, 1);
            sa.Membership.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
            bllscenicadmin.SaveOrUpdate(sa);
        }
        BindList(); 
    }
}