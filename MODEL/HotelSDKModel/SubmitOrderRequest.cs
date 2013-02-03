using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    /// <summary>
    /// 下单请求类
    /// </summary>
    public class SubmitOrderRequest
    {
        /// <summary>
        /// 酒店ID 
        /// </summary>
        public string HotelId { get; set; }
        /// <summary>
        /// 房型ID 
        /// </summary>
        public string RoomTypeId { get; set; }
        /// <summary>
        /// RatePlanID 
        /// </summary>
        public string RatePlanID { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime CheckInDate { get; set; }
        /// <summary>
        /// 离店时间 
        /// </summary>
        public DateTime CheckOutDate { get; set; }
        /// <summary>
        /// 宾客类型代码 
        /// </summary>
        public string GuestTypeCode { get; set; }
        /// <summary>
        /// 房间数量 
        /// </summary>
        public int RoomAmount { get; set; }
        /// <summary>
        /// 入住人数 
        /// </summary>
        public int GuestAmount { get; set; }
        /// <summary>
        /// 最早到达时间 
        /// </summary>
        public DateTime ArrivalEarlyTime { get; set; }
        /// <summary>
        /// 最晚到达时间 
        /// </summary>
        public DateTime ArrivalLateTime { get; set; }
        /// <summary>
        /// 货币代码 
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 总价 
        /// </summary>
        public Decimal TotalPrice { get; set; }
        /// <summary>
        /// 订单确认方式 
        /// </summary>
        public string ConfirmTypeCode { get; set; }
        /// <summary>
        /// 订单确认语言 
        /// </summary>
        public string ConfirmLanguageCode { get; set; }
        /// <summary>
        /// 联系人名
        /// </summary>
        public string ContacterName { get; set; }
        /// <summary>
        ///联系人手机号
        /// </summary>
        public string ContacterMobile { get; set; }
        /// <summary>
        /// 入住人名字，以逗号分隔
        /// </summary>
        public string GuestNames { get; set; }
        /// <summary>
        /// 入住人国籍，以逗号分隔
        /// </summary>
        public string GuestNationals { get; set; }
        /// <summary>
        /// 信用卡号
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// 信用卡验证码
        /// </summary>
        public string VeryfyCode { get; set; }
        /// <summary>
        /// 有效期年 
        /// </summary>
        public int ValidYear { get; set; }
        /// <summary>
        /// 有效期月
        /// </summary>
        public int ValidMonth { get; set; }
        /// <summary>
        /// 持卡人姓名 
        /// </summary>
        public string CardHolderName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNumber { get; set; }


    }
}
