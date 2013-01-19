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
    BLLMembership bllMembership = new BLLMembership();
    public void ProcessRequest(HttpContext context)
    {

        if (mu == null)
        {
            ErrHandler.Redirect(ErrType.AccessDenied);
        }
        TourMembership tourMembership = bllMembership.GetUserByUserId((Guid)mu.ProviderUserKey);
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
            TourLog.LogInstance.Error("不是有效的支付方式:" + pt);

            context.Response.Write("<script>window.location.href='/order/orderErr.aspx';</script>");
            return;
        }

        //如果是衢州抢票 需要调用接口
        string thisTopic = req["topic"];
        string[] arrTicketAssign = paramTicketAssign.Split('_');
        if (thisTopic == "quzhou")
        {
            BLLQZTicketSeller qzSeller = new BLLQZTicketSeller();

            if (arrTicketAssign.Length != 1)
            {
                TourLog.LogInstance.Error("衢州门票派送活动,每个订单只能分配一个身份证号.现在的分配数量:" + arrTicketAssign.Length);
                context.Response.Write("<script>window.location.href='/order/orderErr.aspx';</script>");
                return;
            }
            string[] taValues = arrTicketAssign[0].Split('-');
            int ticketId = Convert.ToInt32(taValues[0]);
                string name = taValues[1];
                string cardidNo = taValues[2];
                Ticket t = bllTickets.GetTicket(Convert.ToInt32(ticketId));

             string result=  qzSeller.SellTicket("tourol.cn",tourMembership, cardidNo, t.ProductCode, 1, "");
             if (result != "T")
             {
                 string qzErrmsg = string.Empty;
                 if (result.Split('|').Length != 2)
                 {
                     qzErrmsg = result;
                 }
                 else
                 {
                     qzErrmsg = result.Split('|')[1];
                 }
                 
                 context.Response.Write("<script>window.location.href='/order/QuZhouorderFail.aspx?msg="+qzErrmsg+"';</script>");
             }
             else
             {
                 context.Response.Write("<script>window.location.href='/order/QuZhouorderSuc.aspx';</script>");
             }
            //正常购票流程
        }
        else
        {
            Model.Order order = docheck();

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
          

            /*指派游览者*/

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
              
               

            }
            /*
           清空购物车
           */

            cookie.Value = "[]";
            context.Response.Cookies.Add(cookie);
        }
        //保存常用联系人
        foreach (string ta in arrTicketAssign)
        {
            string[] taValues = ta.Split('-');
            int ticketId = Convert.ToInt32(taValues[0]);
            string name = taValues[1];
            string cardidNo = taValues[2];
            CommonUser cu = new CommonUser();
            //cu.User=new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey);
            //cu.Name = name;
            //cu.IdCard = cardidNo;
            new BLLCommonUser().Save((Guid)mu.ProviderUserKey, name, cardidNo);
        }



    }
   // private

    private Model.Order docheck()
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
        Model.Order order = checkout.MakeOrder();

        return order;
    }
    private string DoPayment(Model.Order order)
    {
        TourLog.LogPayment("**************准备支付订单:" + order.Id + "***************");
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
            //TicketAssign ta = new TicketAssign();

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