using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hotels_OrderDetail : System.Web.UI.Page
{
    BLL.BLLHotelOrder bllho = new BLL.BLLHotelOrder();
    string orderid = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["orderid"] == null) return;
        orderid = Request["orderid"];
        if (!IsPostBack)
        {
            BindOrderDetail();
        }
    }

    private void BindOrderDetail()
    {
        var orderdetail = bllho.GetOrderdetail(orderid);
        if (orderdetail != null)
        {
            lblorderid.Text = orderdetail.orderid;
            lblorderstatus.Text = orderdetail.statuscode;
            lblcindate.Text = orderdetail.checkindate.ToShortDateString();
            lbltotalprice.Text = orderdetail.totalprice.ToString("F2");
            lblbookdate.Text = orderdetail.bookDate.ToLongDateString();
            lbladdress.Text = orderdetail.hotelid;
            ahotelname.HRef = "/Hotels/Details.aspx?hotelid=" + orderdetail.hotelid;
            lblhotelname.Text = orderdetail.Hotel.hotelName;
            lbladdress.Text = orderdetail.Hotel.address;
            lblphone.Text = orderdetail.Hotel.phone;
            lblcin.Text = orderdetail.checkindate.ToShortDateString();
            lblcout.Text = orderdetail.checkoutdate.ToShortDateString();
            lblarrivalearlytime.Text = orderdetail.arrivalearlytime.ToShortDateString();
            lblarrivallatetime.Text = orderdetail.arrivallatetime.ToShortDateString();
            lblroomnum.Text = orderdetail.roomamount.ToString();
            lblroomtype.Text = orderdetail.roomtypeid;
            lblconname.Text = orderdetail.contactername;
            lblconphone.Text = orderdetail.contactermobile;
            lblguestname.Text = orderdetail.guestsname;
        }
    }
}