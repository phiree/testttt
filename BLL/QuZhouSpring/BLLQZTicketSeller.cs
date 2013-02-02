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
        DAL.DALQZPartnerTicketAsign dalPTA = new DAL.DALQZPartnerTicketAsign();
        /// <summary>
        /// 信息中心网站抢票
        /// </summary>
        /// <param name="clientFriendlyId"></param>
        /// <param name="idcardno"></param>
        /// <param name="realName"></param>
        /// <param name="phone"></param>
        /// <param name="ticketCode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public string SellTicket(string clientFriendlyId, string idcardno, string realName, string phone, string ticketCode, int amount)
        {
            return SellTicket(false, clientFriendlyId, null, realName, idcardno, phone, ticketCode, amount);
        }
        /// <summary>
        /// 重载基方法.
        /// </summary>
        /// <param name="ismedia"></param>
        /// <param name="clientFriendlyId"></param>
        /// <param name="member"></param>
        /// <param name="assignName"></param>
        /// <param name="idcardno"></param>
        /// <param name="phone"></param>
        /// <param name="ticketCode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public string SellTicket(bool ismedia, string clientFriendlyId, TourMembership member, string assignName, string idcardno, string phone, string ticketCode, int amount)
        {
            amount = 1;
            int nowHour = DateTime.Now.Hour;
            if (!ismedia)
            {
                if (nowHour < 10)
                {
                    return "F|亲,十点以后才可以抢票哦~";
                }

            }
            string returnMsg = "T";
            //身份证号码验证
            string checkIdCardNoErrMsg;
            bool idcardnoValid = CommonLibrary.StringHelper.CheckIDCard(idcardno, out checkIdCardNoErrMsg);
            if (!idcardnoValid)
            {
                return "F|" + checkIdCardNoErrMsg;
            }
            DateTime nowDay = DateTime.Now.Date;
            //获取当天合作商某景区的门票分配情况
            QZPartnerTicketAsign partnerAsign = bllQZPartnerTicketAsign.GetOne(nowDay, clientFriendlyId, ticketCode);//todo: 获取 某日期 某个门票 的票数分配情况
            if (partnerAsign == null)
            {
                return "F|没有查到对应的门票";
            }
            Guid requestGUID = Guid.NewGuid();
            TourLog.LogInstance.Info(string.Format("*********Begin********{5}出票请求:{0}_{1}_{2}_{3}_{4}", clientFriendlyId, idcardno, ticketCode, amount, phone, requestGUID));
            string validErrMsg;
            ///规则验证
            bool isValid = ValidateRequst(ismedia, partnerAsign, amount, idcardno, ticketCode, out validErrMsg);
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
            TicketBase currentTicket =  bllTicket.GetByProductCode(ticketCode);
            string partnername = partnerAsign.Partner.Name;
            //将媒体设置成合作者,
            //if (ismedia)
            //{
            //    partnerAsign.Partner.Name = "媒体";
            //}
            Order order = BuildOrderForQZ(member, assignName, idcardno, currentTicket, amount, partnername);
            bllOrder.SaveOrUpdateOrder(order);

            //3 该接入商该景区的已售门票+1
            //if (!ismedia)
            //{
            partnerAsign.SoldAmount += amount;
            // }
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
        private bool ValidateRequst(bool isMediaOrTaiZhou, QZPartnerTicketAsign partnerAsign, int amount, string idcardno, string ticketCode, out string errMsg)
        {


            TourLog.LogInstance.Info("开始验证");

            errMsg = string.Empty;
            //验证这个分发商还有没有足够的门票

            CommonLibrary.ValidateHelper.verify_idcard(idcardno);

            bool hasEnough = true;
            //台州和媒体: 判断是否超出总量
            if (isMediaOrTaiZhou)
            {
                int[] totalAssignedAndSold = dalPTA.GetTotalAssignAndSold(partnerAsign.Partner.FriendlyId, ticketCode);
                int totalAssigned = totalAssignedAndSold[0];
                int totalSold = totalAssignedAndSold[1];
                if (totalAssigned == -1)
                {
                    errMsg = string.Format("没有分配门票信息.partner:{0},ticketcode:{1}", partnerAsign.Partner.Name, ticketCode);
                    return false;
                }
                else
                {
                    if (totalSold + amount > totalAssigned)
                    {
                        errMsg = string.Format("门票已经全部派送.partner:{0},ticketcode:{1}", partnerAsign.Partner.Name, ticketCode);
                        return false;
                    }
                }
            }
            else
            {
                hasEnough = partnerAsign.HasEnoughTickets(amount);
                if (!hasEnough) { errMsg = "当天门票已被抢完,请明天再来"; return false; }
            }



            //验证这个身份证号码是否已经抢到一定数量的某种类型的门票,无法继续抢订.


            //是否已经抢到了足够的票数
            //ticket的 productcode 不为空的门票总数--> 
            //todo: 不太保险的判断

            //IList<TicketAssign> gotTotalTicketsOfThisType = listTa.Where(x => !string.IsNullOrEmpty(x.OrderDetail.TicketPrice.Ticket.ProductCode)).ToList();
            IList<TicketAssign> getAssignTicketForId = bllTicketAssign.GetTaByIdcardandTicketCode(idcardno, ticketCode);
            if (getAssignTicketForId.Count > 0)
            {

                errMsg = "该身份证号码已经抢到这个景区的门票,不能继续抢票";
                return false;
            }
            else
            {
                IList<object[]> gotTotalTicketsOfThisType = bllTicketAssign.GetTaByIdCardHasProductCodeBySql(idcardno);
                if (gotTotalTicketsOfThisType.Count >= 5)
                {
                    errMsg = "该身份证号码已经抢到足够票数,不能继续抢票";
                    return false;
                }
                int i = 0;
                foreach (var item in gotTotalTicketsOfThisType)
                {
                    if (item[0].ToString() == ticketCode)
                    {
                        i++;
                    }
                }
                if (i > 0)
                {
                    errMsg = "该身份证号码已经抢到足够票数,不能继续抢票";
                    return false;
                }
            }

            return true;
        }

        public Order BuildOrderForQZ(TourMembership member, string assignName, string idcardno, TicketBase currentTicket, int amount, string parnterName)
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
