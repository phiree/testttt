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
        /// <param name="ProductCodes"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public string buyProduct(string activityCode, bool needValidatePerDay, bool needCheckTime
            , string PartnerCode, string CardNumber, string RealName, string Phone, IList<string> ProductCodes, int Number)
        {
            Guid requestGUID = Guid.NewGuid();
            TourLog.LogInstance.Debug(string.Format("*********Begin********{5}出票请求:{0}_{1}_{2}_{3}_{4}", PartnerCode, CardNumber, ProductCodes, Number, Phone, requestGUID));
            string returnMsg = "T";
            TourActivity activity = new TourActivity();
            //1 验证每天抢票的开始时间
            //  amount = 1;
            int nowHour = DateTime.Now.Hour;
            if (needCheckTime)
            {
                if (!activity.CheckBuyTime())
                {
                    returnMsg= string.Format("F|抢票时间是{0}点到{1}点.", activity.BeginHour, activity.EndHour);
                    goto LblReturn;
                }
            }
            //验证活动时间
            string timeFormat = "yyyy年MM月dd日";
            if (!activity.CheckBuyTime())
            {
                returnMsg = string.Format("F|活动时间是{0}到{1}", activity.BeginDate.ToString(timeFormat), activity.EndDate.ToString(timeFormat));
                goto LblReturn;
            }
            //身份证号码格式验证
            string checkIdCardNoErrMsg;
            bool idcardnoValid = CommonLibrary.StringHelper.CheckIDCard(CardNumber, out checkIdCardNoErrMsg);
            if (!idcardnoValid)
            {
                returnMsg = "F|" + checkIdCardNoErrMsg;
                goto LblReturn;
            }
            DateTime nowDay = DateTime.Now.Date;
            //获取当天合作商某景区的门票分配情况
            if (ProductCodes.Count == 0)
            {
                returnMsg = "F|门票代码有误";
                goto LblReturn;
            }
            //多张门票一起送,只判断其中一张的数量分配(请保证 统一套票下的各个门票数量相等
            string firstProduct = ProductCodes[0];
            ActivityTicketAssign currentTicketAssign=null;
            IList<ActivityTicketAssign> ticketAssigns = activity.ActivityTicketAssign.Where(x => x.DateAssign == DateTime.Today && x.Partner.PartnerCode == PartnerCode
                 && x.Ticket.ProductCode == firstProduct).ToList();
            if (ticketAssigns.Count == 0)
            {
                returnMsg = "F|没有查到对应的门票";
                goto LblReturn;
            }
            else
            {
                currentTicketAssign=ticketAssigns[0];
            }
            
            ///数量规则验证
            //1 是否还有门票
            // if(activity
            //string validErrMsg;
            
         
            //bool isValid = ValidateRequst(ismedia, partnerAsign, amount, idcardno, ticketCode, out validErrMsg);
            //if (!isValid)
            //{
            //    return "F|" + validErrMsg;
            //}
            //if (member == null)
            //{
            //    member = bllMembership.GetMember(idcardno);

            //    if (member == null)
            //    {
            //        //创建用户
            //        member = bllMembership.CreateUser2("衢州门票派送参与者", phone, string.Empty, idcardno, idcardno, "123456", string.Empty);
            //    }
            //}
            ////自动创建订单
            //Ticket currentTicket = bllTicket.GetByProductCode(ticketCode);
            //string partnername = partnerAsign.Partner.Name;
            ////将媒体设置成合作者,
            ////if (ismedia)
            ////{
            ////    partnerAsign.Partner.Name = "媒体";
            ////}
            //Order order = BuildOrderForQZ(member, assignName, idcardno, currentTicket, amount, partnername);
            //bllOrder.SaveOrUpdateOrder(order);

            ////3 该接入商该景区的已售门票+1
            ////if (!ismedia)
            ////{
            //partnerAsign.SoldAmount += amount;
            //// }
            //bllQZPartnerTicketAsign.SaveOrUpdate(partnerAsign);
            //TourLog.LogInstance.Info(requestGUID + "*********END********" + requestGUID);
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
