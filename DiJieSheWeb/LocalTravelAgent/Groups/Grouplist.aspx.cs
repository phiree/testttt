using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
public partial class Groups_Grouplist : basepageDJS
{
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (!IsPostBack)
        {
            BindGroups();
        }
    }

    protected void cblState_Changed(object sender, EventArgs e)
    {
        BindGroups();
    }

    public void BindGroups()
    {
        IList<Model.DJ_TourGroup> tglist = blltg.GetGroupsForDjsAdmin((DJ_User_TourEnterprise)CurrentMember);

        TourGroupState state = (TourGroupState)Convert.ToInt16(cblState.SelectedValue);

        rptGroups.DataSource = tglist.Where(x => x.GroupState == state);
        rptGroups.DataBind();
    }

    protected void rptGroups_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string errMsg = string.Empty;
        string argId = e.CommandArgument.ToString();
        switch (e.CommandName.ToLower())
        {
            case "delete":
                DJ_TourGroup group = blltg.GetOne(new Guid(argId));

                if (DateTime.Now >= group.BeginDate)
                {
                    errMsg = "团队已经出发,不能删除";

                }
                else
                {
                    blltg.Delete(group);
                    BindGroups();
                }


                break;
        }
        lblMsg.Text = errMsg;
    }

    protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            

            Model.DJ_TourGroup group = e.Item.DataItem as Model.DJ_TourGroup;
   LinkButton lblRoute_bz = e.Item.FindControl("lblRoute_bz") as LinkButton;
            LinkButton lblMember_bz = e.Item.FindControl("lblMember_bz") as LinkButton;
            Panel pnl = e.Item.FindControl("pnlOperation") as Panel;
            if (group.GroupState== TourGroupState.正在进行|| group.GroupState == TourGroupState.已经结束)
            {
                pnl.Visible = lblMember_bz.Visible = lblRoute_bz.Visible = false;
                return;
            }
         
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