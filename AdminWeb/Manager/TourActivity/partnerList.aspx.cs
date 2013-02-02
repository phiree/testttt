using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_TourActivity_partnerList : System.Web.UI.Page
{
    BLLActivityPartner bllAp = new BLLActivityPartner();
    BLLTourActivity bllTa = new BLLTourActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }


    private void bindData()
    {
        Guid actId=Guid.Parse(Request.QueryString["actId"]);
        rptPartner.DataSource = bllTa.GetOne(actId);
        rptPartner.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/manager/touractivity/partnerEdit.aspx");

    }
}