using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    public class SearchHotelDetailRequestCondition
    {
        /// <summary>
        /// 入住日期,日期有效，建议入住日期和离店日期不要超过20天
        /// 且不能早于昨天
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// 离店日期，离店日期大于入住日期
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        public string HotelID { get; set; }
        /// <summary>
        /// 酒店ID ，2、城市ID,酒店名称，酒店ID至少有一个不为空， 
        /// 如果hotelname不为空，cityid也不能为空。 3、酒店ID为多个时, 
        /// ID之间可用英文逗号分隔，建议酒店ID最多有10个
        /// </summary> 
        public SearchHotelListRequestCondition SearchHotelListRequestCondition { get; set; }

    }
}
