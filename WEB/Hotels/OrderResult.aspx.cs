using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hotels_OrderResult : System.Web.UI.Page
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
            lblorderid2.Text = orderdetail.orderid;
            lblname.Text = orderdetail.contactername;
            lblorderstatus.Text = orderdetail.statuscode;
            lblcindate.Text = orderdetail.checkindate.ToShortDateString();
            lblcoutdate.Text = orderdetail.checkoutdate.ToShortDateString();
            lblarrive.Text = orderdetail.arrivalearlytime.ToShortDateString() + "-" + orderdetail.arrivallatetime.ToShortDateString();
            hotelname.Text = orderdetail.hotelid;
            lblroomtype.Text = orderdetail.roomtypeid;
            lblroomnum.Text = orderdetail.roomamount.ToString();
            lblfeetotal.Text = orderdetail.totalprice.ToString();
            lblelongorderid.Text = orderdetail.orderid;
            lbladdress.Text = orderdetail.hotelid;
        }
    }
}