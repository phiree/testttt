using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class search_Default : System.Web.UI.Page
{
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLScenic bllscenic = new BLLScenic();
    BLLTicket bllTicket = new BLLTicket();
    public string q;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindTicketList();
    }
    private void BindTicketList()
    {
        q = Request["q"];
        int pageIndex = GetPageIndex();
        int pageSize = pagerGot.PageSize;
        int totalRecord;

        IList<Model.Ticket> ticketList = bllTicket.Search(q, pageIndex, pageSize, out totalRecord);
        rptItems.DataSource = ticketList;
        rptItems.DataBind();
        pagerGot.RecordCount = totalRecord;
        lblTotalRecord.Text = totalRecord.ToString();
    }
    protected void rptscenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Ticket t = e.Item.DataItem as Model.Ticket;
            decimal priceNormal = t.GetPrice(Model.PriceType.Normal);
            decimal priceOnline = t.GetPrice(Model.PriceType.PayOnline);
            Literal liPriceNormal = e.Item.FindControl("liPriceNormal") as Literal;
            Literal liPriceOnline = e.Item.FindControl("liPriceOnline") as Literal;
            liPriceNormal.Text = priceNormal.ToString("0");
            liPriceOnline.Text = priceOnline.ToString("0");
        }
    }
    private int GetPageIndex()
    {
        string paramPageIndex = Request[pagerGot.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
}