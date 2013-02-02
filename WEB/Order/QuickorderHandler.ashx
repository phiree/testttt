<%@ WebHandler Language="C#" Class="QuickorderHandler" %>

using System;
using System.Web;
using System.Linq;

public class QuickorderHandler : IHttpHandler
{
    BLL.BLLTicket bllTickets = new BLL.BLLTicket();
    BLL.BLLMembership bllMem = new BLL.BLLMembership();
    Model.PriceType pt = Model.PriceType.PayOnline;
    Model.TourMembership tm;
    int ticketid;
    string phone;
    int qty;

    public void ProcessRequest(HttpContext context)
    {
        ticketid = int.Parse(context.Request["ticketid"]);
        phone = context.Request["phone"];
        string paramPriceType = context.Request["pricetype"];
        string paramTicketAssign = context.Request["a"].TrimEnd('_');

        qty = 1;
        System.Collections.Generic.IList<BLL.CartItem> cartitems
            = new System.Collections.Generic.List<BLL.CartItem>(){
                new BLL.CartItem(){
                    TicketId=ticketid,
                    Qty=qty
                }
            };

        /*支付*/
        int intpricetype;

        if (!int.TryParse(paramPriceType, out intpricetype))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        pt = (Model.PriceType)intpricetype;
        if (pt != Model.PriceType.PreOrder && pt != Model.PriceType.PayOnline)
        {
            context.Response.Write("<script>window.location.href='/order/orderErr.aspx';</script>");
            return;
        }
        Model.Order order = docheck();

        /*指派游览者*/
        string[] arrTicketAssign = paramTicketAssign.Split('_');
        foreach (string ta in arrTicketAssign)
        {
            string[] taValues = ta.Split('-');
            int ticketId = Convert.ToInt32(taValues[0]);
            string name = taValues[1];
            string cardidNo = taValues[2];

            Model.OrderDetail detail = order.OrderDetail.Single<Model.OrderDetail>(x => x.TicketPrice.Ticket.Id == ticketId);
            Model.TicketAssign modelTa = new Model.TicketAssign();
            modelTa.IdCard = cardidNo;
            modelTa.IsUsed = false;
            modelTa.Name = name;
            modelTa.OrderDetail = detail;
            new BLL.BLLTicketAssign().SaveOrUpdate(modelTa);
            //保存常用联系人
            Model.CommonUser cu = new Model.CommonUser();
            //cu.User=new BLLMembership().GetMemberById((Guid)mu.ProviderUserKey);
            //cu.Name = name;
            //cu.IdCard = cardidNo;
            new BLL.BLLCommonUser().Save((Guid)tm.Id, name, cardidNo);

        }
        
    }

    private Model.Order docheck()
    {
        /*已有的数据
          门票/ 门票类别/
         *每张门票的数量
         *购买者
         *每个景点的游览者姓名 和 身份证号码/
         */



        BLL.Checkout checkout = new BLL.Checkout();
        tm = bllMem.GetMember(phone);
        checkout.BuerId = (Guid)tm.Id;
        checkout.PriceType = pt;

        checkout.Details = GetDetails(ticketid);
        Model.Order order = checkout.MakeOrder();

        return order;
    }

    private System.Collections.Generic.List<Model.OrderDetail> GetDetails(int ticketid)
    {

        System.Collections.Generic.IList<BLL.CartItem> cart = new System.Collections.Generic.List<BLL.CartItem>()
        {
            new BLL.CartItem(){
                TicketId=ticketid,
                Qty=1
            }
        };


        System.Collections.Generic.List<Model.OrderDetail> details = new System.Collections.Generic.List<Model.OrderDetail>();

        foreach (BLL.CartItem item in cart)
        {
            Model.OrderDetail od = new Model.OrderDetail();
            od.Quantity = item.Qty;

            Model.TicketBase t = bllTickets.GetTicket(item.TicketId);
            Model.TicketPrice tp = t.TicketPrice.SingleOrDefault<Model.TicketPrice>(x => x.PriceType == pt);

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