using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_GroupEdit : System.Web.UI.Page
{
    BLL.BLLDijiesheInfo blldjs = new BLL.BLLDijiesheInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        BindDJS();
    }

    private void BindDJS()
    {
        IList<Model.DJ_DijiesheInfo> djslist=blldjs.GetDjs8all();
        ddlDJS.DataSource = djslist;
        ddlDJS.DataTextField = "Name";
        ddlDJS.DataValueField = "Id";
        ddlDJS.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        Model.DJ_TourGroup tg = new Model.DJ_TourGroup();
        //tg.Name = txtGroupname.Text;
        //tg.BeginDate = DateTime.Parse(txtBegintime.Text);
        //tg.EndDate = DateTime.Parse(txtGroupname.Text);
        //tg.GuideName = txtGuidename.Text;
        //tg.GuidePhone = txtGuidephone.Text;
        //tg.CarNo = txtCarid.Text;
        //tg.AdultsAmount = int.Parse(txtAdultnum.Text);
        //tg.ChildrenAmount = int.Parse(txtChildnum.Text);
        
        blldjs.AddBasicinfo(null, txtGroupname.Text, Calendar1.SelectedDate,
            Calendar2.SelectedDate, int.Parse(txtDays.Text), int.Parse(txtAdultnum.Text), int.Parse(txtChildnum.Text));
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LocalTravelAgent/GroupMemberid.aspx");
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtBegintime.Text = Calendar1.SelectedDate.ToString();
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtEndtime.Text = Calendar2.SelectedDate.ToString();
    }
}