﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Model;
using BLL;
public partial class Scenic_CheckOut : AuthPage
{

    BLLTicket bllTicket = new BLLTicket();
    BLLScenic bllScenic = new BLLScenic();
    BLLOrder bllOrder = new BLLOrder();
    BLLCommonUser bllCu = new BLLCommonUser();
    IList<Ticket> tickets = new List<Ticket>();
    BLLTicketAssign bllTicketAssign = new BLLTicketAssign();

    protected void Page_Load(object sender, EventArgs e)
    {
        //为抢票设定时间
        if(DateTime.Now.Hour<10)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('今日抢票未开始,请在10点之后进行抢票!');window.location='/'", true);
            return;
        }

        tickets = bllTicket.GetTicketsFromCart();
        if (tickets.Count == 0)
        {
            Server.Transfer("/order/cart.aspx");
        }

        //如果只有一张票,而且价格等于0,则隐藏付款方式
        if (tickets.Count == 1)
        {
            Ticket t = tickets[0];
            if (t.GetPrice(PriceType.PreOrder )== 0 && t.GetPrice(PriceType.PayOnline) == 0)
            {
                divPaymentChoose.Style.Add( HtmlTextWriterStyle.Display,"none");
            }
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
            //参加活动的门票
            if (t.TourActivity != null)
            {
                string errmsg;
                if (!t.TourActivity.CheckBuyTime(out errmsg))
                {
                    CommonLibrary.Notification.Show(this,"规则检验",errmsg,"/");
                    return;
                }
                if (!t.TourActivity.CheckBuyHour(out errmsg))
                {
                    CommonLibrary.Notification.Show(this, "规则检验", errmsg, "/");
                    return;
                }
            }

            Literal liPriceOrder = e.Item.FindControl("liPriceOrder") as Literal;
            Literal liPriceOnline = e.Item.FindControl("liPriceOnline") as Literal;
            liPriceOrder.Text = t.GetPrice(PriceType.PreOrder).ToString("0");
            liPriceOnline.Text = t.GetPrice(PriceType.PayOnline).ToString("0");
            HtmlAnchor hrefScenic = e.Item.FindControl("hrefScenic") as HtmlAnchor;
            hrefScenic.HRef = bllScenic.BuildScenicLink( t.Scenic);
            System.Web.UI.HtmlControls.HtmlInputText inputQty = e.Item.FindControl("inputQty") as System.Web.UI.HtmlControls.HtmlInputText;
            //inputQty.
        }
    }

    /*常用联系人*/
    private void BindContacts()
    {
        IList<CommonUser> cu = bllCu.GetCommonUserByUserId(CurrentMember.Id);
        rptContacts.DataSource = cu;
        rptContacts.DataBind();
    }
    /// <summary>
    /// 绑定 门票分配里的 门票列表
    /// </summary>

}
