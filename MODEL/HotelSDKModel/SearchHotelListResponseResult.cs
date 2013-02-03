using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HotelModel.HotelSDKModel
{
    public class SearchHotelListResponseResult
    {

        public List<HotelForGetHotelList> Hotels { get; set; }
        public int HotelCount { get; set; }
        public List<Geo> GeoList { get; set; }
        public SearchHotelListRequestCondition SearchHotelListRequestCondition { get; set; }
    }
    public class HotelForGetHotelList
    {
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 酒店房态0-正常 1-部分日期满房，2-全部满房
        /// </summary>
        public string HotelInvStatusCode { get; set; }

        /// <summary>
        /// 酒店ID
        /// </summary>
        public string HotelId { get; set; }
        /// <summary>
        /// 酒店星级
        /// </summary>
        public string HotelStar { get; set; }
        /// <summary>
        /// 酒店地址
        /// </summary>
        public string HotelAddress { get; set; }
        /// <summary>
        /// 酒店标签
        /// </summary>
        public string HotelLabel { get; set; }
        /// <summary>
        /// 酒店最低价
        /// </summary>
        public string LowestPrice { get; set; }
        /// <summary>
        /// 酒店区域
        /// </summary>
        public string HotelArea { get; set; }
        /// <summary>
        /// 酒店好评率
        /// </summary>
        public string HotelGoodRate { get; set; }
        /// <summary>
        /// 酒店评论总数
        /// </summary>
        public string HotelCommentSum { get; set; }
        /// <summary>
        /// 酒店最新预定时间
        /// </summary>
        public DateTime HotelLastestOrderTime { get; set; }

        /// <summary>
        /// 酒店图片Url
        /// </summary>
        public string HotelImageUrl { get; set; }
        /// <summary>
        /// 酒店房型集合
        /// </summary>
        public List<RoomForGetHotelList> Rooms { get; set; }
        /// <summary>
        /// 酒店促销信息集合
        /// </summary>
        public List<PromotionForGetHotelList> HotelPromotions { get; set; }

        /// <summary>
        /// 担保情况
        /// </summary>
        public GaranteeCase GaranteeCase { get; set; }
        private bool isNational = false;
        /// <summary>
        ///  是否需要输入国籍，在那下单的那里用到 true需要填写国籍
        /// </summary>
        public bool IsNational { get { return isNational; } set { isNational = value; } }
    }

    public class PromotionForGetHotelList
    {

        /// <summary>
        /// 活动描述
        /// </summary>
        public string Description { get; set; }

    }

    public class DRRRuleForGetHotelList
    {
        public int DRRRuleTypeCode { get; set; }
        public List<DictionaryEntry> RuleValues { get; set; }
        public string Description { get; set; }
        public string RoomTypeIds { get; set; }
    }

    public class BookingRuleForGetHotelList
    {
        public int BookingRuleTypeCode { get; set; }
        public List<DictionaryEntry> RuleValues { get; set; }
        public string Description { get; set; }
        public string RoomTypeID { get; set; }
    }

    public class GaranteeRuleForGetHotelList
    {
        public int GaranteeRulesTypeCode { get; set; }
        public List<DictionaryEntry> RuleValues { get; set; }
        public string Description { get; set; }
    }

    public class AddValueForGetHotelList
    {
        /// <summary>
        /// 增值服务ID
        /// </summary>
        public int AddValueID { get; set; }
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCode { get; set; }
        /// <summary>
        /// 是否包含在房费中0-不包含 1-包含
        /// </summary>
        public int IsInclude { get; set; }
        /// <summary>
        /// 包含的份数
        /// </summary>
        public int IncludedCount { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 单价默认选项 1-金额，2-比例
        /// </summary>
        public int PriceDefaultOption { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal PriceNumber { get; set; }
        /// <summary>
        /// 是否单加
        /// </summary>
        public int IsAdd { get; set; }
        /// <summary>
        /// 单加单价默认选项 1-金额，2-比例
        /// </summary>
        public int SinglePriceOption { get; set; }
        /// <summary>
        /// 单加单价
        /// </summary>
        public decimal SinglePrice { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }

    public class RateForGetHotelList
    {
        /// <summary>
        /// 对应日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 每日房态
        /// </summary>
        public string InvStatusCode { get; set; }
        /// <summary>
        /// 门市价
        /// </summary>
        public decimal RetailRate { get; set; }
        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal MemberRate { get; set; }
        /// <summary>
        /// 加床价格
        /// </summary>
        public decimal AddBedRate { get; set; }


    }

    public class RatesForGetHotelList
    {
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 日均价
        /// </summary>
        public string AverageRate { get; set; }
        //货币代码
        public string CurrencyCode { get; set; }

        public List<RateForGetHotelList> rates { get; set; }
    }

    public class RatePlanForGetHotelList
    {
        public int RatePlanID { get; set; }
        public string RatePlanName { get; set; }
        public string GuestTypeCode { get; set; }
        public RatesForGetHotelList Rates { get; set; }
        public List<GaranteeRuleForGetHotelList> GaranteeRules { get; set; }
        public List<BookingRuleForGetHotelList> BookingRuless { get; set; }
        public List<AddValueForGetHotelList> AddValues { get; set; }
        public List<string> AddValuesDescription { get; set; }
        public List<DRRRuleForGetHotelList> DRRRules { get; set; }
        public List<PromotionForGetHotelList> HotelPromotions { get; set; }


    }


    public class RoomForGetHotelList
    {
        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 房型ID
        /// </summary>
        public string RoomTypeId { get; set; }
        /// <summary>
        /// 房型房态0-正常 1-部分日期满房，2-全部满房
        /// </summary>
        public string RoomInvStatusCode { get; set; }
        /// <summary>
        /// 床
        /// </summary>
        public string Bed { get; set; }

        /// <summary>
        /// 宽带
        /// </summary>
        public string Internet { get; set; }
        /// <summary>
        /// 早餐
        /// </summary>
        public string Breakfast { get; set; }
        /// <summary>
        /// 选项
        /// </summary>
        public List<RatePlanForGetHotelList> RatePlans { get; set; }
    }

}
