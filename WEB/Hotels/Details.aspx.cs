using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelModel.HotelSDKModel;
using BLL;

public partial class Hotels_Details : System.Web.UI.Page
{
    string hotelid, cindate, coutdate;
    BLLHotelList bllhotel = new BLLHotelList();
    BLL.BLLHotelRoom bllroom = new BLLHotelRoom();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["hotelid"] == null)
        {
            return;
        }
        if (Request["cin"] == null)
        {
            hotelid = Request["hotelid"].ToString();
            cindate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            coutdate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
        }
        else
        {
            hotelid = Request["hotelid"].ToString();
            cindate = Request["cin"].ToString();
            coutdate = Request["cout"].ToString();
        }
        if (!IsPostBack)
        {
            BindRooms();
        }
    }

    protected void BindRooms()
    {
        SearchHotelDetailResponseResult SearchHotelDetailResponseResult = new SearchHotelDetailResponseResult();

        SearchHotelDetailRequestCondition SearchHotelDetailRequestCondition = new SearchHotelDetailRequestCondition();
        SearchHotelDetailRequestCondition.CheckInDate = string.IsNullOrEmpty(cindate) ? DateTime.Now.Date : DateTime.Parse(cindate);
        SearchHotelDetailRequestCondition.CheckOutDate = string.IsNullOrEmpty(coutdate) ? DateTime.Now.AddDays(1).Date : DateTime.Parse(coutdate);
        SearchHotelDetailRequestCondition.HotelID = hotelid;


        SearchHotelDetailResponseResult = bllhotel.GetHotelDetail(SearchHotelDetailRequestCondition);
        var local_hotels = bllhotel.GetTotalHotelDetailStaticInfo(SearchHotelDetailRequestCondition.HotelID);

        imgMain.ImageUrl = SearchHotelDetailResponseResult.HotelImageUrl;
        //rptImgs.DataSource = SearchHotelDetailResponseResult.HotelImages;
        //rptImgs.DataBind();
        var roomsource = SearchHotelDetailResponseResult.SearchHotelListResponseResult.Hotels[0].Rooms;
        var room2source = bllroom.GetRoomDetailinfo(hotelid, null);
        foreach (var item in room2source)
        {
            if (roomsource.Where(x => x.RoomTypeId == item.roomTypeId).Count() > 0)
            {
                item.averageRate = roomsource.First(x => x.RoomTypeId == item.roomTypeId).RatePlans[0].Rates.AverageRate;
                item.roomInvStatusCode = roomsource.First(x => x.RoomTypeId == item.roomTypeId).RoomInvStatusCode;
                item.ratePlanName = roomsource.First(x => x.RoomTypeId == item.roomTypeId).RatePlans[0].RatePlanName;
                item.ratePlanId = roomsource.First(x => x.RoomTypeId == item.roomTypeId).RatePlans[0].RatePlanID;
            }
        }
        rptrooms2.DataSource = room2source;
        rptrooms2.DataBind();


        lblhotelname.Text = SearchHotelDetailResponseResult.SearchHotelListResponseResult.Hotels[0].HotelName;
        lbladdress.Text = SearchHotelDetailResponseResult.SearchHotelListResponseResult.Hotels[0].HotelAddress;
        checkInDateApply.Value = cindate;
        checkOutDateApply.Value = coutdate;
        lblhoteltel.Text = local_hotels.nbapisdk_hotel.phone;
        lblopentime.Text = (DateTime.Parse(local_hotels.nbapisdk_hotel.openingDate)).ToLongDateString();
        lblnet.Text = "酒店提供宽带上网";
        lblhotelintro.Text = local_hotels.nbapisdk_hotelDetail.introeditor;
        lbllevel.Text = local_hotels.nbapisdk_hotel.star.ToString() == "0" ? "无" : local_hotels.nbapisdk_hotel.star.ToString() + "星";
        lblhoteldesc.Text = local_hotels.nbapisdk_hotelDetail.trafficeandaroundinfomations;
    }
    protected void btndatemodi_Click(object sender, EventArgs e)
    {
        cindate = checkInDateApply.Value;
        coutdate = checkOutDateApply.Value;
        BindRooms();
    }
}