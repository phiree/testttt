using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel.HotelDB;
using HotelModel.HotelSDKModel;

namespace DAL
{
    public class DALHotel : DalBase
    {
        public List<nbapisdk_Hotel> GetHotels(SearchHotelListRequestCondition searchHotelListRequestCondition)
        {
            var hotels = new List<nbapisdk_Hotel>();

            try
            {
                string sql = "select top 20 h.*,img.url_1,img.url_2,img.url_3 from nbapisdk_Hotel h,nbapisdk_Image img where city=:city and img.hotelId=h.hotelId and img.imgType=5";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("city", searchHotelListRequestCondition.CityId);
                var result = query.List<object[]>();
                foreach (var item in result)
                {
                    hotels.Add(new nbapisdk_Hotel()
                    {
                        hotelId = item[0].ToString(),
                        hotelName = item[1].ToString(),
                        address = item[2].ToString(),
                        star = int.Parse(item[3].ToString()),
                        zipCode = item[4].ToString(),
                        category = int.Parse(item[5].ToString()),
                        typology = item[6].ToString(),
                        roomNumer = int.Parse(item[7].ToString()),
                        availPolicy = item[8].ToString(),
                        descNote = item[9].ToString(),
                        usersRating = int.Parse(item[10].ToString()),
                        elongRanking = int.Parse(item[11].ToString()),
                        latitude = item[12].ToString(),
                        longitude = item[13].ToString(),
                        country = item[14].ToString(),
                        region = item[15].ToString(),
                        province = item[16].ToString(),
                        city = item[17].ToString(),
                        businessZone = item[18].ToString(),
                        distict = item[19].ToString(),
                        brandId = item[20].ToString(),
                        phone = item[21] == null ? "" : item[21].ToString(),
                        fax = item[22] == null ? "" : item[22].ToString(),
                        openingDate = item[23].ToString(),
                        activationDate = item[24] == null ? "" : item[24].ToString(),
                        removationDate = item[25] == null ? "" : item[25].ToString(),
                        addTime = item[26].ToString(),
                        modifyTime = item[27].ToString(),
                        isEconomic = bool.Parse(item[28].ToString()),
                        isApartment = bool.Parse(item[29].ToString()),
                        lowestPrice = item[30] == null ? "" : item[30].ToString(),
                        lastOrderedTime = item[31] == null ? "" : item[31].ToString(),
                        invStatusCode = int.Parse(item[32].ToString()),
                        url_1 = item[33].ToString(),
                        url_2 = item[34].ToString(),
                        url_3 = item[35].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return hotels;
        }
        /// <summary>
        /// 获得数据库geo信息
        /// </summary>
        /// <param name="TypeCodeId">//省1，城市2，行政区3，商业区4，地标5</param>
        /// <returns></returns>
        public List<nbapisdk_Location> GetGeos(string TypeCodeId)
        {
            List<nbapisdk_Location> geos = null;
            try
            {
                string sql = "SELECT top 20 parentId,typeCode,locationId,name FROM nbapisdk_Location loc where loc.typeCode=:typeCode";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("typeCode", TypeCodeId);
                var result = query.List<object[]>();
                foreach (var item in result)
                {
                    geos.Add(new nbapisdk_Location()
                    {
                        parentId = item[0].ToString(),
                        typeCode = item[1].ToString(),
                        locationId = item[2].ToString(),
                        name = item[3].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return geos;
        }
        /// <summary>
        /// 获得数据库geo信息
        /// </summary>
        /// <param name="TypeCodeId">//省1，城市2，行政区3，商业区4，地标5</param>
        /// <returns></returns>
        public List<nbapisdk_Location> GetGeos(string TypeCodeId, string ParentID)
        {
            List<nbapisdk_Location> geos = null;
            try
            {
                string sql = "SELECT top 20 parentId,typeCode,locationId,name FROM nbapisdk_Location loc " +
                    "where loc.typeCode=:typeCode and p.parentId =:parentId";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("typeCode", TypeCodeId)
                    .SetParameter("parentId", ParentID);
                var result = query.List<object[]>();
                foreach (var item in result)
                {
                    geos.Add(new nbapisdk_Location()
                    {
                        parentId = item[0].ToString(),
                        typeCode = item[1].ToString(),
                        locationId = item[2].ToString(),
                        name = item[3].ToString()
                    });
                }
            }
            catch (Exception e)
            {

            }
            return geos;
        }
        /// <summary>
        /// 获得酒店商业区名字
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        public string GetHotelCommercialAreaName(string HotelId)
        {
            string HotelCommercialAreaName = "";
            try
            {
                string sql = "select top 1 businessZone from nbapisdk_Hotel h where h.hotelId='" + HotelId + "'";
                var query = session.CreateSQLQuery(sql);
                var locationid = query.UniqueResult<string>();
                string sql2 = "SELECT name FROM nbapisdk_Location where locationId ='" + locationid + "'";
                var query2 = session.CreateSQLQuery(sql2);
                HotelCommercialAreaName = query2.UniqueResult<string>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return HotelCommercialAreaName;
        }
        /// <summary>
        /// 获得酒店外观图片
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        public string GetHotelOneImgExteriorUrl(string HotelId)
        {
            string imageurl = "";
            try
            {
                string sql = "SELECT top 1 url_1 FROM nbapisdk_Image where hotelId=:hotelId and imgType=5";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId", HotelId);
                imageurl = query.UniqueResult<string>();
                if (string.IsNullOrEmpty(imageurl))
                {
                    var sql2 = "SELECT url_1 FROM nbapisdk_Image where hotelId=:hotelId";
                    var query2 = session.CreateSQLQuery(sql2)
                        .SetParameter("hotelId", HotelId);
                    var images = query2.List<string>();
                    if (images != null && images.Count > 0)
                    {
                        imageurl = images.Take(1).ToList()[0];
                    }
                }
            }
            catch (Exception e)
            {

            }
            return imageurl;
        }
        public string GetHotelOneImgExteriorUrlForDetail(string HotelId)
        {
            string imageurl = "";
            try
            {
                string sql = "SELECT top 1 url_1 FROM nbapisdk_Image where hotelId=:hotelId and imgType=5";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId", HotelId);
                imageurl = query.FutureValue<string>().Value;
                if (string.IsNullOrEmpty(imageurl))
                {
                    var sql2 = "SELECT url_1 FROM nbapisdk_Image where hotelId=:hotelId";
                    var query2 = session.CreateSQLQuery(sql2)
                        .SetParameter("hotelId", HotelId);
                    var images = query2.List<string>();
                    if (images != null && images.Count > 0)
                    {
                        imageurl = images.Take(1).ToList()[0];
                    }
                }
            }
            catch (Exception e)
            {

            }
            return imageurl;
        }
        /// <summary>
        /// 获得酒店房型的部分信息
        /// </summary>
        /// <param name="HotelId"></param>
        /// <param name="RoomtypeId"></param>
        /// <returns></returns>
        public RoomPartInfo GetRoomPartInfo(string HotelId, string RoomtypeId)
        {
            RoomPartInfo roomPartInfo = new RoomPartInfo();
            try
            {
                string sql = "SELECT top 1 bedType,hasBroadnet FROM nbapisdk_Room where hotelId=:hotelId and roomTypeId=:roomTypeId";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId", HotelId)
                    .SetParameter("roomTypeId", RoomtypeId);
                var result = query.UniqueResult<object[]>();
                roomPartInfo.Bed = result[0].ToString();
                roomPartInfo.Internet = Boolean.Parse(result[1].ToString()) == true ? "有" : "没有";
            }
            catch (Exception e)
            {
                throw e;
            }
            return roomPartInfo;
        }
        public IList<RoomDetailinfo> GetRoomDetailinfo(string HotelId, string RoomtypeId)
        {
            IList<RoomDetailinfo> roomPartInfoList = new List<RoomDetailinfo>();
            RoomDetailinfo roomPartInfo;
            try
            {
                //string sql = "  SELECT r.hotelId,r.roomTypeId,r.roomName,r.area,r.roomFloor,r.hasBroadnet,r.broadnetFee,r.bedType," +
                //    "img.imgType,img.title,img.url_1,img.url_2,img.url_3 "+
                //    "FROM nbapisdk_Image img,nbapisdk_Room r " +
                //    "where r.hotelId=:hotelId1 and img.hotelId=:hotelId2 and img.roomTypeId=r.roomTypeId ";
                string sql = "SELECT r.hotelId,r.roomTypeId,r.roomName,r.area,r.roomFloor,r.hasBroadnet,r.broadnetFee,r.bedType," +
                    "img.imgType,img.title,img.url_1,img.url_2,img.url_3 " +
                    " FROM (SELECT * FROM nbapisdk_Room where hotelId=:hotelId2) as r " +
                    "left join (select * from nbapisdk_Image where hotelId=:hotelId1) as img on  img.roomTypeId=r.roomTypeId ";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId1", HotelId)
                    .SetParameter("hotelId2", HotelId);
                var result = query.List<object[]>();
                foreach (var item in result)
                {
                    roomPartInfo = new RoomDetailinfo();
                    roomPartInfo.hotelId = item[0].ToString();
                    roomPartInfo.roomTypeId = item[1].ToString();
                    roomPartInfo.roomName = item[2].ToString();
                    roomPartInfo.area = item[3].ToString();
                    roomPartInfo.roomFloor = item[4].ToString();
                    roomPartInfo.hasInternet = Boolean.Parse(item[5].ToString()) == true ? "免费" : "没有";
                    roomPartInfo.broadnetFee = item[6].ToString();
                    roomPartInfo.bedType = item[7].ToString();
                    roomPartInfo.imgType = item[8] == null ? "" : item[8].ToString();
                    roomPartInfo.title = item[9] == null ? "" : item[9].ToString();
                    roomPartInfo.url_1 = item[10] == null ? "" : item[10].ToString();
                    roomPartInfo.url_2 = item[11] == null ? "" : item[11].ToString();
                    roomPartInfo.url_3 = item[12] == null ? "" : item[12].ToString();
                    roomPartInfoList.Add(roomPartInfo);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return roomPartInfoList;
        }

        public List<string> GetHotelImages(string hotelid)
        {
            List<string> urls = new List<string>();
            try
            {
                string sql = "select url_2 from nbapisdk_Image img where img.hotelId=:hotelId";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId", hotelid);
                return query.List<string>().ToList();
            }
            catch (Exception e)
            {

            }
            return urls;
        }

        public HotelDetail GetHotelDetailStaticInfo(string hotelid)
        {
            HotelDetail hotel = new HotelDetail();

            try
            {
                string sql = "select hd.introeditor,hd.ccaccepted,hd.airportpickupservice,hd.featureInfo " +
                    "from nbapisdk_HotelDetail hd " +
                    "where hd.hotelId=:hotelId";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId", hotelid);
                var result = query.UniqueResult<object[]>();
                return new HotelDetail()
                {
                    HotelIntro = result[0].ToString(),
                    HotelPayMent = result[1].ToString(),
                    HotelService = result[2].ToString(),
                };
            }
            catch (Exception e)
            {

            }
            return hotel;
        }

        public nbapisdk_SuperHotel GetTotalHotelDetailStaticInfo(string hotelid)
        {
            nbapisdk_SuperHotel hotel = new nbapisdk_SuperHotel();

            try
            {
                string sql = "select h.*,hd.introeditor,hd.ccaccepted,hd.airportpickupservice,hd.featureInfo " +
                    "from nbapisdk_HotelDetail hd,nbapisdk_Hotel h " +
                    "where hd.hotelId=h.hotelId and hd.hotelId=:hotelId";
                var query = session.CreateSQLQuery(sql)
                    .SetParameter("hotelId", hotelid);
                var result = query.UniqueResult<object[]>();
                return new nbapisdk_SuperHotel()
                {
                    nbapisdk_hotel = new nbapisdk_Hotel()
                    {
                        hotelId = result[0].ToString(),
                        hotelName = result[1].ToString(),
                        address = result[2].ToString(),
                        star = int.Parse(result[3].ToString()),
                        zipCode = result[4].ToString(),
                        category = int.Parse(result[5].ToString()),
                        typology = result[6].ToString(),
                        roomNumer = int.Parse(result[7].ToString()),
                        availPolicy = result[8].ToString(),
                        descNote = result[9].ToString(),
                        usersRating = int.Parse(result[10].ToString()),
                        elongRanking = int.Parse(result[11].ToString()),
                        latitude = result[12].ToString(),
                        longitude = result[13].ToString(),
                        country = result[14].ToString(),
                        region = result[15].ToString(),
                        province = result[16].ToString(),
                        city = result[17].ToString(),
                        businessZone = result[18].ToString(),
                        distict = result[19].ToString(),
                        brandId = result[20].ToString(),
                        phone = result[21] == null ? "" : result[21].ToString(),
                        fax = result[22] == null ? "" : result[22].ToString(),
                        openingDate = result[23].ToString(),
                        activationDate = result[24] == null ? "" : result[24].ToString(),
                        removationDate = result[25] == null ? "" : result[25].ToString(),
                        addTime = result[26].ToString(),
                        modifyTime = result[27].ToString(),
                        isEconomic = bool.Parse(result[28].ToString()),
                        isApartment = bool.Parse(result[29].ToString()),
                        lowestPrice = result[30] == null ? "" : result[30].ToString(),
                        lastOrderedTime = result[31] == null ? "" : result[31].ToString(),
                        invStatusCode = int.Parse(result[32].ToString()),
                    },
                    nbapisdk_hotelDetail = new nbapisdk_HotelDetail()
                    {
                        introeditor = result[33].ToString(),
                        ccaccepted = result[34].ToString(),
                        airportpickupservice = result[35].ToString(),
                        featureinfo = result[36].ToString()
                    }
                };
            }
            catch (Exception e)
            {

            }
            return hotel;
        }

        public bool SubmitOrder(nbapisdk_HotelOrder nbapisdk_HotelOrder)
        {
            string sql = "INSERT INTO [nbapisdk_HotelOrder] ( [orderId] ,[statusCode] ,[hotelId] ,[roomTypeId] ,[ratePlanId] ,[checkInDate] ,[checkOutDate] ,[elongCardNo] ,"
                + "[guestTypeCode] ,[roomAmount] ,[guestAmount] ,[paymentTypeCode] ,[arrivalEarlyTime] ,[arrivalLateTime] ,[currencyCode] ,[totalPrice] ,[guaranteeCurrencyCode] ,"
                + "[guaranteeMoney] ,[confirmTypeCode] ,[confirmLanguageCode] ,[noteToHotel] ,[noteToElong] ,[_default_] ,[guestsName] ,[contacterName] ,[contacterGender] ,"
                + "[contacterEmail] ,[contacterMobile] ,[contacterPhone] ,[contacterFax] ) "
                + " VALUES (:orderId,:statusCode,:hotelId,:roomTypeId,:ratePlanId,:checkInDate,:checkOutDate,:elongCardNo,:guestTypeCode,"
                + ":roomAmount,:guestAmount,:paymentTypeCode,:arrivalEarlyTime,:arrivalLateTime,:currencyCode,:totalPrice,:guaranteeCurrencyCode,"
                + ":guaranteeMoney,:confirmTypeCode,:confirmLanguageCode,:noteToHotel,:noteToElong,:_default_,:guestsName,"
                + ":contacterName,:contacterGender,:contacterEmail,:contacterMobile,:contacterPhone,:contacterFax)";
            var query = session.CreateSQLQuery(sql)
                .SetParameter("orderId", nbapisdk_HotelOrder.orderid)
                .SetParameter("statusCode", nbapisdk_HotelOrder.statuscode)
                .SetParameter("hotelId", nbapisdk_HotelOrder.hotelid)
                .SetParameter("roomTypeId", nbapisdk_HotelOrder.roomtypeid)
                .SetParameter("ratePlanId", nbapisdk_HotelOrder.rateplanid)
                .SetParameter("checkInDate", nbapisdk_HotelOrder.checkindate)
                .SetParameter("checkOutDate", nbapisdk_HotelOrder.checkoutdate)
                .SetParameter("elongCardNo", nbapisdk_HotelOrder.elongcardno)
                .SetParameter("guestTypeCode", nbapisdk_HotelOrder.guesttypecode)
                .SetParameter("roomAmount", nbapisdk_HotelOrder.roomamount)
                .SetParameter("guestAmount", nbapisdk_HotelOrder.guestamount)
                .SetParameter("paymentTypeCode", nbapisdk_HotelOrder.paymenttypecode)
                .SetParameter("arrivalEarlyTime", nbapisdk_HotelOrder.arrivalearlytime)
                .SetParameter("arrivalLateTime", nbapisdk_HotelOrder.arrivallatetime)
                .SetParameter("currencyCode", nbapisdk_HotelOrder.currencycode)
                .SetParameter("totalPrice", nbapisdk_HotelOrder.totalprice)
                .SetParameter("guaranteeCurrencyCode", nbapisdk_HotelOrder.guaranteecurrencycode)
                .SetParameter("guaranteeMoney", nbapisdk_HotelOrder.guaranteemoney)
                .SetParameter("confirmTypeCode", nbapisdk_HotelOrder.confirmtypecode)
                .SetParameter("confirmLanguageCode", nbapisdk_HotelOrder.confirmlanguagecode)
                .SetParameter("noteToHotel", nbapisdk_HotelOrder.notetohotel)
                .SetParameter("noteToElong", nbapisdk_HotelOrder.notetoelong)
                .SetParameter("_default_", nbapisdk_HotelOrder._default_)
                .SetParameter("guestsName", nbapisdk_HotelOrder.guestsname)
                .SetParameter("contacterName", nbapisdk_HotelOrder.contactername)
                .SetParameter("contacterGender", nbapisdk_HotelOrder.contactergender)
                .SetParameter("contacterEmail", nbapisdk_HotelOrder.contacteremail)
                .SetParameter("contacterMobile", nbapisdk_HotelOrder.contactermobile)
                .SetParameter("contacterPhone", nbapisdk_HotelOrder.contacterphone)
                .SetParameter("contacterFax", nbapisdk_HotelOrder.contacterfax);
            var result = query.ExecuteUpdate();
            if (result == 0) return false;
            else return true;
        }

        public nbapisdk_HotelOrder GetOrderdetail(string orderid)
        {
            nbapisdk_HotelOrder ho = new nbapisdk_HotelOrder();
            string sql = "select top 1 [orderId],[statusCode],[hotelId],[roomTypeId],[ratePlanId],[checkInDate]," +//6
                "[checkOutDate],[elongCardNo],[guestTypeCode],[roomAmount],[guestAmount],[paymentTypeCode]," +//6
                "[arrivalEarlyTime],[arrivalLateTime],[currencyCode],[totalPrice],[guaranteeCurrencyCode],[guaranteeMoney]," +//6
                "[confirmTypeCode],[confirmLanguageCode],[noteToHotel],[noteToElong],[_default_],[guestsName]," +//6
                "[contacterName],[contacterGender],[contacterEmail],[contacterMobile],[contacterPhone],[contacterFax] " +//6
                "from [nbapisdk_HotelOrder] where orderId=:orderId";
            var query = session.CreateSQLQuery(sql).SetParameter("orderId", orderid);
            var result = query.List<object[]>();
            foreach (var item in result)
            {
                ho.orderid = item[0].ToString();
                ho.statuscode = item[1].ToString();
                ho.hotelid = item[2].ToString();
                ho.roomtypeid = item[3].ToString();
                ho.rateplanid = int.Parse(item[4].ToString());
                ho.checkindate = DateTime.Parse(item[5].ToString());
                ho.checkoutdate = DateTime.Parse(item[6].ToString());
                ho.elongcardno = item[7].ToString();
                ho.guesttypecode = int.Parse(item[8].ToString());
                ho.roomamount = int.Parse(item[9].ToString());
                ho.guestamount = int.Parse(item[10].ToString());
                ho.paymenttypecode = int.Parse(item[11].ToString());
                ho.arrivalearlytime = DateTime.Parse(item[12].ToString());
                ho.arrivallatetime = DateTime.Parse(item[13].ToString());
                ho.currencycode = item[14].ToString();
                ho.totalprice = decimal.Parse(item[15].ToString());
                ho.guaranteecurrencycode = item[16].ToString();
                ho.guaranteemoney = decimal.Parse(item[17].ToString());
                ho.confirmtypecode = item[18].ToString();
                ho.confirmlanguagecode = item[19].ToString();
                ho.notetohotel = item[20].ToString();
                ho.notetoelong = item[21].ToString();
                ho._default_ = item[22].ToString();
                ho.guestsname = item[23].ToString();
                ho.contactername = item[24].ToString();
                ho.contactergender = int.Parse(item[25].ToString());
                ho.contacteremail = item[26].ToString();
                ho.contactermobile = item[27].ToString();
                ho.contacterphone = item[28].ToString();
                ho.contacterfax = item[29].ToString();
            }
            return ho;
        }
        public IList<nbapisdk_HotelOrder> GetOrderList(string memid)
        {
            if (string.IsNullOrWhiteSpace(memid)) return null;
            IList<nbapisdk_HotelOrder> holist = new List<nbapisdk_HotelOrder>();
            nbapisdk_HotelOrder ho = new nbapisdk_HotelOrder();
            string sql = "select [orderId],[statusCode],[hotelId],[roomTypeId],[ratePlanId],[checkInDate]," +//6
                "[checkOutDate],[elongCardNo],[guestTypeCode],[roomAmount],[guestAmount],[paymentTypeCode]," +//6
                "[arrivalEarlyTime],[arrivalLateTime],[currencyCode],[totalPrice],[guaranteeCurrencyCode],[guaranteeMoney]," +//6
                "[confirmTypeCode],[confirmLanguageCode],[noteToHotel],[noteToElong],[_default_],[guestsName]," +//6
                "[contacterName],[contacterGender],[contacterEmail],[contacterMobile],[contacterPhone],[contacterFax] " +//6
                "from [nbapisdk_HotelOrder] where _default_=:memid ";
            var query = session.CreateSQLQuery(sql).SetParameter("memid", memid);
            var result = query.List<object[]>();
            foreach (var item in result)
            {
                ho = new nbapisdk_HotelOrder();
                ho.orderid = item[0].ToString();
                ho.statuscode = item[1].ToString();
                ho.hotelid = item[2].ToString();
                ho.roomtypeid = item[3].ToString();
                ho.rateplanid = int.Parse(item[4].ToString());
                ho.checkindate = DateTime.Parse(item[5].ToString());
                ho.checkoutdate = DateTime.Parse(item[6].ToString());
                ho.elongcardno = item[7].ToString();
                ho.guesttypecode = int.Parse(item[8].ToString());
                ho.roomamount = int.Parse(item[9].ToString());
                ho.guestamount = int.Parse(item[10].ToString());
                ho.paymenttypecode = int.Parse(item[11].ToString());
                ho.arrivalearlytime = DateTime.Parse(item[12].ToString());
                ho.arrivallatetime = DateTime.Parse(item[13].ToString());
                ho.currencycode = item[14].ToString();
                ho.totalprice = decimal.Parse(item[15].ToString());
                ho.guaranteecurrencycode = item[16].ToString();
                ho.guaranteemoney = decimal.Parse(item[17].ToString());
                ho.confirmtypecode = item[18].ToString();
                ho.confirmlanguagecode = item[19].ToString();
                ho.notetohotel = item[20].ToString();
                ho.notetoelong = item[21].ToString();
                ho._default_ = item[22].ToString();
                ho.guestsname = item[23].ToString();
                ho.contactername = item[24].ToString();
                ho.contactergender = int.Parse(item[25].ToString());
                ho.contacteremail = item[26].ToString();
                ho.contactermobile = item[27].ToString();
                ho.contacterphone = item[28].ToString();
                ho.contacterfax = item[29].ToString();
                holist.Add(ho);
            }
            return holist;
        }
    }
}
