using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Scenic_CheckOut :  AuthPage
{
    
    BLLTicket bllTicket = new BLLTicket();
    BLLOrder bllOrder = new BLLOrder();
    List<Ticket> Tickets = new List<Ticket>();



    protected void Page_Load(object sender, EventArgs e)
    {
        //
        GetTicketListFromCookies();
        BuildTicketList();
        BindTickets();
    }
    IList<CartItem> CartItems = new List<CartItem>();
    private void GetTicketListFromCookies()
    {
        string cookieName = "_cart";
        HttpCookie cookie = Request.Cookies[cookieName];
        string cartJson = Server.UrlDecode(cookie.Value);
        Newtonsoft.Json.Linq.JArray arrya = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(cartJson);

        CartItems = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<CartItem>>(cartJson);

    }

    private void BindTickets()
    {
        rptCart.DataSource = Tickets;
        rptCart.DataBind();
    }

    private void BuildTicketList()
    {


        foreach (CartItem item in CartItems)
        {
            OrderDetail od = new OrderDetail();
            Ticket ti = bllTicket.GetTicketByscId(item.TicketId)[0];
            Tickets.Add(ti);
        }

    }

    protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Ticket t = e.Item.DataItem as Ticket;
            Literal liPriceOrder = e.Item.FindControl("liPriceOrder") as Literal;
            Literal liPriceOnline = e.Item.FindControl("liPriceOnline") as Literal;
            liPriceOrder.Text = t.GetPrice(PriceType.PreOrder).ToString("0");
            liPriceOnline.Text = t.GetPrice(PriceType.PayOnline).ToString("0");

            System.Web.UI.HtmlControls.HtmlInputText inputQty = e.Item.FindControl("inputQty") as System.Web.UI.HtmlControls.HtmlInputText;
            //inputQty.
        }
    }

    /*常用联系人*/
    private void BindContacts()
    {

    }
}
