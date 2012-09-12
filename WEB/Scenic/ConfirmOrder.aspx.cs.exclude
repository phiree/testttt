using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Scenic_ConfirmOrder : System.Web.UI.Page
{
    log4net.ILog logger = log4net.LogManager.GetLogger("PaymentLogger");
    BLLOrder bllorder = new BLLOrder();
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();

    Model.Order order;
    protected void Page_Load(object sender, EventArgs e)
    {
        int orderid = int.Parse(Request.QueryString["orderid"]);
         order  = bllorder.GetOrderByOrderid(orderid);
        if (!IsPostBack)
        {
            bind();
        }
    }
    private void bind()
    {
       
        int type = int.Parse(Request.QueryString["type"]);
     
       
            IList<OrderDetail> list = order.OrderDetail;// bllorderdetail.GetOrderDetailByorderid(orderid);
            decimal sumprice = 0;
            foreach (OrderDetail item in list)
            {
                sumprice += bllticketprice.GetTicketPriceByScenicandtypeid(item.TicketPrice.Ticket.Scenic.Id, 3).Price * item.Quantity;
            }
            liTotal.Text = sumprice.ToString("C0");
        
    }
    protected void btnGoToPay_Click(object sender, EventArgs e)
    {
        BLLPayment bllPay = new BLLPayment(order);
        string payRequest = bllPay.Pay();
        logger.InfoFormat("开始请求支付:{0}", payRequest);
        Response.Write(payRequest);
    }
}