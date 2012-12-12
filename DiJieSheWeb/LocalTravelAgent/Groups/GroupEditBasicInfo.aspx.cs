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
    BLLWorker bllWorker = new BLLWorker();
    string addType = "1";
    string flag = "f";
    protected void Page_Load(object sender, EventArgs e)
    {
        flag=Request["flag"];
        if (flag == "t")
        {
            lblMsg.Text = "保存成功";
        }


        addType = Request["at"];
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
               // ErrHandler.Redirect(ErrType.ObjectIsNull);
            }
            if (CurrentGroup.DJ_DijiesheInfo.Name != CurrentDJS.Name)
            {
               ErrHandler.Redirect(ErrType.AccessDenied);
            }
        }

    //   
        if (!IsPostBack)
        {
            InitWorkers();
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
        IList<string> guides= bllGroupWorker.GetWorkersForGroup(CurrentGroup, DJ_GroupWorkerType.导游).Select(x=>x.DJ_Workers.Name).ToList();
        IList<string> drivers = bllGroupWorker.GetWorkersForGroup(CurrentGroup, DJ_GroupWorkerType.司机).Select(x => x.DJ_Workers.Name).ToList();
  
        ListControlHelper.CheckItems(cbxDrivers,drivers);
        ListControlHelper.CheckItems(cbxGuides,guides);

        if (!string.IsNullOrEmpty(addType))
        {
            if (addType == "1")
            {
                cbxGuides.Items[cbxGuides.Items.Count - 1].Selected = true;
            }
            else if (addType == "2")
            {
                cbxDrivers.Items[cbxDrivers.Items.Count - 1].Selected = true;
            }
        }
        
    }

  

    private void InitWorkers()
    {
        IList<DJ_Workers> drivers = CurrentDJS.Drivers;
        cbxDrivers.DataTextField = "Name";
        cbxDrivers.DataValueField = "Id";
        cbxDrivers.DataSource = drivers;
       
        cbxDrivers.DataBind();

        cbxGuides.DataTextField = "Name";
        cbxGuides.DataValueField = "Id";
        IList<DJ_Workers> guides = CurrentDJS.Guides;
        cbxGuides.DataSource = guides;
        cbxGuides.DataBind();
    }
    BLLDJGroup_Worker bllGroupWorker = new BLLDJGroup_Worker();
    private bool UpdateForm()
    {
        CurrentGroup.Name = tbxName.Text;
        CurrentGroup.BeginDate = Convert.ToDateTime(tbxDateBegin.Text);
        if (CurrentGroup.BeginDate.DayOfYear <  DateTime.Now.DayOfYear)
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(),"begindayerr",  "alert('开始时间不能小于当天时间');",true);
            return false;
        }
        CurrentGroup.DaysAmount = Convert.ToInt32(tbxDateAmount.Text);
        CurrentGroup.EndDate = CurrentGroup.BeginDate.AddDays(CurrentGroup.DaysAmount-1);
        CurrentGroup.DJ_DijiesheInfo = CurrentDJS;
        CurrentGroup.DijiesheEditor =(DJ_User_TourEnterprise) CurrentMember;
        ///司机和导游
        bool hasSelectGuide = false;
        bllGroupWorker.DeleteFromGroup(CurrentGroup);
        CurrentGroup.Workers.Clear();
       // bllGroup.Save(CurrentGroup);
        foreach (ListItem item in cbxGuides.Items)
        {
           
            if (item.Selected)
            {
                Model.DJ_Group_Worker gw = new DJ_Group_Worker();
                hasSelectGuide = true;
                DJ_Workers worker = bllWorker.GetOne(new Guid(item.Value));
                gw.DJ_Workers = worker;
                gw.DJ_TourGroup = CurrentGroup;
                bllGroupWorker.Save(gw);
                //CurrentGroup.Workers.Add(bllGroupWorker.Get(new Guid(item.Value)));
            }
        }
        ///两个方法应该合并.
        foreach (ListItem item in cbxDrivers.Items)
        {
            if (item.Selected)
            {
                Model.DJ_Group_Worker gw = new DJ_Group_Worker();
                hasSelectGuide = true;
                DJ_Workers worker = bllWorker.GetOne(new Guid(item.Value));
                gw.DJ_Workers = worker;
                gw.DJ_TourGroup = CurrentGroup;
                bllGroupWorker.Save(gw);
            }
        }
        if (hasSelectGuide == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mustselectguide", "alert('必须指定导游');", true);

            return false;
        }
        
       

        return true;
    }

    protected void rptRoute_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        Guid routeId = Guid.Parse(e.CommandArgument.ToString());
        DJ_Route route = bllRoute.GetById(routeId);

    }

    protected void btnBasicInfo_Click(object sender, EventArgs e)
    {
        if (!UpdateForm())
        {
            BLLLog.Log("更新团队基本信息失败", 1, "basicinfo");
            return;
        }
        
         bllGroup.Save(CurrentGroup);
         
         Response.Redirect("GroupEditBasicInfo.aspx?flag=t&groupid=" + CurrentGroup.Id);
       
        
        lblMsg.Text = "保存成功";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('修改成功')", true);
    }

}