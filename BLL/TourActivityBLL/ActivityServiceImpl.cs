using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Model;
using System.Data;
namespace BLL
{
    /// <summary>
    /// 为接口服务
    /// </summary>
    public class BLLActivityServiceImpl
    {
        BLLMembership bllMembership = new BLLMembership();
        BLLTicketAssign bllTa = new BLLTicketAssign();
        BLLOrder bllOrder = new BLLOrder();
        BLLTicket bllTicket = new BLLTicket();
        BLLTourActivity bllActivity = new BLLTourActivity();
        BLLActivityTicketAssign bllActivityTicketAssign = new BLLActivityTicketAssign();

        /// <summary>
        /// 合作伙伴请求门票
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
            , string PartnerCode, string CardNumber, string RealName, string Phone, string ticketCode, int Number)
        {



          
            Guid requestGUID = Guid.NewGuid();
            TourLog.LogInstance.Debug(string.Format("*********Begin********{5}出票请求:{0}_{1}_{2}_{3}_{4}", PartnerCode, CardNumber, ticketCode, Number, Phone, requestGUID));
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
               ActivityTicketAssign ticketAssign = activity.ActivityTicketAssign.Where(x =>
                         x.Partner.PartnerCode == PartnerCode
                         && x.Ticket.ProductCode == ticketCode
                         && x.DateAssign == DateTime.Today).Single();
            ///数量规则验证
            //1 是否还有门票
            //如果合作商采用总数验证 ,则不需要验证每天的数量
            if (currentPartner.OnlyControlTotalAmount)
            {
                if (activity.GetPartnerAmountAssigned(PartnerCode, ticketCode) + Number > activity.GetPartnerAmountSold(PartnerCode, ticketCode))
                {
                    returnMsg = "F|门票已售完";
                    goto LblReturn;
                }
            }
            else //每天票数验证.
            {

                //获取当天合作商某景区的门票分配情况


             

                TourLog.LogInstance.Error(string.Format("分配有误:合作伙伴{0}门票{1}在{2}有多次分配"));

                //每张门票 的数量检测
                if (ticketAssign == null)
                {
                    returnMsg = "F|没有查到对应的门票";
                    goto LblReturn;
                }

                if (ticketAssign.SoldAmount + Number > ticketAssign.AssignedAmount)
                {
                    returnMsg = "F|今天的门票已售完,欢迎明天再来";

                    goto LblReturn;
                }

            }
            ///////////////////用户购买数量规则
            //2 该用户是否已经抢到了该景区足够数量的门票
            int idcardGotTicketAmount = bllTa.GetAmountIdcardActivityTicket(activityCode, CardNumber, ticketCode);
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
            ////自动创建订单(如果是联票, 则要为联票门票创建三个订单

            string createOrderErrMsg;
            if (string.IsNullOrEmpty(RealName))
            {
                RealName = activity.Name + "参与者";
            }
            TicketBase ticket = bllTicket.GetByProductCode(ticketCode);
            bllOrder.CreateOrder(activity.Name, PartnerCode, member.Id, ticket, CardNumber, RealName, Number, out createOrderErrMsg);
            if (!string.IsNullOrEmpty(createOrderErrMsg))
            {
                returnMsg = "F|创建订单失败,请联系客服";
                goto LblReturn;
            }

            ////3 该接入商该景区的已售门票+1
          
                ticketAssign.SoldAmount += Number;
                bllActivityTicketAssign.SaveOrUpdate(ticketAssign);
           
        LblReturn:
            TourLog.LogInstance.Info(returnMsg);
            TourLog.LogInstance.Info(requestGUID + "*********END********" + requestGUID);
            return returnMsg;

        }


        public int ProductLeftAmount(string activityCode, string PartnerCode, string productCode, DateTime dt)
        {
            ActivityTicketAssign ticketAssign = bllActivityTicketAssign.GetOneByQuery(activityCode, PartnerCode, productCode, dt);
            return ticketAssign.AssignedAmount - ticketAssign.SoldAmount;
        }

        /// <summary>
        /// 获取所有门票的剩余票量
        /// </summary>
        /// <param name="activityCode"></param>
        /// <param name="PartnerCode"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataSet ProductLeftAmountAll(string activityCode, string PartnerCode, DateTime date)
        {
            IList<ActivityTicketAssign> assigns = bllActivityTicketAssign.GetList(activityCode, PartnerCode, date);


            DataSet ds = new DataSet();

            DataTable dt = new DataTable("ticketamounts");
            string colScenicName = "ScenicName";
            string colProductCode = "ProductCode";
            string colLastAmount = "LastAmount";
            string colAssignedAmount = "AssignedAmount";
            string colSoldAmount = "SoldAmount";
            dt.Columns.Add(colScenicName);
            dt.Columns.Add(colProductCode);
            dt.Columns.Add(colLastAmount);
            dt.Columns.Add(colAssignedAmount);
            dt.Columns.Add(colSoldAmount);
            foreach (ActivityTicketAssign ta in assigns)
            {

                DataRow dr = dt.NewRow();
                dr[colScenicName] = ta.Ticket.Scenic.Name;
                dr[colProductCode] = ta.Ticket.ProductCode;
                dr[colLastAmount] = ta.AssignedAmount - ta.SoldAmount;
                dr[colAssignedAmount] = ta.AssignedAmount;
                dr[colSoldAmount] = ta.SoldAmount;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            return ds;

        }


    }
}
