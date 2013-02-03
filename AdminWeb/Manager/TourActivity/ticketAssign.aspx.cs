using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_ticketAssign : System.Web.UI.Page
{
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
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta=bllTa.GetOne(actId);
        DateTime beginDate=ta.BeginDate;
        DateTime endDate=ta.EndDate;
        List<DateTime> listDate = new List<DateTime>();
        for (int i = 0;  beginDate.AddDays(i)<=endDate; i++)
        {
            listDate.Add(beginDate.AddDays(i));
        }
        rptTime.DataSource = listDate;
        rptTime.DataBind();
    }
    protected void rptTime_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "fp")
        {

        }
    }
}