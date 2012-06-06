using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
/// <summary>
/// 页面功能:
/// 1 购物车内的门票.
/// 2 分配门票
/// 
/// </summary>
public partial class Scenic_Cart : System.Web.UI.Page
{
    /*购物车*/
    BLLTicket bllTicket = new BLLTicket();
    BLLOrder bllOrder = new BLLOrder();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //


        BindTickets();
    }
 

    private void BindTickets()
    {
        rptCart.DataSource = bllTicket.GetTicketsFromCart();
        rptCart.DataBind();
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
