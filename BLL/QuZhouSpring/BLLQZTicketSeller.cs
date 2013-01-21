using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using log4net;
namespace BLL
{
    //被抢一张票

    public class BLLQZTicketSeller
    {

        BLLMembership bllMembership = new BLLMembership();
        BLLTicketAssign bllTicketAssign = new BLLTicketAssign();
        BLLTicket bllTicket = new BLLTicket();
        BLLOrder bllOrder = new BLLOrder();
        BLLQZPartnerTicketAsign bllQZPartnerTicketAsign = new BLLQZPartnerTicketAsign();

        public string SellTicket(string clientFriendlyId, string idcardno, string ticketCode, int amount, string phone)
        { 
            return SellTicket(clientFriendlyId,null,string.Empty,idcardno,ticketCode,amount, phone);
        }
        public string SellTicket(string clientFriendlyId, TourMembership member,string assignName, string idcardno, string ticketCode, int amount, string phone)
        {


            string returnMsg = "T";
            //身份证号码验证
            string checkIdCardNoErrMsg;
            bool idcardnoValid = CommonLibrary.StringHelper.CheckIDCard(idcardno, out checkIdCardNoErrMsg);
            if (!idcardnoValid)
            {
                return "F|" + checkIdCardNoErrMsg;
            }
            DateTime nowDay = DateTime.Now.Date; 
            QZPartnerTicketAsign partnerAsign = bllQZPartnerTicketAsign.GetOne(nowDay, clientFriendlyId, ticketCode);//todo: 获取 某日期 某个门票 的票数分配情况
            if (partnerAsign == null)
            {
                return "F|没有查到对应的门票";
            }
            Guid requestGUID = Guid.NewGuid();
            TourLog.LogInstance.Info(string.Format("*********Begin********{5}出票请求:{0}_{1}_{2}_{3}_{4}", clientFriendlyId, idcardno, ticketCode, amount, phone, requestGUID));
            string validErrMsg;
            bool isValid = ValidateRequst(partnerAsign, amount, idcardno, ticketCode, out validErrMsg);
            if (!isValid)
            {
                return "F|" + validErrMsg;
            }
            if (member == null)
            {
                 member = bllMembership.GetMember(idcardno);

                if (member == null)
                {
                    //创建用户
                    member = bllMembership.CreateUser2("衢州门票派送参与者", phone, string.Empty, idcardno, idcardno, "123456", string.Empty);
                }
            }
            //自动创建订单
            Ticket currentTicket = bllTicket.GetByProductCode(ticketCode);
            Order order = BuildOrderForQZ(member,assignName, idcardno, currentTicket, amount, partnerAsign.Partner.Name);
            bllOrder.SaveOrUpdateOrder(order);

            //3 该接入商该景区的已售门票+1
            partnerAsign.SoldAmount += amount;
            bllQZPartnerTicketAsign.SaveOrUpdate(partnerAsign);
            TourLog.LogInstance.Info(returnMsg);
            TourLog.LogInstance.Info(requestGUID + "*********END********");
            return returnMsg;
        }
        /// <summary>
        /// 该出票请求是否能够通过.
        /// </summary>
        /// <param name="clientFriendlyId"></param>
        /// <param name="amount"></param>
        /// <param name="idcardno"></param>
        /// <param name="ticketCode"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private bool ValidateRequst(QZPartnerTicketAsign partnerAsign, int amount, string idcardno, string ticketCode, out string errMsg)
        {


            TourLog.LogInstance.Info("开始验证");

            errMsg = string.Empty;
            //验证这个分发商还有没有足够的门票

            CommonLibrary.ValidateHelper.verify_idcard(idcardno);

            bool hasEnough = partnerAsign.HasEnoughTickets(amount);
            if (!hasEnough) { errMsg = "该景区当天的门票已被抢完."; return false; }
            //验证这个身份证号码是否已经抢到一定数量的某种类型的门票,无法继续抢订.


            //是否已经抢到了足够的票数
            //ticket的 productcode 不为空的门票总数--> 
            //todo: 不太保险的判断
            IList<TicketAssign> gotTotalTicketsOfThisType = bllTicketAssign.GetTaByIdCard(idcardno).Where(x =>!string.IsNullOrEmpty( x.OrderDetail.TicketPrice.Ticket.ProductCode)).ToList();
            if (gotTotalTicketsOfThisType.Count >= 5)
            {
                //已经抢了5张这样的门票 
                errMsg = "该身份证号码已经抢到足够票数,不能继续抢票";
                return false;
            }
            else
            {
                if (gotTotalTicketsOfThisType.Where(x => x.OrderDetail.TicketPrice.Ticket.ProductCode == ticketCode).ToList().Count > 0)
                {
                    errMsg = "该身份证号码已经抢到这个景区的门票,不能继续抢票";
                    return false;
                }//该身份证已经抢到了这个门票

            }

            return true;
        }

        public Order BuildOrderForQZ(TourMembership member,string assignName,string idcardno, Ticket currentTicket, int amount, string parnterName)
        {
            #region 开始出票
            //1 为身份证号创建一个用户名

            TicketAssign ta = new TicketAssign();
            ta.IdCard = idcardno;
            ta.IsUsed = false;
            ta.Name = assignName;

            OrderDetail orderdetail = new OrderDetail();
            orderdetail.Quantity = amount;
            orderdetail.Remark = "衢州新春门票派送活动自动创建订单,请票来源:" + parnterName;
            orderdetail.TicketAssignList.Add(ta);

            TicketPrice ticketPrice = currentTicket.GetTicketPrice(PriceType.PayOnline);
            orderdetail.TicketPrice = ticketPrice;

            Order order = new Order();
            order.BuyTime = DateTime.Now;
            order.IsPaid = true;
            order.MemberId = member.Id;
            order.OrderDetail.Add(orderdetail);
            order.PayTime = DateTime.Now;
            order.PriceType = PriceType.PayOnline;
            order.PayTime = DateTime.Now;
            order.TradeNo = "QZFREE";

            return order;


            #endregion
        }


       

    }
}
