using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;
using Model;
namespace BLL
{
    /// <summary>
    /// 退款处理逻辑
    /// </summary>
    public class BLLRefund
    {
        //开始退款
        int orderId;
        Order order;
        private Order Order {
            get {
                if (order == null)
                { order = new BLLOrder().GetOrderByOrderid(orderId); }
                if (order == null)
                {
                    ErrHandler.Redirect(ErrType.ObjectIsNull,"获取订单数据失败,orderid:"+orderId);
                }
                return order;
            
            }
        }
        public string OrderIdstring
        {
            set
            {
                if (! int.TryParse(value, out orderId))
                {
                    ErrHandler.Redirect(ErrType.ParamIllegal,"orderid 不是数字");
                }
            }
        }

        public TourMembership Member
        {
            get;
            set;
        }
        public BLLRefund(TourMembership member,string  orderid)
        {
            this.Member = member;
            this.OrderIdstring = orderid;
        }
        DALRefund DalRefund = new DALRefund();

        /// <summary>
        /// 申请退款
        /// </summary>
        public string ApplyRefund()
        {
            Refund refund = new Refund();
            refund.ApplyTime = DateTime.Now;
            refund.Member = Member;
            refund.Order = Order;
            refund.RefundSerialNo = new BLLFormatSerialNo().GetSerialNo(TourConfig.RefundFlag);
            DalRefund.Save(refund);
           string html=  new BLLPayment().PayBack(refund);
           return html;
        }
        /// <summary>
        /// 支付宝api处理结果
        /// </summary>
        public void Receive(string refundSerialNo)
        { 
            
        }
    }
}