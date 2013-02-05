using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_TourActivity_AsByDate : System.Web.UI.Page
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
        TourActivity ta = bllTa.GetOne(actId);
        rptDt.DataSource = ta.Tickets;
        rptDt.DataBind();

    }
    protected void rptDt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTa.GetOne(actId);
        if (e.Item.ItemType == ListItemType.Header)
        {
            //Literal laPartnerName = e.Item.FindControl("laPartnerName") as Literal;
            //foreach (var partner in ta.Partners)
            //{
            //    string tdpartner=
            //}
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //Literal 
            //Guid actId = Guid.Parse(Request.QueryString["actId"]);
            //TourActivity ta = bllTa.GetOne(actId);
            //Ticket t = e.Item.DataItem as Ticket;
            //foreach (var partner in ta.Partners)
            //{
                
            //}
        }
    }
}