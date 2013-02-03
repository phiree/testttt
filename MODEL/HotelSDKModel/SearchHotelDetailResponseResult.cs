using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    public class SearchHotelDetailResponseResult
    {
        public SearchHotelListResponseResult SearchHotelListResponseResult { get; set; }

        public SearchHotelDetailRequestCondition SearchHotelDetailRequestCondition { get; set; }

        /// <summary>
        /// 酒店的图片集合
        /// </summary>
        public List<string> HotelImages { get; set; }

        /// <summary>
        /// 酒店一些简单的信息
        /// </summary>
        public HotelDetail HotelDetialStaticInfo { get; set; }

        public string HotelImageUrl { get; set; }
    }
}
