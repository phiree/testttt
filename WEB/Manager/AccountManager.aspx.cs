using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
/// <summary>
/// 账户管理:
/// 给景区管理员分配帐号.
/// 指定管理员帐号
/// </summary>
public partial class Manager_AccountManager : System.Web.UI.Page
{
    IDAL.IMembership dalMember = new DAL.DALMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUsers(1);
        }
    }


    private void BindUsers(int currentPage)
    {
        int pageIndex = currentPage;
        long totalRecord;
        IList<Model.TourMembership> users = dalMember.GetAllUsers(pageIndex-1,pager.PageSize,out totalRecord);
        pager.RecordCount = (int)totalRecord;
        rpt.DataSource = users;
        rpt.DataBind();
    }

    protected void rpt_DataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TourMembership member = e.Item.DataItem as TourMembership;
            if (string.IsNullOrWhiteSpace(member.Name)) return;
            string[] roles = Roles.GetRolesForUser(member.Name);
            Label lblRoles = e.Item.FindControl("lblRoles") as Label;
            string strRoles = string.Empty;
            foreach (string role in roles)
            {
                strRoles += role + ",";
            }
            strRoles.TrimEnd(',');
            lblRoles.Text = strRoles;
        }
    }
    protected void pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int currentPage = e.NewPageIndex;
        BindUsers(currentPage);
    }
}