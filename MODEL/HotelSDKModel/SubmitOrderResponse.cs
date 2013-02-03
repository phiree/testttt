using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.HotelSDKModel
{
    public class SubmitOrderResponse
    {
        private bool isSubmitOrderSucceed = false;
        /// <summary>
        /// 是否下单成功
        /// </summary>
        public bool IsSubmitOrderSucceed { get { return isSubmitOrderSucceed; } set { isSubmitOrderSucceed = value; } }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 最晚取消订单时间
        /// </summary>
        public DateTime CancelDeadline { get; set; }
        /// <summary>
        /// 如果此订单是担保订单，则在此列出担保金额，
        /// 币种是人民币(如果提交订单时候的是港币，
        /// 这里也会被换算成对应金额的人民币)。
        /// </summary>
        public decimal GuaranteeMoney { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
