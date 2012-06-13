using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class UserCenter_MyOrder : basepage
{
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLOrder bllorder = new BLLOrder();
    BLLMembership bllMember = new BLLMembership();
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    Order order;
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
        int orderid = int.Parse(Request.QueryString["orderid"]);


        order = bllorder.GetOrderByOrderid(orderid);
        btnRefurb.Visible = order.IsPaid && !order.GetUsedState;
        if (order.State == 1)
        {

            paystate.InnerHtml = "订票方式:在线支付&nbsp;&nbsp;已付";
            rptOrderDetail.Visible = true;
            rptOrderDetail2.Visible = false;
            rptOrderDetail3.Visible = false;
            state1.Visible = true;
            state2.Visible = false;
            state3.Visible = false;
        }
        if (order.State == 2)
        {
            paystate.InnerHtml = "订票方式:预定";
            rptOrderDetail.Visible = false;
            rptOrderDetail2.Visible = true;
            rptOrderDetail3.Visible = false;
            state1.Visible = false;
            state2.Visible = true;
            state3.Visible = false;
        }
        if (order.State == 3)
        {
            paystate.InnerHtml = "订票方式:在线支付&nbsp;&nbsp;未付";
            rptOrderDetail.Visible = false;
            rptOrderDetail2.Visible = false;
            rptOrderDetail3.Visible = true;
            state1.Visible = false;
            state2.Visible = false;
            state3.Visible = true;
        }
    }

    protected void btnRefurb_Click(object sender, EventArgs e)
    {
        string html = new BLLRefund(CurrentMember, order.Id.ToString()).ApplyRefund();
        Response.Write(html);
    }
    private void bind()
    {
        int orderid = int.Parse(Request.QueryString["orderid"]);

        Order order = bllorder.GetOrderByOrderid(orderid);
        //hyReturnToList.NavigateUrl = "/UserCenter/Order.aspx";
        rptOrderDetail.DataSource = order.OrderDetail;// bllorderdetail.GetOrderDetailByorderid(orderid);
        rptOrderDetail.DataBind();
        rptbind.DataSource = order.OrderDetail;
        rptbind.DataBind();
        rptOrderDetail2.DataSource = order.OrderDetail;
        rptOrderDetail2.DataBind();
        rptOrderDetail3.DataSource = order.OrderDetail;
        rptOrderDetail3.DataBind();
        List<OrderDetail> list = new List<OrderDetail>();
        IList<OrderDetail> ilist = bllorderdetail.GetOrderDetailByorderid(orderid);
        foreach (OrderDetail item in ilist)
        {
            int count = bllticketassign.GetIsUsedCountByAsodid(item.Id).Count;
            if (count > 0)
            {
                list.Add(item);
            }
        }
        //统计数据
        int counttp = 0;
        int total = 0;
        foreach (RepeaterItem item in rptOrderDetail.Items)
        {
            int price = int.Parse((item.FindControl("tp") as HtmlContainerControl).InnerHtml);
            int num = int.Parse((item.FindControl("qua") as HtmlContainerControl).InnerHtml);
            counttp += num;
            total += num * price;
        }
        oscticketcount.InnerHtml = counttp.ToString();
        oscticketprice.InnerHtml = total.ToString();
        //绑定预定数据
        int ydcountt = 0;
        int ttpricee = 0;
        int cj = 0;
        foreach (RepeaterItem item in rptOrderDetail2.Items)
        {
            OrderDetail od = bllorderdetail.GetOrderDetailByodid(int.Parse((item.FindControl("hfid") as HiddenField).Value));
            decimal yhprice = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(od.TicketPrice.Ticket.Scenic.Id, 3).Price;
            decimal ydprice = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(od.TicketPrice.Ticket.Scenic.Id, 2).Price;
            ydcountt += int.Parse((item.FindControl("notusedcount") as HtmlContainerControl).InnerHtml);
            ttpricee += int.Parse((item.FindControl("notusedcount") as HtmlContainerControl).InnerHtml) * int.Parse((item.FindControl("ydprice") as HtmlContainerControl).InnerHtml);
            cj += (int)(ydprice - yhprice) * int.Parse(((item.FindControl("notusedcount") as HtmlContainerControl).InnerHtml));
        }
        ydcount.InnerHtml = ydcountt.ToString();
        ttprice.InnerHtml = ttpricee.ToString();
        jsprice.InnerHtml = cj.ToString();
        //在线支付未付
        int wfcountt = 0;
        int ttwf = 0;
        int ttwfyd = 0;
        foreach (RepeaterItem item in rptOrderDetail3.Items)
        {
            OrderDetail od = bllorderdetail.GetOrderDetailByodid(int.Parse((item.FindControl("hfid") as HiddenField).Value));
            decimal ydprice = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(od.TicketPrice.Ticket.Scenic.Id, 2).Price;
            wfcountt += int.Parse((item.FindControl("tp") as HtmlContainerControl).InnerHtml);
            ttwf += int.Parse((item.FindControl("sumprice") as HtmlContainerControl).InnerHtml);
            ttwfyd += (int)(int.Parse((item.FindControl("tp") as HtmlContainerControl).InnerHtml) * ydprice);
        }
        wfcount.InnerHtml = wfcountt.ToString();
        wfttprice.InnerHtml = ttwf.ToString();


        zbttprice.InnerHtml = ttwfyd.ToString();
        //绑定常用联系人
        //rptnamelist.DataSource = bllcommonuser.GetCommonUserByUserIdandidcard((Guid)CurrentUser.ProviderUserKey);
        //rptnamelist.DataBind();

        IList<CommonUser> cu = bllcommonuser.GetCommonUserByUserIdandidcard((Guid)CurrentUser.ProviderUserKey);
        rptContacts.DataSource = cu;
        rptContacts.DataBind();
    }
    protected void rptOrderDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("hfid") != null)
        {
            int orderdetailid = int.Parse((e.Item.FindControl("hfid") as HiddenField).Value);
            OrderDetail od = bllorderdetail.GetOrderDetailByodid(orderdetailid);
            int sumprice = int.Parse((od.Quantity * od.TicketPrice.Price).ToString("0"));
            (e.Item.FindControl("sumprice") as HtmlContainerControl).InnerHtml = sumprice.ToString();
            int count = bllticketassign.GetIsUsedCountByAsodid(orderdetailid).Count;
            if (count > 0)
            {
                (e.Item.FindControl("usedstate") as HtmlContainerControl).InnerHtml = "未使用完";
                //(e.Item.FindControl("itemod") as HtmlContainerControl).Attributes.Add("onclick", "btn2("+orderdetailid+")");
                //(e.Item.FindControl("itemod") as HtmlContainerControl).Attributes.Add("style", "cursor:pointer");
            }
            else
            {
                (e.Item.FindControl("usedstate") as HtmlContainerControl).InnerHtml = "已使用";
                (e.Item.FindControl("usedstate") as HtmlContainerControl).Style.Add("color", "#9F9F9F");
            }
            if ((e.Item.FindControl("usedstate") as HtmlContainerControl).InnerHtml == "已使用")
            {
                (e.Item.FindControl("usedetail") as HtmlAnchor).Visible = true;
            }
            else
            {
                (e.Item.FindControl("usedetail") as HtmlAnchor).Visible = false;
            }
            (e.Item.FindControl("buytype") as HtmlContainerControl).InnerHtml = od.TicketPrice.PriceType == PriceType.PayOnline ? "在线购买" : "网上预订";

        }

    }

    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    string name = txtsearchname.Text;
    //    rptnamelist.DataSource = bllcommonuser.SearchCommonUser(name);
    //    rptnamelist.DataBind();
    //}
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptbind.Items)
        {
            string odid = (item.FindControl("hfid") as HiddenField).Value;
            IList<TicketAssign> ilist = bllorderdetail.GetOrderDetailByodid(int.Parse(odid)).TicketAssignList;
            foreach (TicketAssign ta in ilist)
            {
                ta.Name = (item.FindControl("txtdetailname") as TextBox).Text.Trim();
                ta.IdCard = (item.FindControl("txtdetailidcard") as TextBox).Text.Trim();
                bllticketassign.SaveOrUpdate(ta);
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('修改成功!');", true);
    }
    protected void rptbind_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.FindControl("oscused") as HtmlContainerControl) != null)
        {
            string odid = (e.Item.FindControl("hfid") as HiddenField).Value;
            int count = bllticketassign.GetIsUsedCountByAsodid(int.Parse(odid)).Count;
            if (count == 0)
            {
                (e.Item.FindControl("oscused") as HtmlContainerControl).Attributes.Add("style", "color:Gray");
                (e.Item.FindControl("txtdetailname") as TextBox).Attributes.Add("ues", "t");
                (e.Item.FindControl("txtdetailname") as TextBox).Enabled = false;
                (e.Item.FindControl("txtdetailidcard") as TextBox).Enabled = false;
            }
        }
    }
    protected void rptOrderDetail2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("hfid") != null)
        {
            int orderdetailid = int.Parse((e.Item.FindControl("hfid") as HiddenField).Value);
            OrderDetail od = bllorderdetail.GetOrderDetailByodid(orderdetailid);
            int sumprice = int.Parse((od.Quantity * od.TicketPrice.Price).ToString("0"));
            (e.Item.FindControl("sumprice") as HtmlContainerControl).InnerHtml = sumprice.ToString();
            int count = bllticketassign.GetIsUsedCountByAsodid(orderdetailid).Count;
            (e.Item.FindControl("notusedcount") as HtmlContainerControl).InnerHtml = count.ToString();
            (e.Item.FindControl("usedcount") as HtmlContainerControl).InnerHtml = (od.Quantity - count).ToString();
            if (count > 0)
            {
                (e.Item.FindControl("usedstate") as HtmlContainerControl).InnerHtml = "未使用完";
                //(e.Item.FindControl("itemod") as HtmlContainerControl).Attributes.Add("onclick", "btn2("+orderdetailid+")");
                //(e.Item.FindControl("itemod") as HtmlContainerControl).Attributes.Add("style", "cursor:pointer");
            }
            else
            {
                (e.Item.FindControl("usedstate") as HtmlContainerControl).InnerHtml = "已使用";
                (e.Item.FindControl("usedstate") as HtmlContainerControl).Style.Add("color", "#9F9F9F");
            }
            if ((e.Item.FindControl("usedstate") as HtmlContainerControl).InnerHtml == "已使用")
            {
                (e.Item.FindControl("usedetail") as HtmlAnchor).Visible = true;
            }
            else
            {
                (e.Item.FindControl("usedetail") as HtmlAnchor).Visible = false;
            }
        }
    }
    protected void rptOrderDetail3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.FindControl("sumprice") as HtmlContainerControl) != null)
        {
            (e.Item.FindControl("sumprice") as HtmlContainerControl).InnerHtml = (int.Parse((e.Item.FindControl("onlineprice") as HtmlContainerControl).InnerHtml) *
                int.Parse((e.Item.FindControl("tp") as HtmlContainerControl).InnerHtml)).ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write(new BLLPayment(order).Pay());
        // Response.Redirect("/Payment/?transid=" + int.Parse(Request.QueryString["orderid"]) + "");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int orderid = int.Parse(Request.QueryString["orderid"]);
        IList<OrderDetail> od = bllorder.GetOrderByOrderid(orderid).OrderDetail;
        foreach (OrderDetail item in od)
        {
            item.TicketPrice = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(item.TicketPrice.Ticket.Scenic.Id, 2);
            bllorderdetail.saveorupdate(item);
        }
    }
}