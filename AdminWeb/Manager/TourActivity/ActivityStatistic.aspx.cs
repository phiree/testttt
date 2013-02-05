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
        List<OrderDetail> listOd = bllOd.GetUsedOrderDetailForIdcardInActivity(ta.ActivityCode).ToList();
        foreach (var orderdetail in listOd)
        {
            foreach (var ticketAssign in orderdetail.TicketAssignList)
            {
                if (ticketAssign.UsedTime != null&&listDateTime.Where(x=>x==DateTime.Parse(ticketAssign.UsedTime.ToString()).Date).Count()==0)
            {
                listDateTime.Add(DateTime.Parse(ticketAssign.UsedTime.ToString()));
            }
            }
        }
        rptTime.DataSource = listDateTime;
        rptTime.DataBind();

    }
    int totalSolidAmount = 0, totalCheckAmount = 0;
    protected void rptTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            TourActivity ta = bllTourActivity.GetOne(actId);
            DateTime dt = (DateTime)e.Item.DataItem;
            List<ActivityTicketAssign> listAta = ta.GetActivityAssignForPartnerDate(dt).ToList();
            int solidAmount = 0,checkAmount=0;
            foreach (ActivityTicketAssign ata in listAta)
            {
                solidAmount += ata.SoldAmount;
            }
            totalSolidAmount += solidAmount;
            Literal laSolidAmount = e.Item.FindControl("laSolidAmount") as Literal;
            laSolidAmount.Text = solidAmount.ToString();
            IList<OrderDetail> listOd= bllOd.GetUsedOrderDetailForIdcardInActivity(ta.ActivityCode).Where(x=>x.IsChildTicket==false).ToList();
            foreach (var od in listOd)
            {
                foreach (var ticketAssign in od.TicketAssignList)
                {
                    if (ticketAssign.UsedTime <= DateTime.Parse(dt.AddDays(1).Date.ToString()) && ticketAssign.UsedTime >= DateTime.Parse(dt.Date.ToString()))
                    {
                        checkAmount += 1;
                    }
                }
            }
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
}