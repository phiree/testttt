<%@ WebHandler Language="C#" Class="CheckoutHandler" %>

using System;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using Model;
using System.Linq;
using BLL;
public class CheckoutHandler : IHttpHandler
{


    BLLTicket bllTickets = new BLLTicket();
    PriceType pt = PriceType.PayOnline;
    MembershipUser mu = Membership.GetUser();
    public void ProcessRequest(HttpContext context)
    {

        if (mu == null)
        {
            ErrHandler.Redirect(ErrType.AccessDenied);
        }
        HttpRequest req = context.Request;
        HttpResponse rep = context.Response;
        /*购物车是否为空*/
        HttpCookie cookie = context.Request.Cookies["_cart"];
        IList<CartItem> cartitems = bllTickets.GetCartFromCookies();
        if (cartitems.Count == 0)
        {
            rep.Write("购物车内没有门票,不能确认订单");

            return;
        }


        string paramPriceType = req["pricetype"];
        string paramTicketAssign = req["a"].TrimEnd('_');
        /*支付*/
        int intpricetype;

        if (!int.TryParse(paramPriceType, out intpricetype))
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        pt = (PriceType)intpricetype;
        if (pt != PriceType.PreOrder && pt != PriceType.PayOnline)
        {
            context.Response.Write("<script>window.location.href='/order/orderErr.aspx';</script>");
            return;
        }
        Order order = docheck();

        if (pt == PriceType.PayOnline)
        {

            string html = DoPayment(order);
            context.Response.Write(html);
        }
        else if (pt == PriceType.PreOrder)
        {
            context.Response.Write("<script>window.location.href='/order/preordersuc.aspx';</script>");
        }


        /*end 支付*/
        /*
         清空购物车
         */

        cookie.Value = "[]";
        context.Response.Cookies.Add(cookie);

        /*指派游览者*/
        string[] arrTicketAssign = paramTicketAssign.Split('_');
        foreach (string ta in arrTicketAssign)
        {
            string[] taValues = ta.Split('-');
            int ticketId = Convert.ToInt32(taValues[0]);
            string name = taValues[1];
            string cardidNo = taValues[2];

            OrderDetail detail = order.OrderDetail.Single<OrderDetail>(x => x.TicketPrice.Ticket.Id == ticketId);
            TicketAssign modelTa = new TicketAssign();
            modelTa.IdCard = cardidNo;
            modelTa.IsUsed = false;
            modelTa.Name = name;
            modelTa.OrderDetail = detail;
            new BLLTicketAssign().SaveOrUpdate(modelTa);
            //保存常用联系人
            CommonUser cu = new CommonUser();
            //cu.User=new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey);
            //cu.Name = name;
            //cu.IdCard = cardidNo;
            new BLLCommonUser().Save((Guid)mu.ProviderUserKey, name, cardidNo);

        }



    }

    private Order docheck()
    {
        /*已有的数据
          门票/ 门票类别/
         *每张门票的数量
         *购买者
         *每个景点的游览者姓名 和 身份证号码/
         */



        Checkout checkout = new Checkout();
        checkout.BuerId = (Guid)mu.ProviderUserKey;
        checkout.PriceType = pt;

        checkout.Details = GetDetails();
        Order order = checkout.MakeOrder();

        return order;
    }
    private string DoPayment(Order order)
    {
        TourLog.LogPayment("**************准备支付订单:"+order.Id+"***************");
        BLLPayment payment = new BLLPayment(order);
        TourLog.LogPayment("跳转至支付宝开始支付:" + order.Id + "");
      
        return payment.Pay();
    }

    private List<OrderDetail> GetDetails()
    {

        IList<CartItem> cart = bllTickets.GetCartFromCookies();


        List<OrderDetail> details = new List<OrderDetail>();

        foreach (CartItem item in cart)
        {
            OrderDetail od = new OrderDetail();
            od.Quantity = item.Qty;

            Ticket t = bllTickets.GetTicket(item.TicketId);
            TicketPrice tp = t.TicketPrice.Single<TicketPrice>(x => x.PriceType == pt);
            TicketAssign ta = new TicketAssign();

            od.TicketPrice = tp;
            details.Add(od);

        }
        return details;

    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}