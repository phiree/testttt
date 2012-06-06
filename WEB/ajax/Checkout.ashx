<%@ WebHandler Language="C#" Class="Checkout" %>

using System;
using System.Web;
using Model;
public class Checkout : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        
    }

    private void docheck()
    {
        /*已有的数据
          门票/ 门票类别/
         *每张门票的数量
         *购买者
         *每个景点的游览者姓名 和 身份证号码/
         */
        
        
        Order order = new Order();
        OrderDetail od = new OrderDetail();
        TicketPrice tp = new TicketPrice();
        tp.Ticket = new Ticket();
        tp.Price = 12;
        tp.PriceType = PriceType.Normal;
        
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}