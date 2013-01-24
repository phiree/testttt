using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using Model;
using BLL;
using System.Data;
/// <summary>
/// 购票记录
/// 使用记录
/// </summary>
public partial class UserCenter_MyTickets : basepage
{

    BLLOrder bllOrder = new BLLOrder();
    BLLArea bllArea = new BLLArea();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }

    }

    private void BindList()
    {
        //获取该用户的Order
        object objId = CurrentUser.ProviderUserKey;
        Guid memberId = new Guid(objId.ToString());
        IList<Order> orderList = bllOrder.GetListForUser(memberId);
        rptOrder.DataSource = orderList;
        rptOrder.DataBind();
    }

    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    Repeater rpColumnNews = (Repeater)e.Item.FindControl("rptDetail");
        //    //找到分类Repeater关联的数据项 
        //    Model.Order order = (Model.Order)e.Item.DataItem;
        //    //里面的Repeater
        //    if (order.IsPaid)
        //    {
        //        Button btn = e.Item.FindControl("btnValidate") as Button;
        //        btn.Visible = false;
        //    }
        //}
    }
    private void Pay(int transid)
    {
        Response.Redirect("/Payment/?transid=" + transid + "");
    }

    protected void rptOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (!(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
        {
            return;
        }
        if (e.Item.FindControl("rptod") != null)
        {
            string odid = (e.Item.FindControl("hfodid") as HiddenField).Value;
            Repeater r = e.Item.FindControl("rptod") as Repeater;
            r.ItemDataBound+=new RepeaterItemEventHandler(r_ItemDataBound);
            r.DataSource = bllOrder.GetOrderByOrderid(int.Parse(odid)).OrderDetail;
            r.DataBind();
        }
        if (e.Item.FindControl("paystate") != null)
        {
            string odid = (e.Item.FindControl("hfodid") as HiddenField).Value;
            ViewState["odid"] = odid;
            Order order = bllOrder.GetOrderByOrderid(int.Parse(odid));
            HtmlAnchor ha = e.Item.FindControl("usedetail") as HtmlAnchor;
            if (order.IsPaid == true && order.OrderDetail[0].TicketPrice.PriceType == PriceType.PayOnline)
            {
                (e.Item.FindControl("paystate") as HtmlContainerControl).InnerHtml = order.PayTime.Value.ToString("yyyy-MM-dd") + "&nbsp;已付款";
                //ha.HRef = "/UserCenter/Orderdetail.aspx?orderid=" + odid + "&type=1";
            }
            if (order.OrderDetail[0].TicketPrice.PriceType == PriceType.PreOrder)
            {
                (e.Item.FindControl("paystate") as HtmlContainerControl).InnerHtml = order.BuyTime.ToString("yyyy-MM-dd") + "&nbsp;已预定";
                //ha.HRef = "/UserCenter/Orderdetail.aspx?orderid=" + odid + "&type=2";
            }
            if (order.IsPaid == false && order.OrderDetail[0].TicketPrice.PriceType == PriceType.PayOnline)
            {
                (e.Item.FindControl("paystate") as HtmlContainerControl).InnerHtml = "未付款&nbsp;&nbsp;" + "<a class='onowpay' onclick='pay()'>现在支付</a>";
                //ha.HRef = "/UserCenter/Orderdetail.aspx?orderid=" + odid + "&type=3";
            }
        }
        
    }
    protected void btnpayfor_Click(object sender, EventArgs e)
    {
        Order order = bllOrder.GetOrderByOrderid(int.Parse(ViewState["odid"].ToString()));
        Response.Write(new BLLPayment(order).Pay());
    }

    protected void r_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            OrderDetail od = e.Item.DataItem as OrderDetail;
            HtmlAnchor haa = e.Item.FindControl("ahref") as HtmlAnchor;
            haa.HRef = "/Tickets/" + bllArea.GetAreaByCode(od.TicketPrice.Ticket.Scenic.Area.Code.Substring(0, 4) + "00").SeoName + "_" + od.TicketPrice.Ticket.Scenic.Area.SeoName + "/" + od.TicketPrice.Ticket.Scenic.SeoName + ".html";
        }
    }
}
    