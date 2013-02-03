using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelModel.HotelSDKModel;
using BLL;
using HotelModel.HotelDB;

public partial class Hotels_Order : System.Web.UI.Page
{
    BLL.BLLHotelList hotelListService = new BLL.BLLHotelList();
    SearchHotelListResponseResult SearchHotelListResponseResult;

    string hotelid = string.Empty;
    string typeid = string.Empty;
    string rpid = string.Empty;
    string cin = string.Empty;
    string cout = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["hotelid"] == null || Request["typeid"] == null || Request["rpid"]==null)
        {
            return;
        }
        hotelid = Request["hotelid"].ToString();
        typeid = Request["typeid"].ToString();
        rpid = Request["rpid"].ToString();
        cin = Request["cin"] == null ? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") : Request["cin"].ToString();
        cout = Request["cout"] == null ? DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") : Request["cout"].ToString();

        if (!IsPostBack)
        {
            BindOrder();
        }
    }

    protected void BindOrder()
    {
        SearchHotelListRequestCondition SearchHotelListRequestCondition = new SearchHotelListRequestCondition();

        SearchHotelListRequestCondition.CheckInDate = string.IsNullOrEmpty(cin) ? DateTime.Now.Date : DateTime.Parse(cin);
        SearchHotelListRequestCondition.CheckOutDate = string.IsNullOrEmpty(cout) ? DateTime.Now.AddDays(1).Date : DateTime.Parse(cout);
        SearchHotelListRequestCondition.HotelId = hotelid;
        SearchHotelListRequestCondition.RoomTypeID = typeid;
        SearchHotelListRequestCondition.RatePlanID = int.Parse(rpid);

        SearchHotelListResponseResult = hotelListService.GetHotelListForOrder(SearchHotelListRequestCondition);

        lblhotelname1.Text = SearchHotelListResponseResult.Hotels[0].HotelName;
        lblhotelname2.Text = SearchHotelListResponseResult.Hotels[0].HotelName;
        lblhoteladdress.Text = SearchHotelListResponseResult.Hotels[0].HotelAddress;
        lblprice.Text = SearchHotelListResponseResult.Hotels[0].Rooms[0].RatePlans[0].Rates.TotalPrice.ToString("F0");

        imghotel.ImageUrl = SearchHotelListResponseResult.Hotels[0].HotelImageUrl;
        lblroomtype.Text = SearchHotelListResponseResult.Hotels[0].Rooms[0].RoomName;
        lblbedtype.Text = SearchHotelListResponseResult.Hotels[0].Rooms[0].Bed;
        lblbreakfast.Text = SearchHotelListResponseResult.Hotels[0].Rooms[0].RatePlans[0].RatePlanName;
        lblnet.Text = SearchHotelListResponseResult.Hotels[0].Rooms[0].Internet;
        tbxDateBegin.Text = cin;
        tbxDateEnd.Text = cout;

        hide_CurrencyCode.Value = SearchHotelListResponseResult.Hotels[0].Rooms[0].RatePlans[0].Rates.CurrencyCode;
        hide_RoomTypeId.Value = SearchHotelListResponseResult.Hotels[0].Rooms[0].RoomTypeId;
        hide_GuestTypeCode.Value = SearchHotelListResponseResult.Hotels[0].Rooms[0].RatePlans[0].GuestTypeCode;
        hide_Price.Value= SearchHotelListResponseResult.Hotels[0].Rooms[0].RatePlans[0].Rates.TotalPrice.ToString();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SubmitOrderRequest submitOrderRequest = new SubmitOrderRequest();
        #region 参数赋值
        submitOrderRequest.CheckInDate = DateTime.Parse(cin);
        submitOrderRequest.CheckOutDate = DateTime.Parse(cout);
        submitOrderRequest.ArrivalEarlyTime = DateTime.Parse(submitOrderRequest.CheckInDate.ToString("yyyy-MM-dd") + " " + ddlearly.SelectedValue.ToString());
        submitOrderRequest.ArrivalLateTime = DateTime.Parse(submitOrderRequest.CheckInDate.ToString("yyyy-MM-dd") + " " + ddllate.SelectedValue.ToString());
        submitOrderRequest.CardHolderName = "";
        submitOrderRequest.CardNumber = "";
        submitOrderRequest.ConfirmLanguageCode = "CN";
        submitOrderRequest.ConfirmTypeCode = "sms";
        submitOrderRequest.ContacterMobile = txtphone.Value.Trim();
        submitOrderRequest.ContacterName = txtlxr.Value.Trim();
        submitOrderRequest.CurrencyCode = hide_CurrencyCode.Value;
        submitOrderRequest.GuestAmount = 0;
        submitOrderRequest.GuestNames = txtrzr.Value.Trim();//入住人名字，以逗号分隔
        submitOrderRequest.GuestNationals = "";
        submitOrderRequest.GuestTypeCode = hide_GuestTypeCode.Value;
        submitOrderRequest.HotelId = hotelid== null ? "" : hotelid;
        submitOrderRequest.IDNumber = "";
        submitOrderRequest.RatePlanID = rpid == null ? "" : rpid;
        submitOrderRequest.RoomAmount = int.Parse(ddlroomnum.SelectedValue);
        submitOrderRequest.RoomTypeId = hide_RoomTypeId.Value;
        submitOrderRequest.TotalPrice = lblprice.Text == null ? 0 : decimal.Parse(lblprice.Text);
        submitOrderRequest.ValidMonth = 0;
        submitOrderRequest.ValidYear = 0;
        submitOrderRequest.VeryfyCode ="";
        #endregion
        BLLHotelOrder IOrderService = new BLLHotelOrder();
        SubmitOrderResponse SubmitOrderResponse = IOrderService.SubmitOrder(submitOrderRequest);
        if (SubmitOrderResponse.IsSubmitOrderSucceed)
        {
            nbapisdk_HotelOrder ho = new nbapisdk_HotelOrder();
            ho.orderid = SubmitOrderResponse.OrderID;
            ho.statuscode = string.Empty;
            ho.hotelid = submitOrderRequest.HotelId;
            ho.roomtypeid = submitOrderRequest.RoomTypeId;
            ho.rateplanid = int.Parse(submitOrderRequest.RatePlanID);
            ho.checkindate = submitOrderRequest.CheckInDate;
            ho.checkoutdate = submitOrderRequest.CheckOutDate;
            ho.elongcardno = string.Empty;
            ho.guesttypecode = int.Parse(submitOrderRequest.GuestTypeCode);
            ho.roomamount = submitOrderRequest.RoomAmount;
            ho.guestamount = submitOrderRequest.GuestAmount;
            ho.paymenttypecode = 0;
            ho.arrivalearlytime = submitOrderRequest.ArrivalEarlyTime;
            ho.arrivallatetime = submitOrderRequest.ArrivalLateTime;
            ho.currencycode = submitOrderRequest.CurrencyCode;
            ho.totalprice = submitOrderRequest.TotalPrice;
            ho.guaranteecurrencycode = string.Empty;
            ho.guaranteemoney = 0;
            ho.confirmtypecode = submitOrderRequest.ConfirmTypeCode;
            ho.confirmlanguagecode = submitOrderRequest.ConfirmLanguageCode;
            ho.notetohotel = string.Empty;
            ho.notetoelong = string.Empty;
            ho._default_ = string.Empty;
            ho.guestsname = submitOrderRequest.GuestNames;
            ho.contactername = submitOrderRequest.ContacterName;
            ho.contacterphone = submitOrderRequest.ContacterMobile;
            ho.contactergender = 0;
            ho.contacteremail = string.Empty;
            ho.contactermobile = submitOrderRequest.ContacterMobile;
            ho.contacterfax = string.Empty;
            if (new BLLHotelOrder().SubmitOrder(ho))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下单成功！')", true);
                Response.Redirect("/Hotels/OrderDetail.aspx?orderid=" + SubmitOrderResponse.OrderID);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下单失败！" + SubmitOrderResponse.FailedMessage + "')", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下单失败！" + SubmitOrderResponse.FailedMessage + "')", true);
        }
    }
}