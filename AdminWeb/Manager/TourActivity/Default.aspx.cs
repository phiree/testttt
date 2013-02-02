using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_Default : System.Web.UI.Page
{
    BLLTourActivity bllTourActivity = new BLLTourActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        rptActive.DataSource= bllTourActivity.GetAll<TourActivity>();
        rptActive.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Manager/TourActivity/activityDetail.aspx");
    }
}