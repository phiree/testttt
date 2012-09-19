using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_GroupEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        Model.DJ_TourGroup tg = new Model.DJ_TourGroup();
        tg.Name = txtGroupname.Text;
        tg.BeginDate = DateTime.Parse(txtBegintime.Text);
        tg.EndDate = DateTime.Parse(txtGroupname.Text);
        tg.GuideName = txtGuidename.Text;
        tg.GuidePhone = txtGuidephone.Text;
        tg.CarNo = txtCarid.Text;
        tg.AdultsAmount = int.Parse(txtAdultnum.Text);
        tg.ChildrenAmount = int.Parse(txtChildnum.Text);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LocalTravelAgent/GroupMemberid.aspx");
    }
}