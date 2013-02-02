using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Configuration;

public partial class Manager_QuZhouSpring_DateTicketAsign : System.Web.UI.Page
{
    BLLQZTicketAsign bllqz = new BLLQZTicketAsign();
    BLLQZSpringPartner bllqzPartner = new BLLQZSpringPartner();
    BLLQZPartnerTicketAsign bllqzPartnerTa = new BLLQZPartnerTicketAsign();
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
        laDate.Text = Request.QueryString["date"];
        List<QZTicketAsign> listTa = bllqz.GetQzByDate(DateTime.Parse(Request.QueryString["date"])).ToList();
        //如果此时在config中添加了新的门票，则需添加对应的qzta
        string[] ticketId = ConfigurationManager.AppSettings["ticketId"].Split(',');
        List<Ticket> listTicket = new List<Ticket>();
        for (int i = 0; i < ticketId.Length; i++)
        {
            listTicket.Add(bllTicket.GetTicket(int.Parse(ticketId[i])));
        }
        rptAsignList.DataSource = bllqz.GetQzByDate(DateTime.Parse(Request.QueryString["date"]), listTicket);
        rptAsignList.DataBind();
    }
    protected void rptAsignList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            QZTicketAsign qzTa= e.Item.DataItem as QZTicketAsign;
            Repeater rptPartnerList= e.Item.FindControl("rptPartnerList") as Repeater;
            rptPartnerList.DataSource = bllqz.GetAllQzPartnerTa(qzTa);
            rptPartnerList.DataBind();
        }
    }
    protected void rptPartnerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var rpt = (Repeater)sender;
        var ptlist = (List<QZPartnerTicketAsign>)rpt.DataSource;
        if (e.Item.ItemType == ListItemType.Footer)
        {
            var lblMedia = (Label)e.Item.FindControl("lblMedia");
            if (ptlist[0].QZTicketAsign == null)
            {
                lblMedia.Text = "0";
            }
            else
            {
                lblMedia.Text =Math.Abs((int.Parse(bllqz.GetTotalTickets(DateTime.Parse(Request.QueryString["date"]), ptlist[0].QZTicketAsign.Ticket.Id).ToString()) -
                    ptlist[0].SoldAmount - ptlist[1].SoldAmount)).ToString();
            }
        }
    }
    protected void rptAsignList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "save")
        {
            Guid qzTaId = Guid.Parse((e.Item.FindControl("hfTaId") as HiddenField).Value);
            QZTicketAsign qzTa = bllqz.GetOne(qzTaId);
            Repeater rptPartnerList= e.Item.FindControl("rptPartnerList") as Repeater;
            int Amount = 0;
            foreach (RepeaterItem item in rptPartnerList.Items)
            {
                TextBox tbxAsignAmount = item.FindControl("tbxAsignAmount") as TextBox;
                if (tbxAsignAmount.Text == "")
                    tbxAsignAmount.Text = "0";

                DateTime dateTime=DateTime.Parse(Request.QueryString["date"]);
                Guid partnerId=Guid.Parse((item.FindControl("hfPartnerId") as HiddenField).Value);
                int ticketId=qzTa.Ticket.Id;
                QZPartnerTicketAsign qzpartnerTa = bllqzPartnerTa.GetOneByDateAndPartnerIdAndTicketId(dateTime, partnerId, ticketId);
                if (qzpartnerTa == null)
                    qzpartnerTa = new QZPartnerTicketAsign();
                qzpartnerTa.Partner = bllqzPartner.GetOne(partnerId);
                qzpartnerTa.AsignedAmount = int.Parse(tbxAsignAmount.Text);
                qzpartnerTa.QZTicketAsign = qzTa;
                bllqzPartnerTa.SaveOrUpdate(qzpartnerTa);
                Amount += int.Parse(tbxAsignAmount.Text);
            }
            
            qzTa.Amount = Amount;
            bllqz.SaveOrUpdate(qzTa);
            //这里需要征询袁飞
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "window.location=window.location", true);
        }
    }
}