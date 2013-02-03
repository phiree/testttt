using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    public class RoomDetailinfo
    {
        public string hotelId { get; set; }
        public string roomTypeId { get; set; }
        public string roomName { get; set; }
        public string area { get; set; }
        public string roomFloor { get; set; }

        public string hasInternet { get; set; }
        public string broadnetFee { get; set; }
        /// <summary>
        /// 床型
        /// </summary>
        public string bedType { get; set; }
        public string imgType { get; set; }
        public string title { get; set; }

        public string url_1 { get; set; }
        public string url_2 { get; set; }
        public string url_3 { get; set; }

        //后期附加值
        /// <summary>
        /// 日均价
        /// </summary>
        public string averageRate { get; set; }
        /// <summary>
        /// 是否有房
        /// </summary>
        public string roomInvStatusCode { get; set; }
        /// <summary>
        /// 价格选项Id
        /// </summary>
        public int ratePlanId { get; set; }
        /// <summary>
        /// 价格选项
        /// </summary>
        public string ratePlanName { get; set; }
    }
}
