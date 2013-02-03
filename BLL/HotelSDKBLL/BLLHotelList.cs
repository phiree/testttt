using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elong2 = BLL.NorthBoundAPIService;
using HotelModel.HotelSDKModel;
using System.Collections;
using HotelModel.HotelDB; 

namespace BLL
{
    public class BLLHotelList
    {
        DAL.DALHotel DataBaseManager = new DAL.DALHotel();

        /// <summary>
        /// 为下订单查询hotellist
        /// </summary>
        /// <param name="SearchHotelListRequestCondition"></param>
        /// <returns></returns>
        public SearchHotelListResponseResult GetHotelList(SearchHotelListRequestCondition SearchHotelListRequestCondition)
        {
            SearchHotelListResponseResult SearchHotelListResponseResult = new SearchHotelListResponseResult();
            SearchHotelListResponseResult.SearchHotelListRequestCondition = SearchHotelListRequestCondition;
            Elong2.GetHotelListResponse Response = new Elong2.GetHotelListResponse();

            #region ELongNBAPI
            Response = ELongNBAPI_HotelList(SearchHotelListRequestCondition);
            #endregion
            if (Response.ResponseHead.ResultCode == "0")//返回成功，解析返回内容
            {
                SearchHotelListResponseResult.HotelCount = Response.HotelCount;

                if (Response.HotelCount > 0)
                {
                    List<HotelForGetHotelList> WebHotelList = new List<HotelForGetHotelList>();
                    foreach (Elong2.HotelForGetHotelList hotel in Response.Hotels)
                    {
                        HotelForGetHotelList WebHotel = new HotelForGetHotelList();
                        WebHotel.HotelAddress = hotel.HotelAddress;
                        WebHotel.HotelArea = GetHotelCommercialAreaName(hotel.HotelId);
                        WebHotel.HotelCommentSum = "369";
                        WebHotel.HotelGoodRate = "99%";
                        WebHotel.HotelId = hotel.HotelId;
                        WebHotel.HotelImageUrl = GetHotelOneImgExteriorUrl(hotel.HotelId);
                        WebHotel.HotelInvStatusCode = hotel.HotelInvStatusCode;
                        WebHotel.HotelLabel = "酒店标签从本地数据库读取";
                        WebHotel.HotelLastestOrderTime = DateTime.Now;
                        WebHotel.HotelName = hotel.HotelName;
                        WebHotel.HotelStar = hotel.StarCode;
                        WebHotel.LowestPrice = hotel.LowestPrice.ToString();
                        List<PromotionForGetHotelList> WebPromotins = new List<PromotionForGetHotelList>();
                        if (hotel.HotelPromotions != null && hotel.HotelPromotions.Count() > 0)
                        {

                            foreach (Elong2.PromotionForGetHotelList p in hotel.HotelPromotions)
                            {
                                PromotionForGetHotelList WebPromotion = new PromotionForGetHotelList();
                                WebPromotion.Description = p.Description;
                                WebPromotins.Add(WebPromotion);
                            }
                        }

                        WebHotel.HotelPromotions = WebPromotins;
                        List<RoomForGetHotelList> WebRooms = new List<RoomForGetHotelList>();

                        if (hotel.Rooms != null && hotel.Rooms.Count() > 0)
                        {
                            foreach (Elong2.RoomForGetHotelList Room in hotel.Rooms)
                            {
                                RoomPartInfo RoomPartInfo = GetRoomPartInfo(hotel.HotelId, Room.RoomTypeId);
                                RoomForGetHotelList WebRoom = new RoomForGetHotelList();

                                WebRoom.Bed = RoomPartInfo.Bed == null ? "" : RoomPartInfo.Bed;
                                WebRoom.Internet = RoomPartInfo.Internet == null ? "" : RoomPartInfo.Internet;
                                WebRoom.RoomInvStatusCode = Room.RoomInvStatusCode == "0" ? "有房" : "无房";
                                WebRoom.RoomName = Room.RoomName;
                                WebRoom.RoomTypeId = Room.RoomTypeId;
                                #region RatePlan

                                List<RatePlanForGetHotelList> WebRatePlans = new List<RatePlanForGetHotelList>();
                                if (Room.RatePlans != null && Room.RatePlans.Count() > 0)
                                {
                                    foreach (Elong2.RatePlanForGetHotelList rateplan in Room.RatePlans)
                                    {
                                        RatePlanForGetHotelList WebRatePlan = new RatePlanForGetHotelList();
                                        WebRatePlan.RatePlanID = rateplan.RatePlanID;
                                        WebRatePlan.RatePlanName = rateplan.RatePlanName;
                                        List<PromotionForGetHotelList> WebRatePlanPromotions = new List<PromotionForGetHotelList>();
                                        foreach (Elong2.PromotionForGetHotelList p in rateplan.HotelPromotions)
                                        {
                                            PromotionForGetHotelList WebRatePlanPromotion = new PromotionForGetHotelList();
                                            WebRatePlanPromotion.Description = p.Description;
                                            WebRatePlanPromotions.Add(WebRatePlanPromotion);
                                        }
                                        WebRatePlan.HotelPromotions = WebRatePlanPromotions;

                                        RatesForGetHotelList WebRates = new RatesForGetHotelList();
                                        WebRates.TotalPrice = rateplan.Rates.TotalPrice;
                                        string AverageRate = "0";
                                        List<RateForGetHotelList> WebRateList = new List<RateForGetHotelList>();
                                        if (rateplan.Rates.rates != null && rateplan.Rates.rates.Count() > 0)
                                        {
                                            foreach (Elong2.RateForGetHotelList rate in rateplan.Rates.rates)
                                            {
                                                RateForGetHotelList webrate = new RateForGetHotelList();
                                                webrate.AddBedRate = rate.AddBedRate;
                                                webrate.CurrencyCode = rate.CurrencyCode;
                                                webrate.Date = rate.Date;
                                                webrate.InvStatusCode = rate.InvStatusCode;
                                                webrate.MemberRate = rate.MemberRate;
                                                webrate.RetailRate = rate.RetailRate;

                                                WebRateList.Add(webrate);
                                            }
                                            #region 日均价计算
                                            int effectiveRate = rateplan.Rates.rates.Where(p => p.MemberRate != -1 || p.InvStatusCode == "0").Count();
                                            decimal TotalPrice = rateplan.Rates.TotalPrice;
                                            if (effectiveRate == 0) effectiveRate = 1;
                                            AverageRate = (TotalPrice / effectiveRate).ToString("0");//日均价 
                                            #endregion
                                        }

                                        WebRates.AverageRate = AverageRate;
                                        WebRates.rates = WebRateList;
                                        WebRatePlan.Rates = WebRates;
                                        WebRatePlans.Add(WebRatePlan);

                                    }
                                }
                                WebRoom.RatePlans = WebRatePlans;
                                #endregion
                                WebRooms.Add(WebRoom);
                            }
                        }
                        WebHotel.Rooms = WebRooms;
                        WebHotelList.Add(WebHotel);
                    }
                    SearchHotelListResponseResult.Hotels = WebHotelList;
                }

            }

            #region 获得geo信息
            BLLGeo geoservice = new BLLGeo();
            List<Geo> geo = geoservice.GetCommercialCeo(SearchHotelListRequestCondition.CityId);
            SearchHotelListResponseResult.GeoList = geo;
            #endregion

            return SearchHotelListResponseResult;
        }

        public SearchHotelListResponseResult GetHotelListForOrder(SearchHotelListRequestCondition SearchHotelListRequestCondition)
        {
            SearchHotelListResponseResult SearchHotelListResponseResult = new SearchHotelListResponseResult();
            SearchHotelListResponseResult.SearchHotelListRequestCondition = SearchHotelListRequestCondition;
            Elong2.GetHotelListResponse Response = new Elong2.GetHotelListResponse();

            #region ELongNBAPI
            Response = ELongNBAPI_HotelList(SearchHotelListRequestCondition);
            #endregion
            if (Response.ResponseHead.ResultCode == "0")//返回成功，解析返回内容
            {
                SearchHotelListResponseResult.HotelCount = Response.HotelCount;

                if (Response.HotelCount > 0)
                {
                    List<HotelForGetHotelList> WebHotelList = new List<HotelForGetHotelList>();
                    foreach (Elong2.HotelForGetHotelList hotel in Response.Hotels)
                    {
                        if (hotel.HotelInvStatusCode != "0") continue;//只展示启用的酒店
                        HotelForGetHotelList WebHotel = new HotelForGetHotelList();
                        WebHotel.HotelImageUrl = GetHotelOneImgExteriorUrl(hotel.HotelId);
                        WebHotel.HotelAddress = hotel.HotelAddress;
                        WebHotel.HotelId = hotel.HotelId;
                        WebHotel.HotelName = hotel.HotelName;
                        WebHotel.HotelStar = hotel.StarCode;
                        WebHotel.LowestPrice = hotel.LowestPrice.ToString();
                        List<PromotionForGetHotelList> WebPromotins = new List<PromotionForGetHotelList>();
                        if (hotel.HotelPromotions != null && hotel.HotelPromotions.Count() > 0)
                        {

                            foreach (Elong2.PromotionForGetHotelList p in hotel.HotelPromotions)
                            {
                                PromotionForGetHotelList WebPromotion = new PromotionForGetHotelList();
                                WebPromotion.Description = p.Description;
                                WebPromotins.Add(WebPromotion);
                            }
                        }

                        WebHotel.HotelPromotions = WebPromotins;
                        List<RoomForGetHotelList> WebRooms = new List<RoomForGetHotelList>();

                        if (hotel.Rooms != null && hotel.Rooms.Count() > 0)
                        {
                            foreach (Elong2.RoomForGetHotelList Room in hotel.Rooms)
                            {
                                RoomPartInfo RoomPartInfo = GetRoomPartInfo(hotel.HotelId, Room.RoomTypeId);
                                RoomForGetHotelList WebRoom = new RoomForGetHotelList();

                                WebRoom.Bed = RoomPartInfo.Bed == null ? "" : RoomPartInfo.Bed;
                                WebRoom.Internet = RoomPartInfo.Internet == null ? "" : RoomPartInfo.Internet;
                                WebRoom.RoomInvStatusCode = Room.RoomInvStatusCode == "0" ? "有房" : "无房";
                                WebRoom.RoomName = Room.RoomName;
                                WebRoom.RoomTypeId = Room.RoomTypeId;
                                #region RatePlan

                                List<RatePlanForGetHotelList> WebRatePlans = new List<RatePlanForGetHotelList>();
                                if (Room.RatePlans != null && Room.RatePlans.Count() > 0)
                                {
                                    foreach (Elong2.RatePlanForGetHotelList rateplan in Room.RatePlans)
                                    {
                                        RatePlanForGetHotelList WebRatePlan = new RatePlanForGetHotelList();
                                        WebRatePlan.RatePlanID = rateplan.RatePlanID;
                                        WebRatePlan.RatePlanName = rateplan.RatePlanName;
                                        #region 促销Promotion
                                        List<PromotionForGetHotelList> WebRatePlanPromotions = new List<PromotionForGetHotelList>();
                                        foreach (Elong2.PromotionForGetHotelList p in rateplan.HotelPromotions)
                                        {
                                            PromotionForGetHotelList WebRatePlanPromotion = new PromotionForGetHotelList();
                                            WebRatePlanPromotion.Description = p.Description;
                                            WebRatePlanPromotions.Add(WebRatePlanPromotion);
                                        }
                                        #endregion
                                        WebRatePlan.HotelPromotions = WebRatePlanPromotions;

                                        #region 促销DRR
                                        List<DRRRuleForGetHotelList> WebDRRs = new List<DRRRuleForGetHotelList>();
                                        if (rateplan.DRRRules != null && rateplan.DRRRules.Count() > 0)
                                        {
                                            foreach (Elong2.DRRRuleForGetHotelList drr in rateplan.DRRRules)
                                            {
                                                DRRRuleForGetHotelList WebDRR = new DRRRuleForGetHotelList();
                                                WebDRR.Description = drr.Description;
                                                WebDRRs.Add(WebDRR);
                                            }
                                        }
                                        #endregion
                                        WebRatePlan.DRRRules = WebDRRs;

                                        #region 担保
                                        List<GaranteeRuleForGetHotelList> Garantees = new List<GaranteeRuleForGetHotelList>();
                                        GaranteeCase GaranteeCase = new GaranteeCase();
                                        if (rateplan.GaranteeRules != null && rateplan.GaranteeRules.Count() > 0)
                                        {
                                            foreach (Elong2.GaranteeRuleForGetHotelList gar in rateplan.GaranteeRules)
                                            {
                                                GaranteeRuleForGetHotelList WebGarantee = new GaranteeRuleForGetHotelList();
                                                WebGarantee.GaranteeRulesTypeCode = gar.GaranteeRulesTypeCode;
                                                List<DictionaryEntry> dicentrys = new List<DictionaryEntry>();
                                                if (gar.RuleValues != null && gar.RuleValues.Count() > 0)
                                                {
                                                    foreach (Elong2.DictionaryEntry dic in gar.RuleValues)
                                                    {
                                                        DictionaryEntry webdic = new DictionaryEntry();
                                                        webdic.Key = dic.Key;
                                                        webdic.Value = dic.Value;
                                                        dicentrys.Add(webdic);
                                                    }
                                                    #region 分析担保情况
                                                    GaranteeCase.IsGarantee = true;
                                                    string IsArriveTimeVouch = dicentrys.SingleOrDefault(p => p.Key.ToString() == "IsArriveTimeVouch").Value.ToString();
                                                    string IsRoomCountVouch = dicentrys.SingleOrDefault(p => p.Key.ToString() == "IsRoomCountVouch").Value.ToString();
                                                    //无条件担保
                                                    if (IsArriveTimeVouch == "0" && IsRoomCountVouch == "0")
                                                    {
                                                        GaranteeCase.GaranteeType = 0;
                                                    }
                                                    //日期担保
                                                    else if (IsArriveTimeVouch == "1" && IsRoomCountVouch == "0")
                                                    {
                                                        GaranteeCase.GaranteeType = 1;

                                                    }
                                                    //房量担保
                                                    else if (IsArriveTimeVouch == "0" && IsRoomCountVouch == "1")
                                                    {
                                                        GaranteeCase.GaranteeType = 2;

                                                    }
                                                    //日期+房量担保
                                                    else
                                                    {
                                                        GaranteeCase.GaranteeType = 3;
                                                    }
                                                    GaranteeCase.ArriveStatTime = dicentrys.SingleOrDefault(p => p.Key.ToString() == "ArriveStatTime").Value.ToString();
                                                    GaranteeCase.ArriveEndTime = dicentrys.SingleOrDefault(p => p.Key.ToString() == "ArriveEndTime").Value.ToString();
                                                    GaranteeCase.RoomCount = int.Parse(dicentrys.SingleOrDefault(p => p.Key.ToString() == "RoomCount").Value.ToString());

                                                    #endregion
                                                }
                                                WebGarantee.RuleValues = dicentrys;
                                                WebGarantee.Description = gar.Description;
                                                Garantees.Add(WebGarantee);
                                            }

                                        }
                                        WebHotel.GaranteeCase = GaranteeCase;
                                        #endregion
                                        WebRatePlan.GaranteeRules = Garantees;
                                        #region 附加服务
                                        WebRatePlan.AddValuesDescription = rateplan.AddValuesDescription.ToList();
                                        #endregion

                                        #region 预定规则
                                        List<BookingRuleForGetHotelList> Bookings = new List<BookingRuleForGetHotelList>();
                                        if (rateplan.BookingRuless != null && rateplan.BookingRuless.Count() > 0)
                                        {
                                            foreach (Elong2.BookingRuleForGetHotelList booking in rateplan.BookingRuless)
                                            {
                                                BookingRuleForGetHotelList Webbooking = new BookingRuleForGetHotelList();
                                                Webbooking.Description = booking.Description;
                                                Webbooking.BookingRuleTypeCode = booking.BookingRuleTypeCode;
                                                if (booking.BookingRuleTypeCode == 1)//下单的时候需要填写国籍
                                                {
                                                    WebHotel.IsNational = true;
                                                }
                                                Bookings.Add(Webbooking);

                                            }
                                        }
                                        #endregion
                                        WebRatePlan.BookingRuless = Bookings;

                                        #region 价格
                                        RatesForGetHotelList WebRates = new RatesForGetHotelList();
                                        WebRates.TotalPrice = rateplan.Rates.TotalPrice;
                                        List<RateForGetHotelList> WebRateList = new List<RateForGetHotelList>();
                                        if (rateplan.Rates.rates != null && rateplan.Rates.rates.Count() > 0)
                                        {
                                            foreach (Elong2.RateForGetHotelList rate in rateplan.Rates.rates)
                                            {
                                                RateForGetHotelList webrate = new RateForGetHotelList();
                                                webrate.AddBedRate = rate.AddBedRate;
                                                webrate.CurrencyCode = rate.CurrencyCode;
                                                WebRates.CurrencyCode = rate.CurrencyCode;
                                                webrate.Date = rate.Date;
                                                webrate.InvStatusCode = rate.InvStatusCode;
                                                webrate.MemberRate = rate.MemberRate;
                                                webrate.RetailRate = rate.RetailRate;

                                                WebRateList.Add(webrate);
                                            }

                                        }

                                        WebRates.rates = WebRateList;
                                        #endregion

                                        #region 宾客类型
                                        WebRatePlan.GuestTypeCode = rateplan.GuestTypeCode;
                                        #endregion
                                        WebRatePlan.Rates = WebRates;


                                        WebRatePlans.Add(WebRatePlan);

                                    }
                                }
                                WebRoom.RatePlans = WebRatePlans;
                                #endregion
                                WebRooms.Add(WebRoom);
                            }
                        }
                        WebHotel.Rooms = WebRooms;
                        WebHotelList.Add(WebHotel);
                    }
                    SearchHotelListResponseResult.Hotels = WebHotelList;
                }

            }



            return SearchHotelListResponseResult;
        }


        private Elong2.GetHotelListResponse ELongNBAPI_HotelList(SearchHotelListRequestCondition SearchHotelListRequestCondition)
        {
            Elong2.GetHotelListResponse Response = new Elong2.GetHotelListResponse();
            Elong2.NorthBoundAPIServiceSoapClient client = new Elong2.NorthBoundAPIServiceSoapClient();
            Elong2.LoginRequest loginreq = new Elong2.LoginRequest();
            loginreq.UserName = System.Configuration.ConfigurationManager.AppSettings["NB_UserName"].ToString();
            loginreq.Password = System.Configuration.ConfigurationManager.AppSettings["NB_Pwd"].ToString();

            Elong2.LoginResponse loginres = new Elong2.LoginResponse();
            loginres = client.Login(loginreq);
            Elong2.GetHotelListRequest HotelListReq = new Elong2.GetHotelListRequest();
            Elong2.RequestHead RequestHead = new Elong2.RequestHead();
            RequestHead.Language = "CN";
            RequestHead.LoginToken = loginres.LoginToken.ToString();
            HotelListReq.RequestHead = RequestHead;
            Elong2.GetHotelConditionForGetHotelList GetHotelConditionForGetHotelList = new Elong2.GetHotelConditionForGetHotelList();
            GetHotelConditionForGetHotelList.CheckInDate = SearchHotelListRequestCondition.CheckInDate;
            GetHotelConditionForGetHotelList.CheckOutDate = SearchHotelListRequestCondition.CheckOutDate;
            GetHotelConditionForGetHotelList.CityId = SearchHotelListRequestCondition.CityId;
            GetHotelConditionForGetHotelList.CommercialLocationId = SearchHotelListRequestCondition.CommercialLocationId;
            GetHotelConditionForGetHotelList.HighestRate = SearchHotelListRequestCondition.HighestRate;
            GetHotelConditionForGetHotelList.LowestRate = SearchHotelListRequestCondition.LowestRate;
            GetHotelConditionForGetHotelList.MaxRows = SearchHotelListRequestCondition.MaxRows;
            GetHotelConditionForGetHotelList.PageIndex = SearchHotelListRequestCondition.PageIndex;
            GetHotelConditionForGetHotelList.HotelName = SearchHotelListRequestCondition.HotelName;
            GetHotelConditionForGetHotelList.HotelId = SearchHotelListRequestCondition.HotelId;
            GetHotelConditionForGetHotelList.StarCode = SearchHotelListRequestCondition.StarCode;
            GetHotelConditionForGetHotelList.RoomTypeID = SearchHotelListRequestCondition.RoomTypeID;
            GetHotelConditionForGetHotelList.RatePlanID = SearchHotelListRequestCondition.RatePlanID;
            HotelListReq.GetHotelCondition = GetHotelConditionForGetHotelList;

            Response = client.GetHotelList(HotelListReq);
            return Response;
        }

        //获取当地酒店列表
        public IList<HotelModel.HotelDB.nbapisdk_Hotel> GetHotelListLocal(SearchHotelListRequestCondition searchHotelListRequestCondition)
        {
            IList<HotelModel.HotelDB.nbapisdk_Hotel> hotestlist = new List<HotelModel.HotelDB.nbapisdk_Hotel>();
            return DataBaseManager.GetHotels(searchHotelListRequestCondition);
        }

        //酒店商区图片
        public string GetHotelCommercialAreaName(string HotelId)
        {
            return DataBaseManager.GetHotelCommercialAreaName(HotelId);
        }

        //酒店图片
        public string GetHotelOneImgExteriorUrl(string HotelId)
        {
            return DataBaseManager.GetHotelOneImgExteriorUrl(HotelId);
        }

        //酒店图片
        public string GetHotelOneImgExteriorUrlForDetail(string HotelId)
        {
            return DataBaseManager.GetHotelOneImgExteriorUrlForDetail(HotelId);
        }

        //房间信息
        public RoomPartInfo GetRoomPartInfo(string HetelId, string RoomtypeId)
        {
            return DataBaseManager.GetRoomPartInfo(HetelId, RoomtypeId);
        }

        #region 酒店详情

        //获得酒店详情
        public SearchHotelDetailResponseResult GetHotelDetail(SearchHotelDetailRequestCondition SearchHotelDetailRequestCondition)
        {
            SearchHotelDetailResponseResult SearchHotelDetailResponseResult = new SearchHotelDetailResponseResult();

            SearchHotelDetailResponseResult.SearchHotelListResponseResult = GetHotelList(new SearchHotelListRequestCondition() { CheckInDate = SearchHotelDetailRequestCondition.CheckInDate, CheckOutDate = SearchHotelDetailRequestCondition.CheckOutDate, HotelId = SearchHotelDetailRequestCondition.HotelID });
            SearchHotelDetailResponseResult.HotelImages = GetHotelImages(SearchHotelDetailRequestCondition.HotelID);
            SearchHotelDetailResponseResult.HotelDetialStaticInfo = GetHotelDetailStaticInfo(SearchHotelDetailRequestCondition.HotelID);
            SearchHotelDetailResponseResult.SearchHotelDetailRequestCondition = SearchHotelDetailRequestCondition;
            SearchHotelDetailResponseResult.HotelImageUrl = GetHotelOneImgExteriorUrl(SearchHotelDetailRequestCondition.HotelID);

            return SearchHotelDetailResponseResult;
        }

        public List<string> GetHotelImages(string hotelid)
        {
            return DataBaseManager.GetHotelImages(hotelid);
        }


        public HotelDetail GetHotelDetailStaticInfo(string hotelid)
        {
            return DataBaseManager.GetHotelDetailStaticInfo(hotelid);
        }

        public nbapisdk_SuperHotel GetTotalHotelDetailStaticInfo(string hotelid)
        {
            return DataBaseManager.GetTotalHotelDetailStaticInfo(hotelid);
        }
        #endregion
    }
}
