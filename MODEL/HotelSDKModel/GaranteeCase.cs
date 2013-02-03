using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    /// <summary>
    /// 担保情况
    /// </summary>
    public class GaranteeCase
    {
        private bool isGarantee = false;
        /// <summary>
        /// 是否要担保 是true 
        /// </summary>
        public bool IsGarantee { get; set; }
        /// <summary>
        /// 担保类型 0为无条件担保
        /// 1为日期担保
        /// 2为房量担保
        /// 3日期+房量担保
        /// </summary>
        public int GaranteeType { get; set; }

        /// <summary>
        /// 到店担保的开始时间
        /// </summary>
        public string ArriveStatTime { get; set; }
        /// <summary>
        /// 到店担保的结束时间
        /// </summary>
        public string ArriveEndTime { get; set; }

        /// <summary>
        /// 担保的房间数,预定几间房以上要担保
        /// </summary>
        public int RoomCount { get; set; }
    }
}
