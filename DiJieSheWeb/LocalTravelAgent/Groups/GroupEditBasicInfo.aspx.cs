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
    DJ_TourGroup Group;
    BLL.BLLDJTourGroup bllGroup = new BLLDJTourGroup();
    BLLDJ_Route bllRoute = new BLLDJ_Route();
    protected void Page_Load(object sender, EventArgs e)
    {


        string paramstr = Request["groupid"];
        if (!Guid.TryParse(paramstr, out groupId))
        {
            IsNew = true;
            Group = new DJ_TourGroup();
            pnlLinks.Visible = false;

        }
        else
        {
            Group = bllGroup.GetTourGroupById(groupId);
            if (groupId == null)
            {
                ErrHandler.Redirect(ErrType.ParamIllegal);
            }
        }

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
        tbxName.Text = Group.Name;
        tbxDateBegin.Text = Group.BeginDate.ToString("yyyy-MM-dd");
        tbxDateAmount.Text = Group.DaysAmount.ToString();

    }
    private void InitWorkers()
    {
        IList<DJ_Group_Worker> works = Group.Workers;
        IList<DJ_Group_Worker> drivers = works.Where(x => x.WorkerType == DJ_GroupWorkerType.司机).ToList<DJ_Group_Worker>();
        cbxDrivers.DataSource = drivers;
        cbxDrivers.DataTextField = "Name";
        cbxDrivers.DataValueField = "Id";
        cbxDrivers.DataBind();

        IList<DJ_Group_Worker> guides = works.Where(x => x.WorkerType == DJ_GroupWorkerType.导游).ToList<DJ_Group_Worker>();
        cbxGuides.DataSource = guides;
        cbxGuides.DataTextField = "Name";
        cbxGuides.DataValueField = "Id";
        cbxGuides.DataBind();
    }
    
    private void UpdateForm()
    {
        Group.Name = tbxName.Text;
        Group.BeginDate = Convert.ToDateTime(tbxDateBegin.Text);
        Group.DaysAmount = Convert.ToInt32(tbxDateAmount.Text);
        Group.EndDate=
        Group.No = tbxGroupNo.Text;
        Group.DJ_DijiesheInfo = CurrentDJS;
      
    }

    protected void rptRoute_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        Guid routeId = Guid.Parse(e.CommandArgument.ToString());
        DJ_Route route = bllRoute.GetById(routeId);

    }

    protected void btnBasicInfo_Click(object sender, EventArgs e)
    {
        UpdateForm();
      bllGroup.Save(Group);
        if (IsNew)
        {
            Response.Redirect("GroupEditMember.aspx?groupid=" + Group.Id);
        }
    }

}