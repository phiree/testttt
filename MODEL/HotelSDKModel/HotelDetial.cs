using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    public class HotelDetail
    {
        /// <summary>
        /// 酒店简介
        /// </summary>
        public string HotelIntro { get; set; }

        /// <summary>
        /// 酒店支付方式
        /// </summary>
        public string HotelPayMent { get; set; }

        /// <summary>
        /// 酒店提供的服务
        /// </summary>
        public string HotelService { get; set; }
    }
}
