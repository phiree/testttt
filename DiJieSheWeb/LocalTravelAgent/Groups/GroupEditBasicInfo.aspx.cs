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
    private Guid groupId;
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
        tbxDateEnd.Text = Group.EndDate.ToShortDateString();
        tbxGroupNo.Text = Group.No;

    }
    private void UpdateForm()
    {
        Group.Name = tbxName.Text;
        Group.BeginDate = Convert.ToDateTime(tbxDateBegin.Text);
        Group.EndDate = Convert.ToDateTime(tbxDateEnd.Text);
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