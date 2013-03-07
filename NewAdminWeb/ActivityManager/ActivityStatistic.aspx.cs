using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ActivityManager_ActivityStatistic : System.Web.UI.Page
{
    TourActivity ta;
    BLLTourActivity bllTourActivity = new BLLTourActivity();
    BLLOrderDetail bllOd = new BLLOrderDetail();
    int totalSolidAmount, totalCheckAmount, totalAmount, ticketSolidTotal, ticketCheckTotal;
    protected void Page_Load(object sender, EventArgs e)
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        ta = bllTourActivity.GetOne(actId);
        if (!IsPostBack)
        {
            bindData();
            gridStatistic.Hidden = false; 
            gridStatistic2.Hidden = true;
            gridStatistic3.Hidden = true;
        }
    }

    protected void rblwd_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rblwd.SelectedIndex)
        {
            case 0: bindData(); gridStatistic.Hidden = false; gridStatistic2.Hidden = true; gridStatistic3.Hidden = true; break;
            case 1: bindData2(); gridStatistic.Hidden = true; gridStatistic2.Hidden = false; gridStatistic3.Hidden = true; break;
            case 2: bindData3(); gridStatistic.Hidden = true; gridStatistic2.Hidden = true; gridStatistic3.Hidden = false; break;
        }
    }

    private void bindData()
    {
        List<DateTime> listDateTime = new List<DateTime>();
        for (int i = 0; ta.BeginDate.AddDays(i) <= ta.EndDate; i++)
        {
            listDateTime.Add(ta.BeginDate.AddDays(i));
        }

        if (ta.Tickets.Count > 0)
        {
            for (int i = 0; ta.Tickets[0].BeginDate.AddDays(i) <= ta.Tickets[0].EndDate; i++)
            {
                if (listDateTime.Where(x => x == DateTime.Parse(ta.Tickets[0].BeginDate.AddDays(i).ToString()).Date).Count() == 0)
                {
                    listDateTime.Add(DateTime.Parse(ta.Tickets[0].BeginDate.AddDays(i).ToString()));
                }
            }

        }
        gridStatistic.DataSource = listDateTime;
        gridStatistic.DataBind();
        lblTotal.Text ="售出票总数" + totalSolidAmount + "       验票总数" + totalCheckAmount + "      转换率" + (totalCheckAmount * 100.0 / totalSolidAmount).ToString("f2") + "%";
    }
    private void bindData2()
    {
        gridStatistic2.DataSource = ta.Partners;
        gridStatistic2.DataBind();
        lblTotal.Text = "售出总数" + totalAmount;
    }
    private void bindData3()
    {
        gridStatistic3.DataSource = ta.Tickets;
        gridStatistic3.DataBind();
        lblTotal.Text = "售出数量" + ticketSolidTotal + "验票数量" + ticketCheckTotal;
    }


    protected void gridStatistic_RowDataBound(object sender, FineUI.GridRowEventArgs e)
    {
        if (e.DataItem != null)
        {
            DateTime dt = (DateTime)e.DataItem;
            List<ActivityTicketAssign> listAta = ta.GetActivityAssignForPartnerDate(dt).ToList();
            int solidAmount = 0, checkAmount = 0;
            foreach (ActivityTicketAssign ata in listAta)
            {
                solidAmount += ata.SoldAmount;
            }
            totalSolidAmount += solidAmount;
            Literal laSolidAmount =gridStatistic.Rows[e.RowIndex].FindControl("laSolidAmount") as Literal;
            laSolidAmount.Text = solidAmount.ToString();
            
            checkAmount = bllOd.GetTaForIdCardInActivity(ta.ActivityCode, dt).Count;
            totalCheckAmount += checkAmount;
            Literal laCheckAmount = gridStatistic.Rows[e.RowIndex].FindControl("laCheckAmount") as Literal;
            laCheckAmount.Text = checkAmount.ToString();
        }
    }
    protected void gridStatistic2_RowDataBound(object sender, FineUI.GridRowEventArgs e)
    {
        if (e.DataItem != null)
        {
            Literal laCount = gridStatistic2.Rows[e.RowIndex].FindControl("laCount") as Literal;
            ActivityPartner ap = e.DataItem as ActivityPartner;
            IList<ActivityTicketAssign> listAp = ta.GetActivityAssignForPartner(ap.PartnerCode);
            int Amount = 0;
            foreach (var ata in listAp)
            {
                Amount += ata.SoldAmount;
            }
            laCount.Text = Amount.ToString();
            totalAmount += Amount;
        }
    }
    protected void gridStatistic3_RowDataBound(object sender, FineUI.GridRowEventArgs e)
    {
        if (e.DataItem != null)
        {
            Ticket ticket = e.DataItem as Ticket;
            IList<ActivityTicketAssign> listTa = ta.GetActivityAssignForTicket(ticket.ProductCode).ToList();
            int Amount = 0;
            foreach (var ata in listTa)
            {
                Amount += ata.SoldAmount;
            }
            ticketSolidTotal += Amount;
            Literal laSolidAmount = gridStatistic3.Rows[e.RowIndex].FindControl("laTicketSolidAmount") as Literal;
            laSolidAmount.Text = Amount.ToString();

            Literal laCheckAmount = gridStatistic3.Rows[e.RowIndex].FindControl("laTicketCheckAmount") as Literal;
            int checkAmount = 0;
            IList<TicketAssign> listTicketAssign = bllOd.GetTaForIdCardInActivity(ta.ActivityCode, ticket.Id);
            foreach (var item in listTicketAssign)
            {
                checkAmount++;
            }
            ticketCheckTotal += checkAmount;
            laCheckAmount.Text = checkAmount.ToString();
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ActivityManager/ActivityList.aspx");
    }
}