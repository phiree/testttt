using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class LocalTravelAgent_Groups_GroupEditBasicInfo :basepageDjsGroupEdit
{
    bool IsNew = false;
    public Guid groupId = Guid.Empty;
  
    BLL.BLLDJTourGroup bllGroup = new BLLDJTourGroup();
    BLLDJRoute bllRoute = new BLLDJRoute();
    protected void Page_Load(object sender, EventArgs e)
    {


        string paramstr = Request["groupid"];
        if (!Guid.TryParse(paramstr, out groupId))
        {
            IsNew = true;
            CurrentGroup = new DJ_TourGroup();
            a_link_2.Visible = false;
            a_link_3.Visible = false;
        }
        else
        {
            CurrentGroup = bllGroup.GetOne(groupId);
            if (groupId == null)
            {
                ErrHandler.Redirect(ErrType.ParamIllegal);
            }
            if (CurrentGroup.DijiesheEditor == null)
            {
                ErrHandler.Redirect(ErrType.ObjectIsNull);
            }
            if (CurrentGroup.DJ_DijiesheInfo.Name != CurrentMember.Name)
            {
                ErrHandler.Redirect(ErrType.AccessDenied);
            }
        }

        InitWorkers();
        if (!IsPostBack)
        {
            if (!IsNew)
            {
                LoadForm();
            }

        }
    }

    private void LoadForm()
    {
        //绑定链接
        a_link_1.HRef = "/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx?groupid=" + Request["groupid"];
        a_link_2.HRef = "/LocalTravelAgent/Groups/GroupEditMember.aspx?groupid=" + Request["groupid"];
        a_link_3.HRef = "/LocalTravelAgent/Groups/GroupEditRoute.aspx?groupid=" + Request["groupid"];
        tbxName.Text = CurrentGroup.Name;
        tbxDateBegin.Text = CurrentGroup.BeginDate.ToString("yyyy-MM-dd");
        tbxDateAmount.Text = CurrentGroup.DaysAmount.ToString();
        LoadGroupWorkers();
    }
    /// <summary>
    ///勾选 团队工作人员 
    /// </summary>
    private void LoadGroupWorkers()
    {
        ListControlHelper.CheckItems(cbxDrivers, CurrentGroup.Workers.Select(x => x.Name).ToList());
        ListControlHelper.CheckItems(cbxGuides, CurrentGroup.Workers.Select(x => x.Name).ToList());
    }

  

    private void InitWorkers()
    {
        IList<DJ_Group_Worker> drivers = CurrentDJS.Drivers;
        cbxDrivers.DataTextField = "Name";
        cbxDrivers.DataValueField = "Id";
        cbxDrivers.DataSource = drivers;
       
        cbxDrivers.DataBind();

        cbxGuides.DataTextField = "Name";
        cbxGuides.DataValueField = "Id";
        IList<DJ_Group_Worker> guides = CurrentDJS.Guides;
        cbxGuides.DataSource = guides;
        cbxGuides.DataBind();
    }
    BLLDJGroup_Worker bllWorker = new BLLDJGroup_Worker();
    private void UpdateForm()
    {
        CurrentGroup.Name = tbxName.Text;
        CurrentGroup.BeginDate = Convert.ToDateTime(tbxDateBegin.Text);
        CurrentGroup.DaysAmount = Convert.ToInt32(tbxDateAmount.Text);
        CurrentGroup.EndDate = CurrentGroup.BeginDate.AddDays(CurrentGroup.DaysAmount-1);
        CurrentGroup.DJ_DijiesheInfo = CurrentDJS;
        CurrentGroup.DijiesheEditor =(DJ_User_TourEnterprise) CurrentMember;
        ///司机和导游
        foreach (ListItem item in cbxGuides.Items)
        {
            if (item.Selected)
            {
                CurrentGroup.Workers.Add(bllWorker.Get(new Guid(item.Value)));
            }
        }
        foreach (ListItem item in cbxDrivers.Items)
        {
            if (item.Selected)
            {
                CurrentGroup.Workers.Add(bllWorker.Get(new Guid(item.Value)));
            }
        }
        
      
    }

    protected void rptRoute_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        Guid routeId = Guid.Parse(e.CommandArgument.ToString());
        DJ_Route route = bllRoute.GetById(routeId);

    }

    protected void btnBasicInfo_Click(object sender, EventArgs e)
    {
         UpdateForm();
         bllGroup.Save(CurrentGroup);
        if (IsNew)
        {
            Response.Redirect("GroupEditMember.aspx?groupid=" + CurrentGroup.Id);
        }
    }

}