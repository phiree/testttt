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
    BLLTicketAssign bllTa = new BLLTicketAssign();
    BLLMembership bllMembership = new BLLMembership();
    BLLActivityServiceImpl bllActivityService = new BLLActivityServiceImpl();
    BLLOrder bllOrder = new BLLOrder();
    string paramTicketAssign;
    string orderErrMsg;
    bool OrderSuccess = false;
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
        paramTicketAssign = req["a"].TrimEnd('_');
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

        string[] arrTicketAssign = paramTicketAssign.Split('_');
     
        IList<Ticket> TicketList = new List<Ticket>();
        int amount=1;
        foreach (var item in cartitems)
        {
            Ticket originalTicket = bllTickets.GetTicket(item.TicketId);
            TicketList.Add(originalTicket);
            amount = item.Qty;
            
        }
        string assignName=string.Empty, idcardno=string.Empty;
        if (arrTicketAssign.Length >0)
        {
            string[] taValues = arrTicketAssign[0].Split('-');

            assignName = taValues[1];
            idcardno = taValues[2];
        }
        ///为活动做了简化处理: 订单内 每个订单详情的数量, 分配的身份证号码和 姓名都是一样的
        
        #region  //用户已买门票数量的判断
        //foreach (Ticket t in TicketList)
        //{ 
        //    if(t.TourActivity!=null)
        //    {
        //     bool checkResult=   bllTa.CheckIdCardAmountPerTicket(t.TourActivity.ActivityCode, idcardno, t.ProductCode, amount, out orderErrMsg);
        //     if (checkResult == false)
        //     {
        //         context.Response.Write("<script>window.location.href='/order/QuZhouorderFail.aspx?msg=" + context.Server.UrlEncode(orderErrMsg) + "';</script>");
        //         return;
        //     }
        //    }
         
        //}
        
        
        #endregion


        Model.Order order = bllOrder.CreateOrder(System.Configuration.ConfigurationManager.AppSettings["partnerCode"], tourMembership.Id, TicketList, idcardno, assignName, amount, pt, out orderErrMsg);
          //  Model.Order order = docheck();

         if (!string.IsNullOrEmpty(orderErrMsg))
            {
                context.Response.Write("<script>window.location.href='/order/QuZhouorderFail.aspx?msg=" + context.Server.UrlEncode(orderErrMsg) + "';</script>");
                return;
            }
         
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

    //private Model.Order docheck()
    //{
    //    /*已有的数据
    //      门票/ 门票类别/
    //     *每张门票的数量
    //     *购买者
    //     *每个景点的游览者姓名 和 身份证号码/
    //     */



    //    Checkout checkout = new Checkout();
    //    checkout.BuerId = (Guid)mu.ProviderUserKey;
    //    checkout.PriceType = pt;

    //    checkout.Details = GetDetails();
    //    Model.Order order = checkout.MakeOrder();

    //    OrderSuccess = true;
    //    return order;
    //}
    private string DoPayment(Model.Order order)
    {
        TourLog.LogPayment("**************准备支付订单:" + order.Id + "***************");
        BLLPayment payment = new BLLPayment(order);
        TourLog.LogPayment("跳转至支付宝开始支付:" + order.Id + "");

        return payment.Pay();
    }

    //private List<OrderDetail> GetDetails()
    //{

    //    IList<CartItem> cart = bllTickets.GetCartFromCookies();


    //    List<OrderDetail> details = new List<OrderDetail>();

    //    string errMsg;
    //    ///购物车内的 门票ID 和 数量
    //    foreach (CartItem item in cart)
    //    {

    //        Ticket originalTicket = bllTickets.GetTicket(item.TicketId);
    //        //IList<Ticket> allTickets = new List<Ticket>();
    //        //if (originalTicket is TicketUnion)
    //        //{
    //        //    allTickets = ((TicketUnion)originalTicket).TicketList;
    //        //}
    //        //else
    //        //{
    //        //    allTickets.Add(originalTicket);
    //        //}
    //        ////
           
           
    //            OrderDetail od = new OrderDetail();
    //            od.Quantity = item.Qty;

    //            TicketPrice tp = t.TicketPrice.Single<TicketPrice>(x => x.PriceType == pt);

    //            string[] arrTicketAssign = paramTicketAssign.Split('_');
    //            foreach (string ta in arrTicketAssign)
    //            {
    //                string[] taValues = ta.Split('-');
    //                int ticketId = Convert.ToInt32(taValues[0]);
    //                string name = taValues[1];
    //                string cardidNo = taValues[2];
    //                //活动规则检查
    //                TourActivity touractivity = t.TourActivity;
    //                if (touractivity != null)
    //                {


    //                    IList<TicketAssign> talist = bllTa.GetTaByIdcardandTicketCode(cardidNo, t.ProductCode);
    //                    bool checkResult = touractivity.IntergrationCheck(talist, cardidNo, t.ProductCode, 1, out orderErrMsg);
    //                    if (!checkResult)
    //                    {

    //                        return null;
    //                    }
    //                }
    //                TicketAssign modelTa = new TicketAssign();
    //                modelTa.IdCard = cardidNo;
    //                modelTa.IsUsed = false;
    //                modelTa.Name = name;
    //                modelTa.OrderDetail = od;
    //                // new BLLTicketAssign().SaveOrUpdate(modelTa);
                
    //            od.TicketPrice = tp;
    //            details.Add(od);
    //        }


    //    }
    //    return details;

    //}

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}