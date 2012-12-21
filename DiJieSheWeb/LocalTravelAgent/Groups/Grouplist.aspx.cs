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
        if (!IsPostBack)
        {
            NoRecord.Visible = false;
            BindGroups();
            if (Request.Cookies["select_tab"] != null)
            {
                Response.Cookies["select_tab"].Value = "0";
            }
        }
    }
    #region method

    public void BindGroups()
    {
        IList<Model.DJ_TourGroup> tglist = blltg.GetGroupsForDjsAdmin((DJ_User_TourEnterprise)CurrentMember);

        TourGroupState state = (TourGroupState)Convert.ToInt16(hfState.Value);

        rptGroups.DataSource = tglist.Where(x => x.GroupState == state);
        rptGroups.DataBind();
        if (rptGroups.Items.Count == 0)
        {
            NoRecord.Visible = true;
        }
    }

    #endregion

    #region event
    //状态选择
    protected void cblState_Changed(object sender, EventArgs e)
    {
        BindGroups();
    }

    protected void rptGroups_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string errMsg = string.Empty;
        string argId = e.CommandArgument.ToString();
        DJ_TourGroup group = blltg.GetOne(new Guid(argId));

        switch (e.CommandName.ToLower())
        {
            case "delete":

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
            case "copy":

                DJ_TourGroup newGroup = new DJ_TourGroup();
                group.CopyTo(newGroup);
                blltg.Save(newGroup);

                Response.Redirect("GroupEditBasicInfo.aspx?groupid=" + newGroup.Id, true);

                break;
        }

        ShowNotification(errMsg);
    }

    protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {


            Model.DJ_TourGroup group = e.Item.DataItem as Model.DJ_TourGroup;
            LinkButton lblRoute_bz = e.Item.FindControl("lblRoute_bz") as LinkButton;
            LinkButton lblMember_bz = e.Item.FindControl("lblMember_bz") as LinkButton;
            Label lblSuccess = e.Item.FindControl("lblSuccess") as Label;
            Panel pnl = e.Item.FindControl("pnlOperation") as Panel;
            int state = 0;
            if (group.GroupState == TourGroupState.正在进行 || group.GroupState == TourGroupState.已经结束)
            {
                pnl.Visible = lblMember_bz.Visible = lblRoute_bz.Visible = false;
                return;
            }

            if (group.Members.Count == 0)
            {
                //lblMember_bz.Text = group.Members.Count + "位团员, 请补充团员信息";
                lblMember_bz.Text = "补充成员信息";
            }
            else
            {
                state++;
            }
            lblMember_bz.PostBackUrl = "/LocalTravelAgent/Groups/GroupEditMember.aspx?groupid=" + group.Id;


            if (group.Routes.GroupBy(x => x.DayNo).Count() > group.DaysAmount)
            {
                //lblRoute_bz.Text = group.Routes.GroupBy(x => x.DayNo).Count() + "日线路, 超出计划天数" +
                //    (group.Routes.GroupBy(x => x.DayNo).Count() - group.DaysAmount) + "天";
                //lblRoute_bz.BackColor = System.Drawing.Color.Yellow;
                lblRoute_bz.Text = "补充线路信息";
            }
            else if (group.Routes.GroupBy(x => x.DayNo).Count() < group.DaysAmount)
            {
                //lblRoute_bz.Text = group.Routes.GroupBy(x => x.DayNo).Count() + "日线路, 原计划天数" +
                //    (group.DaysAmount - group.Routes.GroupBy(x => x.DayNo).Count()) + "天";
                //lblRoute_bz.BackColor = System.Drawing.Color.Aqua;
                lblRoute_bz.Text = "补充线路信息";
            }
            else
            {
                state++;
            }
            lblRoute_bz.PostBackUrl = "/LocalTravelAgent/Groups/GroupEditRoute.aspx?groupid=" + group.Id;
            if (state == 2)
            {
                lblSuccess.Text = "已完成资料录入";
            }
        }
    }

    //直接录入
    protected void Btnzjlr_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx");
    }
    //excel导入
    protected void Btnxlslr_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LocalTravelAgent/Groups/GroupInfo.aspx");
    }
    //导出
    protected void btnOutput3_Click(object sender, EventArgs e)
    {
        IList<Model.DJ_TourGroup> tglist = blltg.GetGroupsForDjsAdmin((DJ_User_TourEnterprise)CurrentMember);
        TourGroupState state = (TourGroupState)Convert.ToInt16(cblState.SelectedValue);
        var result = tglist.Where(x => x.GroupState == state);
        DataTable tblDatas = new DataTable("Datas");
        tblDatas.Columns.Add("id", Type.GetType("System.String"));
        tblDatas.Columns.Add("name", Type.GetType("System.String"));
        tblDatas.Columns.Add("time", Type.GetType("System.String"));
        tblDatas.Columns.Add("days", Type.GetType("System.String"));
        int i = 1;
        foreach (var item in result)
        {
            tblDatas.Rows.Add(new object[] { i++, item.Name, item.BeginDate.ToString("yyyy年MM月dd日"), 
                item.DaysAmount+"日游" });
        }
        ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","名称","时间","几日游"
        }, result.First().DJ_DijiesheInfo.Name+"[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "团队列表");
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGroups();
    }
}