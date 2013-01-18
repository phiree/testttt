using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_QuZhouSpring_DateTicketAsign : System.Web.UI.Page
{
    BLLQZTicketAsign bllqz = new BLLQZTicketAsign();
    BLLQZSpringPartner bllqzPartner = new BLLQZSpringPartner();
    BLLQZPartnerTicketAsign bllqzPartnerTa = new BLLQZPartnerTicketAsign();
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
        rptAsignList.DataSource =
        rptAsignList.DataSource= bllqz.GetQzByDate(DateTime.Parse(Request.QueryString["date"]));
        rptAsignList.DataBind();
    }
    protected void rptAsignList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            QZTicketAsign qzTa= e.Item.DataItem as QZTicketAsign;
            Repeater rptPartnerList= e.Item.FindControl("rptPartnerList") as Repeater;
            rptPartnerList.DataSource = qzTa.PartnerTicketAsign;
            rptPartnerList.DataBind();
        }
    }
    protected void rptAsignList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "save")
        {
            Repeater rptPartnerList= e.Item.FindControl("rptPartnerList") as Repeater;
            int Amount = 0;
            foreach (RepeaterItem item in rptPartnerList.Items)
            {
                TextBox tbxAsignAmount = item.FindControl("tbxAsignAmount") as TextBox;
                if (tbxAsignAmount.Text == "")
                    tbxAsignAmount.Text = "0";
                Guid qzPartnerTaId = Guid.Parse((item.FindControl("hfid") as HiddenField).Value);
                QZPartnerTicketAsign qzpartnerTa= bllqzPartnerTa.GetOne(qzPartnerTaId);
                qzpartnerTa.AsignedAmount = int.Parse(tbxAsignAmount.Text);
                bllqzPartnerTa.SaveOrUpdate(qzpartnerTa);
                Amount += int.Parse(tbxAsignAmount.Text);
            }
            Guid qzTaId = Guid.Parse((e.Item.FindControl("hfTaId") as HiddenField).Value);
            QZTicketAsign qzTa = bllqz.GetOne(qzTaId);
            qzTa.Amount = Amount;
            bllqz.SaveOrUpdate(qzTa);
            bindData();
        }
    }
}