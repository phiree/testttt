using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_activityDetail : System.Web.UI.Page
{
    BLLTourActivity bllTourActivity = new BLLTourActivity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void bindDate()
    {
        if (Request.QueryString["actId"] != null)
        {
            string actId = Request.QueryString["actId"];
            //bllTourActivity
        }
    }
}