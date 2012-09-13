﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Scenic_CheckOut : AuthPage
{

    BLLTicket bllTicket = new BLLTicket();
    BLLOrder bllOrder = new BLLOrder();
    BLLCommonUser bllCu = new BLLCommonUser();
    IList<Ticket> tickets = new List<Ticket>();

    protected void Page_Load(object sender, EventArgs e)
    {

        tickets = bllTicket.GetTicketsFromCart();
        if (tickets.Count == 0)
        {
            Server.Transfer("/order/cart.aspx");
        }
        BindTickets();
        BindContacts();
        BindAssign();

    }

    private void BindTickets()
    {
        rptCart.DataSource = tickets;
        rptCart.DataBind();
    }
    private void BindAssign()
    {
        rptAssign.DataSource = tickets;
        rptAssign.DataBind();
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
        IList<CommonUser> cu = bllCu.GetCommonUserByUserIdandidcard(CurrentMember.Id);
        rptContacts.DataSource = cu;
        rptContacts.DataBind();
    }
    /// <summary>
    /// 绑定 门票分配里的 门票列表
    /// </summary>

}
