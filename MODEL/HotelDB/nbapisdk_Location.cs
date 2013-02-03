using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelDB
{
    public class nbapisdk_Hotel
    {
        public string hotelId { get; set; }
        public string hotelName { get; set; }
        public string address { get; set; }
        public int star { get; set; }
        public string zipCode { get; set; }
        public int category { get; set; }
        public string typology { get; set; }
        public int roomNumer { get; set; }
        public string availPolicy { get; set; }
        public string descNote { get; set; }
        public int usersRating { get; set; }
        public int elongRanking { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string businessZone { get; set; }
        public string distict { get; set; }
        public string brandId { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string openingDate { get; set; }
        public string activationDate { get; set; }
        public string removationDate { get; set; }
        public string addTime { get; set; }
        public string modifyTime { get; set; }
        public bool isEconomic { get; set; }
        public bool isApartment { get; set; }
        public string lowestPrice { get; set; }
        public string lastOrderedTime { get; set; }
        public int invStatusCode { get; set; }

        //附加属性，
        public string url_3 { get; set; }
    }

    public class nbapisdk_Location
    {
        public string parentId { get; set; }
        public string typeCode { get; set; }
        public string locationId { get; set; }
        public string name { get; set; }
    }

    public class nbapisdk_HotelOrder
    {
        public string orderid { get; set; }
        public string statuscode { get; set; }
        public string hotelid { get; set; }
        public string roomtypeid { get; set; }
        public int rateplanid { get; set; }
        public DateTime checkindate { get; set; }
        public DateTime checkoutdate { get; set; }
        public string elongcardno { get; set; }
        public int guesttypecode { get; set; }
        public int roomamount { get; set; }
        public int guestamount { get; set; }
        public int paymenttypecode { get; set; }
        public DateTime arrivalearlytime { get; set; }
        public DateTime arrivallatetime { get; set; }
        public string currencycode { get; set; }
        public decimal totalprice { get; set; }
        public string guaranteecurrencycode { get; set; }
        public decimal guaranteemoney { get; set; }
        public string confirmtypecode { get; set; }
        public string confirmlanguagecode { get; set; }
        public string notetohotel { get; set; }
        public string notetoelong { get; set; }
        public string _default_ { get; set; }
        public string guestsname { get; set; }
        public string contactername { get; set; }
        public int contactergender { get; set; }
        public string contacteremail { get; set; }
        public string contactermobile { get; set; }
        public string contacterphone { get; set; }
        public string contacterfax { get; set; }
    }

    public class nbapisdk_HotelDetail
    {
        public string hotelid { get; set; }
        public string introeditor { get; set; }
        public string ccaccepted { get; set; }
        public string airportpickupservice { get; set; }
        public string generalamenities { get; set; }
        public string roomamenities { get; set; }
        public string recreationamenities { get; set; }
        public string conferenceamenities { get; set; }
        public string diningamenities { get; set; }
        public string trafficeandaroundinfomations { get; set; }
        public string surroundingcommerces { get; set; }
        public string surrondingrestaurants { get; set; }
        public string surroundingattractions { get; set; }
        public string surroundingshops { get; set; }
        public string _default_ { get; set; }
        public string featureinfo { get; set; }
    }

    public class nbapisdk_SuperHotel
    {
        public nbapisdk_Hotel nbapisdk_hotel { get; set; }
        public nbapisdk_HotelDetail nbapisdk_hotelDetail { get; set; }
    }

}
