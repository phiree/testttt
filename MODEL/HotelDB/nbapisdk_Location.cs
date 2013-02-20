using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelDB
{
    public class nbapisdk_Hotel
    {
        /// <summary>
        /// 酒店id
        /// </summary>
        public string hotelId { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string hotelName { get; set; }
        /// <summary>
        /// 酒店地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 酒店挂牌星级：当为0时，对外显示可用Category的值
        /// </summary>
        public int star { get; set; }
        /// <summary>
        /// 酒店所在地邮编
        /// </summary>
        public string zipCode { get; set; }
        /// <summary>
        /// 酒店星级：-1，0均表示经济型酒店，此处为酒店推荐星级，而非酒店挂牌星级
        /// </summary>
        public int category { get; set; }
        /// <summary>
        /// 酒店类别，目前只有H
        /// </summary>
        public string typology { get; set; }
        /// <summary>
        /// 房间种类数量
        /// </summary>
        public int roomNumer { get; set; }
        /// <summary>
        /// 酒店特殊信息提示：请把次信息展示给用户，以便 用户预定
        /// </summary>
        public string availPolicy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string descNote { get; set; }
        /// <summary>
        /// 用户评分，暂时不用
        /// </summary>
        public int usersRating { get; set; }
        /// <summary>
        /// 艺龙评分，暂时不用
        /// </summary>
        public int elongRanking { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 酒店区域：暂时不用，空置
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 酒店所在省份：ID表示，省份名称和Ggeo中的province对应
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 酒店所在城市：ID表示，城市 名称和geo中cityid相对应
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 商业区：ID表示，商业区名称和geo中的commerciallocation相对应
        /// </summary>
        public string businessZone { get; set; }
        /// <summary>
        /// 行政区：ID表示，城市名称和geo中的distinct相对应
        /// </summary>
        public string distict { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string brandId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string fax { get; set; }
        /// <summary>
        /// 开店时间
        /// </summary>
        public string openingDate { get; set; }
        /// <summary>
        /// 不用字段
        /// </summary>
        public string activationDate { get; set; }
        /// <summary>
        /// 不用字段
        /// </summary>
        public string removationDate { get; set; }
        /// <summary>
        /// 上线销售时间
        /// </summary>
        public string addTime { get; set; }
        /// <summary>
        /// 此酒店最后一次修改时间
        /// </summary>
        public string modifyTime { get; set; }
        /// <summary>
        /// 是否经济型酒店
        /// </summary>
        public bool isEconomic { get; set; }
        /// <summary>
        /// 是否酒店式公寓
        /// </summary>
        public bool isApartment { get; set; }
        /// <summary>
        /// 最低价格
        /// </summary>
        public string lowestPrice { get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public string lastOrderedTime { get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public int invStatusCode { get; set; }



        //附加属性，
        public string url_1 { get; set; }
        public string url_2 { get; set; }
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

        public DateTime bookDate { get; set; }
        public nbapisdk_Hotel Hotel { get; set; }
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
