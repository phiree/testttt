using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Model;
namespace BLL.TourActivityBLL
{
    /// <summary>
    /// 为接口服务
    /// </summary>
    public class ActivityServiceImpl
    {
        BLLMembership bllMembership = new BLLMembership();
        BLLTicketAssign bllTa = new BLLTicketAssign();
        BLLOrder bllOrder = new BLLOrder();
        BLLTicket bllTicket = new BLLTicket();
        BLLTourActivity bllActivity = new BLLTourActivity();
        BLLActivityTicketAssign bllActivityTicketAssign = new BLLActivityTicketAssign();
        /// <summary>
        /// 用户请求一张门票
        /// </summary>
        /// <param name="PartnerCode"></param>
        /// <param name="CardNumber"></param>
        /// <param name="RealName"></param>
        /// <param name="Phone"></param>
        /// <param name="ProductCode"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public string buyProduct(string PartnerCode, string CardNumber, string RealName, string Phone, string ProductCode, int Number)
        {
            return "T";
        }

        /// <summary>
        /// 同事请求多张门票
        /// </summary>
        /// <param name="activityCode">活动代码</param>
        /// <param name="needValidatePerDay">是否每天验证</param>
        /// <param name="needCheckTime">是否限制购买时间</param>
        /// <param name="PartnerCode"></param>
        /// <param name="CardNumber"></param>
        /// <param name="RealName"></param>
        /// <param name="Phone"></param>
        /// <param name="ticketCodes"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public string buyProduct(string activityCode, bool needCheckTime, TourMembership member
            , string PartnerCode, string CardNumber, string RealName, string Phone, IList<string> ticketCodes, int Number)
        {
            Guid requestGUID = Guid.NewGuid();
            TourLog.LogInstance.Debug(string.Format("*********Begin********{5}出票请求:{0}_{1}_{2}_{3}_{4}", PartnerCode, CardNumber, ticketCodes, Number, Phone, requestGUID));
            string returnMsg = "T";
         
            TourActivity activity = bllActivity.GetOneByActivityCode(activityCode);//get from activitycode
            //todo
            ActivityPartner currentPartner = new ActivityPartner();//get from partnercode and actrivityCode
            ///1 验证每天抢票的开始时间
            //  amount = 1;
            int nowHour = DateTime.Now.Hour;
            if (needCheckTime)
            {
                if (!activity.CheckBuyTime())
                {
                    returnMsg = string.Format("F|抢票时间是{0}点到{1}点.", activity.BeginHour, activity.EndHour);
                    goto LblReturn;
                }
            }
            ///验证活动时间
            string timeFormat = "yyyy年MM月dd日";
            if (!activity.CheckBuyTime())
            {
                returnMsg = string.Format("F|活动时间是{0}到{1}", activity.BeginDate.ToString(timeFormat), activity.EndDate.ToString(timeFormat));
                goto LblReturn;
            }
            ///身份证号码格式验证
            string checkIdCardNoErrMsg;
            bool idcardnoValid = CommonLibrary.StringHelper.CheckIDCard(CardNumber, out checkIdCardNoErrMsg);
            if (!idcardnoValid)
            {
                returnMsg = "F|" + checkIdCardNoErrMsg;
                goto LblReturn;
            }

            DateTime nowDay = DateTime.Now.Date;
            //获取当天合作商某景区的门票分配情况
            if (ticketCodes.Count == 0)
            {
                returnMsg = "F|门票代码有误";
                goto LblReturn;
            }

            ///每张门票的剩余数量和分配情况都做检验
            IList<Ticket> ticketList = bllTicket.GetListByMultitTicketCode(ticketCodes);
                //某几张门票 某日 某合作商的分配列表,count应该等于 门票数量
            IList<ActivityTicketAssign> ticketAssigns = activity.ActivityTicketAssign.Where(x =>
                    x.Partner.PartnerCode == PartnerCode
                    && ticketCodes.Contains(x.Ticket.ProductCode)
                    && x.DateAssign == DateTime.Today).ToList();

            //多张门票一起送,只判断其中一张的数量分配(请保证 统一套票下的各个门票数量相等)不太保险的要求.
            string firstProduct = ticketCodes[0];
            ///数量规则验证
            //1 是否还有门票
            //如果合作商采用总数验证 ,则不需要验证每天的数量
            if (currentPartner.OnlyControlTotalAmount)
            {
                if (activity.GetPartnerAmountAssigned(PartnerCode, firstProduct) + Number > activity.GetPartnerAmountSold(PartnerCode, firstProduct))
                {
                    returnMsg = "F|门票已售完";
                    goto LblReturn;
                }
            }
            else //每天票数验证.
            {
            
              
                if (ticketCodes.Count != ticketAssigns.Count)
                {
                    TourLog.LogInstance.Error(string.Format("分配有误:合作伙伴{0}门票{1}在{2}有多次分配"));
                }
                //每张门票 的数量检测
                if (ticketAssigns.Count == 0)
                {
                    returnMsg = "F|没有查到对应的门票";
                    goto LblReturn;
                }
                foreach (ActivityTicketAssign currentTicketAssign in ticketAssigns)
                {
                    if (currentTicketAssign.SoldAmount + Number > currentTicketAssign.AssignedAmount)
                    {
                        returnMsg = "F|今天的门票已售完,欢迎明天再来";
                        
                        goto LblReturn;
                    }
                }
            }
            ///////////////////用户购买数量规则
            //2 该用户是否已经抢到了该景区足够数量的门票
            int idcardGotTicketAmount = bllTa.GetAmountIdcardActivityTicket(activityCode, CardNumber, firstProduct);
            if (idcardGotTicketAmount + Number > activity.AmountPerIdcardTicket)
            {
                returnMsg = "F|已获得该景区足够票数";
                goto LblReturn;
            }
            int idcardGotAmount = bllTa.GetAmountActivityIdcard(activityCode, CardNumber);
            if (idcardGotAmount + Number > activity.AmountPerIdcardInActivity)
            {
                returnMsg = "F|已获得足够票数";
                goto LblReturn;
            }

            ///开始生成订单,订单详情,门票分配
            //创建用户
            if (member == null)
            {
                member = bllMembership.GetMember(CardNumber);

                if (member == null)
                {
                    //创建用户
                    member = bllMembership.CreateUser2("衢州门票派送参与者", Phone, string.Empty, CardNumber, CardNumber, "123456", string.Empty);
                }
            }
            ////自动创建订单(三张一起创建,要使用session的事务)

            string createOrderErrMsg;
            if (string.IsNullOrEmpty(RealName))
            {
                RealName = activity.Name + "参与者";
            }
            bllOrder.CreateMultiOrder(activity.Name, PartnerCode, member.Id, ticketList, CardNumber, RealName, Number, out createOrderErrMsg);
            if (!string.IsNullOrEmpty(createOrderErrMsg))
            {
                returnMsg = "F|创建订单失败,请联系客服";
                goto LblReturn;
            }

            ////3 该接入商该景区的已售门票+1
            foreach (var assign in ticketAssigns)
            {
                assign.SoldAmount += Number;
                bllActivityTicketAssign.SaveOrUpdate(assign);
            }
        LblReturn:
            TourLog.LogInstance.Info(returnMsg);
            TourLog.LogInstance.Info(requestGUID + "*********END********" + requestGUID);
            return returnMsg;

        }

        //private bool IdAmountCheck(bool isMediaOrTaiZhou, QZPartnerTicketAsign partnerAsign, int amount, string idcardno, string ticketCode, out string errMsg)
        //{



        //    //验证这个分发商还有没有足够的门票

        //    CommonLibrary.ValidateHelper.verify_idcard(idcardno);

        //    bool hasEnough = true;
        //    //台州和媒体: 判断是否超出总量
        //    if (isMediaOrTaiZhou)
        //    {
        //        int[] totalAssignedAndSold = dalPTA.GetTotalAssignAndSold(partnerAsign.Partner.FriendlyId, ticketCode);
        //        int totalAssigned = totalAssignedAndSold[0];
        //        int totalSold = totalAssignedAndSold[1];
        //        if (totalAssigned == -1)
        //        {
        //            errMsg = string.Format("没有分配门票信息.partner:{0},ticketcode:{1}", partnerAsign.Partner.Name, ticketCode);
        //            return false;
        //        }
        //        else
        //        {
        //            if (totalSold + amount > totalAssigned)
        //            {
        //                errMsg = string.Format("门票已经全部派送.partner:{0},ticketcode:{1}", partnerAsign.Partner.Name, ticketCode);
        //                return false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        hasEnough = partnerAsign.HasEnoughTickets(amount);
        //        if (!hasEnough) { errMsg = "当天门票已被抢完,请明天再来"; return false; }
        //    }



        //    //验证这个身份证号码是否已经抢到一定数量的某种类型的门票,无法继续抢订.


        //    //是否已经抢到了足够的票数
        //    //ticket的 productcode 不为空的门票总数--> 
        //    //todo: 不太保险的判断

        //    //IList<TicketAssign> gotTotalTicketsOfThisType = listTa.Where(x => !string.IsNullOrEmpty(x.OrderDetail.TicketPrice.Ticket.ProductCode)).ToList();
        //    IList<TicketAssign> getAssignTicketForId = bllTicketAssign.GetTaByIdcardandTicketCode(idcardno, ticketCode);
        //    if (getAssignTicketForId.Count > 0)
        //    {

        //        errMsg = "该身份证号码已经抢到这个景区的门票,不能继续抢票";
        //        return false;
        //    }
        //    else
        //    {
        //        IList<object[]> gotTotalTicketsOfThisType = bllTicketAssign.GetTaByIdCardHasProductCodeBySql(idcardno);
        //        if (gotTotalTicketsOfThisType.Count >= 5)
        //        {
        //            errMsg = "该身份证号码已经抢到足够票数,不能继续抢票";
        //            return false;
        //        }
        //        int i = 0;
        //        foreach (var item in gotTotalTicketsOfThisType)
        //        {
        //            if (item[0].ToString() == ticketCode)
        //            {
        //                i++;
        //            }
        //        }
        //        if (i > 0)
        //        {
        //            errMsg = "该身份证号码已经抢到足够票数,不能继续抢票";
        //            return false;
        //        }
        //    }

        //    return true;
        //}


    }
}
