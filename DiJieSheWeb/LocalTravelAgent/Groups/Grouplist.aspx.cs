using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Groups_Grouplist : System.Web.UI.Page
{
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroups();
        }
    }

    public void BindGroups()
    {
        IList<Model.DJ_TourGroup> tglist = blltg.GetTourGroupByAll();
        rptGroups.DataSource = tglist.Where(x=>x.EndDate>DateTime.Now);
        rptGroups.DataBind();
    }

    protected void rptGroups_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            LinkButton lkbtnSort = (LinkButton)e.Item.FindControl(e.CommandName.Trim());
            if (ViewState[e.CommandName.Trim()] == null)
            {
                ViewState[e.CommandName.Trim()] = "ASC";
                lkbtnSort.Text = lkbtnSort.Text + "↑";
            }
            else
            {
                if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
                {
                    ViewState[e.CommandName.Trim()] = "DESC";
                    if (lkbtnSort.Text.IndexOf("↑") != -1)
                        lkbtnSort.Text = lkbtnSort.Text.Replace("↑", "↓");
                    else
                        lkbtnSort.Text = lkbtnSort.Text + "↓";
                }
                else
                {
                    ViewState[e.CommandName.Trim()] = "ASC";
                    if (lkbtnSort.Text.IndexOf("↓") != -1)
                        lkbtnSort.Text = lkbtnSort.Text.Trim().Replace("↓", "↑");
                    else
                        lkbtnSort.Text = lkbtnSort.Text + "↑";
                }
            }
            ViewState["text"] = lkbtnSort.Text;
            ViewState["id"] = e.CommandName.Trim();
            IList<Model.DJ_TourGroup> tglist = blltg.GetTourGroupByAll();
            switch (e.CommandName.Trim())
            {
                case "lbname":
                    if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
                        tglist = tglist.OrderBy(x => x.Name).ToList();
                    else
                        tglist = tglist.OrderByDescending(x => x.Name).ToList();
                    break;
                case "lbdate":
                    if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
                        tglist = tglist.OrderBy(x => x.BeginDate).ToList();
                    else
                        tglist = tglist.OrderByDescending(x => x.BeginDate).ToList();
                    break;
                case "lbdays":
                    if (ViewState[e.CommandName.Trim()].ToString().Trim() == "ASC")
                        tglist = tglist.OrderBy(x => x.DaysAmount).ToList();
                    else
                        tglist = tglist.OrderByDescending(x => x.DaysAmount).ToList();
                    break;
            }
            rptGroups.DataSource = tglist;
            rptGroups.DataBind();
        }
    }

    protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (ViewState["id"] != null)
            {
                LinkButton lkbtnSort = (LinkButton)e.Item.FindControl(ViewState["id"].ToString().Trim());
                lkbtnSort.Text = ViewState["text"].ToString();
            }
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.DJ_TourGroup group = e.Item.DataItem as Model.DJ_TourGroup;

            LinkButton lblMember_bz = e.Item.FindControl("lblMember_bz") as LinkButton;
            if (group.Members.Count == 0)
            {
                lblMember_bz.Text = group.Members.Count + "位团员, 请补充团员信息";
                lblMember_bz.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                lblMember_bz.Text = group.Members.Count + "位团员√";
            }
            lblMember_bz.PostBackUrl = "/LocalTravelAgent/Groups/GroupEditMember.aspx?groupid=" + group.Id;

            LinkButton lblRoute_bz = e.Item.FindControl("lblRoute_bz") as LinkButton;
            if (group.Routes.GroupBy(x => x.DayNo).Count() > group.DaysAmount)
            {
                lblRoute_bz.Text = group.Routes.GroupBy(x => x.DayNo).Count() + "日线路, 超出计划天数" +
                    (group.Routes.GroupBy(x => x.DayNo).Count() - group.DaysAmount) + "天";
                lblRoute_bz.BackColor = System.Drawing.Color.Yellow;
            }
            else if (group.Routes.GroupBy(x => x.DayNo).Count() < group.DaysAmount)
            {
                lblRoute_bz.Text = group.Routes.GroupBy(x => x.DayNo).Count() + "日线路, 原计划天数" +
                    (group.DaysAmount - group.Routes.GroupBy(x => x.DayNo).Count()) + "天";
                lblRoute_bz.BackColor = System.Drawing.Color.Aqua;
            }
            else
            {
                lblRoute_bz.Text = group.Routes.GroupBy(x => x.DayNo).Count() + "日线路√";
            }
            lblRoute_bz.PostBackUrl = "/LocalTravelAgent/Groups/GroupEditRoute.aspx?groupid=" + group.Id;
        }
    }
}