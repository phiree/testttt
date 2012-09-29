using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_GroupDetail : System.Web.UI.Page
{
    //var
    const string GID = "gid";

    //var
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    string gid = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        gid = Request.QueryString[GID];
        BindGroup();
    }

    private void BindGroup()
    {
        Model.DJ_TourGroup tg = blldjs.GetGroup8gid(gid);
        lblName.Text = tg.Name;
        lblBeginDate.Text = tg.BeginDate.ToShortDateString();
        lblEndDate.Text = tg.EndDate.ToShortDateString();
        //lblGuideName.Text = tg.GuideName;
        //lblGuidePhone.Text = tg.GuidePhone;
        //lblIdCardNo.Text = tg.GuideIdCardNo;
        //lblDriverName.Text = tg.DriverName;
        //lblDriverPhone.Text = tg.DriverPhone;
        //lblCarNo.Text = tg;
        rptGrouplist.DataSource = tg.Members;
        rptGrouplist.DataBind();
    }
}