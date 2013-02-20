using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    /// <summary>
    /// 搜索条件
    /// </summary>
    public class SearchHotelListRequestCondition
    {
        /// <summary>
        /// 价格标示
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 入住日期,日期有效，建议入住日期和离店日期不要超过20天
        /// 且不能早于昨天
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// 离店日期，离店日期大于入住日期
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// 酒店名称，酒店名称可为酒店名称的一部分，比如，北京昆仑饭店，可以输入“北京昆仑”。
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// 酒店ID ，2、城市ID,酒店名称，酒店ID至少有一个不为空， 
        /// 如果hotelname不为空，cityid也不能为空。 3、酒店ID为多个时, 
        /// ID之间可用英文逗号分隔，建议酒店ID最多有10个
        /// </summary>
        public string HotelId { get; set; }

        /// <summary>
        /// 房型ID
        /// </summary>
        public string RoomTypeID { get; set; }

        /// <summary>
        /// RatePlanID 
        /// </summary>
        public int RatePlanID { get; set; }

        /// <summary>
        /// 星级代码 
        /// </summary>
        public string StarCode { get; set; }

        /// <summary>
        /// 产品最高价格  
        /// 1、字段为0则不限价 2、如搜200元以下，则HighestRate=200，
        /// LowestRate=0 3、如搜600元以上，则HighestRate=10000，
        /// LowestRate=600
        /// </summary>
        public int HighestRate { get; set; }

        /// <summary>
        /// 产品最低价格 
        /// </summary>
        public int LowestRate { get; set; }

        /// <summary>
        /// 位置查询模式  
        /// 0：不按位置搜索； 1：按矩形方式； 2：按点-半径方式
        /// </summary>
        public string PositionModeCode { get; set; }

        /// <summary>
        /// 起始经度
        /// 1、此5个字段作为地图搜索使用，在PositionModeCode=1或2时，使用此字段 
        /// </summary>
        public Decimal StartLongitude { get; set; }

        /// <summary>
        /// 起始纬度 
        /// </summary>
        public Decimal StartLatitude { get; set; }

        /// <summary>
        /// 终止经度 
        /// </summary>
        public Decimal EndLongitude { get; set; }

        /// <summary>
        /// 终止纬度 
        /// </summary>
        public Decimal EndLatitude { get; set; }

        /// <summary>
        /// 半径  单位为：米
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// 行政区ID  
        /// 如果按照这3个查询，则城市ID必须输入
        /// </summary>
        public string DistrictId { get; set; }

        /// <summary>
        /// 商业区ID  
        /// 如果按照这3个查询，则城市ID必须输入
        /// </summary>
        public string CommercialLocationId { get; set; }

        /// <summary>
        /// 标志物ID   
        /// 如果按照这3个查询，则城市ID必须输入
        /// </summary>
        public string LandmarkLocationID { get; set; }

        /// <summary>
        /// 排序标准  
        /// elong：默认 star：按星级（艺龙推荐星级）
        /// price：按价格 distance：按距离
        /// </summary>
        public string OrderByCode { get; set; }

        /// <summary>
        /// 分页页数 默认从1开始，如果使用PageIndex
        /// 则MaxRows需要设置值
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 最大返回记录数 
        /// </summary>
        public int MaxRows { get; set; }

        public string zipCode { get; set; }
    }
}
