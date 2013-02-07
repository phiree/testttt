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
    BLLOrderDetail bllOd = new BLLOrderDetail();
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
            case 0: bindData(); rptTime.Visible = true; rptPartner.Visible = false; rptTickets.Visible = false; break;
            case 1: bindData2(); rptTime.Visible = false; rptPartner.Visible = true; rptTickets.Visible = false; break;
            case 2: bindData3(); rptTime.Visible = false; rptPartner.Visible = false; rptTickets.Visible = true; break;
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

        if (ta.Tickets.Count > 0)
        {
            for (int i = 0;  ta.Tickets[0].BeginDate.AddDays(i)<=ta.Tickets[0].EndDate; i++)
            {
                if (listDateTime.Where(x => x == DateTime.Parse(ta.Tickets[0].BeginDate.AddDays(i).ToString()).Date).Count() == 0)
                {
                    listDateTime.Add(DateTime.Parse(ta.Tickets[0].BeginDate.AddDays(i).ToString()));
                }
            }
           
        }
        rptTime.DataSource = listDateTime;
        rptTime.DataBind();

    }
    int totalSolidAmount = 0, totalCheckAmount = 0;
    protected void rptTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTourActivity.GetOne(actId);
        
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DateTime dt = (DateTime)e.Item.DataItem;
            List<ActivityTicketAssign> listAta = ta.GetActivityAssignForPartnerDate(dt).ToList();
            int solidAmount = 0, checkAmount = 0;
            foreach (ActivityTicketAssign ata in listAta)
            {
                solidAmount += ata.SoldAmount;
            }
            totalSolidAmount += solidAmount;
            Literal laSolidAmount = e.Item.FindControl("laSolidAmount") as Literal;
            laSolidAmount.Text = solidAmount.ToString();
            //IList<OrderDetail> listOd = bllOd.GetUsedOrderDetailForIdcardInActivity(ta.ActivityCode).Where(x => x.IsChildTicket == false).ToList();
            //foreach (var od in listOd)
            //{
            //    foreach (var ticketAssign in od.TicketAssignList)
            //    {
            //        if (ticketAssign.UsedTime <= DateTime.Parse(dt.AddDays(1).Date.ToString()) && ticketAssign.UsedTime >= DateTime.Parse(dt.Date.ToString()))
            //        {
            //            checkAmount += 1;
            //        }
            //    }
            //}
            checkAmount = bllOd.GetTaForIdCardInActivity(ta.ActivityCode, dt).Count;
            totalCheckAmount += checkAmount;
            Literal laCheckAmount = e.Item.FindControl("laCheckAmount") as Literal;
            laCheckAmount.Text = checkAmount.ToString();
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laTotalSolidAmount = e.Item.FindControl("laTotalSolidAmount") as Literal;
            Literal laTotalCheckAmount = e.Item.FindControl("laTotalCheckAmount") as Literal;
            laTotalSolidAmount.Text = totalSolidAmount.ToString();
            laTotalCheckAmount.Text = totalCheckAmount.ToString();
            Literal laBfb = e.Item.FindControl("laBfb") as Literal;
            laBfb.Text = (totalCheckAmount * 100.0 / totalSolidAmount).ToString("f2")+"%";
        }
    }

    private void bindData2()
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTourActivity.GetOne(actId);
        rptPartner.DataSource = ta.Partners;
        rptPartner.DataBind();
    }


    int totalAmount = 0;
    protected void rptPartner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laCount = e.Item.FindControl("laCount") as Literal;
            ActivityPartner ap=e.Item.DataItem as ActivityPartner;
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            TourActivity ta = bllTourActivity.GetOne(actId);
            IList<ActivityTicketAssign> listAp= ta.GetActivityAssignForPartner(ap.PartnerCode);
            int Amount = 0;
            foreach (var ata in listAp)
            {
                Amount += ata.SoldAmount;
            }
            laCount.Text = Amount.ToString();
            totalAmount += Amount;
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laTotalCount = e.Item.FindControl("laTotalCount") as Literal;
            laTotalCount.Text = totalAmount.ToString();
        }
    }

    protected void bindData3()
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTourActivity.GetOne(actId);
        rptTickets.DataSource = ta.Tickets;
        rptTickets.DataBind();
    }
    int ticketSolidTotal = 0, ticketCheckTotal = 0;
    protected void rptTickets_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            TourActivity ta = bllTourActivity.GetOne(actId);
            Ticket ticket = e.Item.DataItem as Ticket;
            IList<ActivityTicketAssign> listTa = ta.GetActivityAssignForTicket(ticket.ProductCode).ToList();
            int Amount = 0;
            foreach (var ata in listTa)
            {
                Amount += ata.SoldAmount;
            }
            ticketSolidTotal += Amount;
            Literal laSolidAmount = e.Item.FindControl("laSolidAmount") as Literal;
            laSolidAmount.Text = Amount.ToString();

            Literal laCheckAmount = e.Item.FindControl("laCheckAmount") as Literal;
            int checkAmount = 0;
            IList<TicketAssign> listTicketAssign= bllOd.GetTaForIdCardInActivity(ta.ActivityCode,ticket.Id);
            foreach (var item in listTicketAssign)
            {
                checkAmount++;
            }
            ticketCheckTotal += checkAmount;
            laCheckAmount.Text = checkAmount.ToString();
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laSolidTotalAmount = e.Item.FindControl("laSolidTotalAmount") as Literal;
            Literal laCheckTotalAmount = e.Item.FindControl("laCheckTotalAmount") as Literal;
            laSolidTotalAmount.Text = ticketSolidTotal.ToString();
            laCheckTotalAmount.Text = ticketCheckTotal.ToString();
        }
    }
}