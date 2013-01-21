using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Configuration;

public partial class Manager_QuZhouSpring_TicketStatistics : System.Web.UI.Page
{
    public int allTicketCount;
    BLLQZSpringPartner bllQZSp = new BLLQZSpringPartner();
    BLLQZTicketAsign bllQZTa = new BLLQZTicketAsign();
    BLLTicket bllTicket = new BLLTicket();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        allTicketCount = bllQZTa.getAllTicketCount();
        rptDateList.DataSource = GetAllTicket();
        rptDateList.DataBind();
    }
    protected void rptDateList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Literal partnerHeadList = e.Item.FindControl("partnerHeadList") as Literal;
            IList<QZSpringPartner> listQZSp = bllQZSp.GetAll<QZSpringPartner>();
            partnerHeadList.Text = "";
            foreach (var sp in listQZSp)
            {
                partnerHeadList.Text += "<td>";
                partnerHeadList.Text += sp.Name;
                partnerHeadList.Text += "</td>";
            }
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal partnerCountList = e.Item.FindControl("partnerCountList") as Literal;
            Ticket t = e.Item.DataItem as Ticket;
            List<int> listCount= bllQZTa.getPartnerStatisticsByTicketId(t.Id);
            partnerCountList.Text = "";
            foreach (var item in listCount)
            {
                partnerCountList.Text += "<td>";
                partnerCountList.Text += item.ToString();
                partnerCountList.Text += "</td>";
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            List<int> listCount = bllQZTa.getPartnerStatisticsByTicketId(0);
            Literal partnerFooterList = e.Item.FindControl("partnerFooterList") as Literal;
            partnerFooterList.Text = "";
            foreach (var item in listCount)
            {
                partnerFooterList.Text += "<td>";
                partnerFooterList.Text += item.ToString();
                partnerFooterList.Text += "</td>";
            }
        }
    }

    private List<Ticket> GetAllTicket()
    {
        string[] ticketId = ConfigurationManager.AppSettings["ticketId"].Split(',');
        List<Ticket> listTicket = new List<Ticket>();
        for (int i = 0; i < ticketId.Length; i++)
        {
            listTicket.Add(bllTicket.GetTicket(int.Parse(ticketId[i])));
        }
        return listTicket;
    }
}