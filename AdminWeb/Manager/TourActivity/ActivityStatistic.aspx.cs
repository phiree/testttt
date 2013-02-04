using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_ActivityStatistic : System.Web.UI.Page
{
    BLLTourActivity bllTourActivity = new BLLTourActivity();
    BLLTicketAssign bllta = new BLLTicketAssign();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (RadioButtonList1.SelectedIndex)
        {
            case 0: rptTime.Visible = true; break;
        }

    }

    private void bindData()
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTourActivity.GetOne(actId);
        List<DateTime> listDateTime = new List<DateTime>();
        for (int i = 0; ta.BeginDate.AddDays(i)<=ta.EndDate; i++)
        {
            listDateTime.Add(ta.BeginDate.AddDays(i));
        }
        List<TicketAssign> listTa = bllta.GetListByActivity_Idcard_Ticket(ta.ActivityCode, "", "").ToList();
        foreach (var ticketAssign in listTa)
        {
            if (ticketAssign.UsedTime != null&&listDateTime.Where(x=>x==DateTime.Parse(ticketAssign.UsedTime.ToString()).Date).Count()==0)
            {
                listDateTime.Add(DateTime.Parse(ticketAssign.UsedTime.ToString()));
            }
        }
        rptTime.DataSource = listDateTime;
        rptTime.DataBind();

    }
}