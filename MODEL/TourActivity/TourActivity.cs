using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 活动类
    /// </summary>
    public class TourActivity //: IActivityRule
    {

        public TourActivity()
        {
            EndHour = 24;
            Partners = new List<ActivityPartner>();
            Tickets = new List<Ticket>();
            ActivityTicketAssign = new List<ActivityTicketAssign>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ActivityCode { get; set; }
        public virtual int BeginHour { get; set; }
        public virtual int EndHour { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// 每张身份证每个景区购买的最大数量
        /// </summary>
        public virtual int AmountPerIdcardTicket { get; set; }
        /// <summary>
        /// 身份证号在本次活动中能购买的最大数量
        /// </summary>
        public virtual int AmountPerIdcardInActivity { get; set; }
        //合作分票者
        public virtual IList<ActivityPartner> Partners { get; set; }
        //参与活动的门票
        public virtual IList<Ticket> Tickets { get; set; }
        //门票分配情况
        public virtual IList<ActivityTicketAssign> ActivityTicketAssign { get; set; }
        /// <summary>
        /// 限制购买者的地理位置
        /// true 表示 用 excludeareas
        /// </summary>
        public virtual bool NeedCheckArea { get; set; }
        public virtual bool AreasUseBlackList { get; set; }
        //逗号隔开  3301,3302,330
        public virtual string AreasBlackList { get; set; }
        public virtual string AreasWhiteList { get; set; }

        #region Irule implention


        public virtual bool CheckBeforeOrder(ActivityPartner partner, string ticketCode, int requiredAmount, out string summaryErrMsg)
        {
            
               bool result = true;
            summaryErrMsg = string.Empty;
            string errMsg = string.Empty;
            //时间检查 
            if (!CheckBuyHour(partner, out errMsg))
            {
                summaryErrMsg += errMsg + ",";
                result = false;
            }
            //日期检查
            if (!CheckBuyTime(out errMsg))
            {
                summaryErrMsg += errMsg + ",";
                result = false;
            }
            if (!this.CheckAmountPartnerTicketDate(ticketCode, partner, DateTime.Now.Date, requiredAmount, out errMsg))
            {
                summaryErrMsg += errMsg + ",";
                result = false;
            }

           
            return result;
          

        }
        public virtual bool CheckProcessOrder(IList<OrderDetail> detailOfIdcard,string ticketCode
            ,int requiredAmount,string idcardNo,out string summaryErrMsg)
        {
            bool result=true;
            string errMsg=string.Empty;
            summaryErrMsg = string.Empty;
             if (NeedCheckArea && !this.CheckUserAreas(idcardNo, out errMsg))
            {
                summaryErrMsg += errMsg + ",";
                result = false;
            }
           
            if (!this.CheckAmountIdcard(detailOfIdcard, idcardNo, ticketCode, requiredAmount, out errMsg))
            {
                summaryErrMsg += errMsg + ",";
                result = false;
            }
            return result;
            

        }

        /// <summary>
        /// 景区是否有足够的门票
        /// </summary>
        /// <param name="ticketCode"></param>
        /// <param name="partnerCode"></param>
        /// <param name="date"></param>
        /// <param name="requestAmount"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private  bool CheckAmountPartnerTicketDate(string ticketCode, ActivityPartner partner, DateTime date, int requestAmount, out string errMsg)
        {
            errMsg = string.Empty;

            int assigned = 0, sold = 0;
            //如果景区只需要控制总数
            if (partner.OnlyControlTotalAmount)
            {
                assigned = ActivityTicketAssign.Where(x => x.Partner.PartnerCode.ToLower() == partner.PartnerCode.ToLower()).Sum(x => x.AssignedAmount);
                sold = ActivityTicketAssign.Where(x => x.Partner.PartnerCode.ToLower() == partner.PartnerCode.ToLower()).Sum(x => x.SoldAmount);
            }
            else
            {
                ActivityTicketAssign thisAss = null;
                IList<ActivityTicketAssign> assigns = ActivityTicketAssign.Where(x => x.DateAssign == date && x.Partner.PartnerCode.ToLower() == partner.PartnerCode.ToLower()
                                               && x.Ticket.ProductCode.ToLower() == ticketCode.ToLower()).ToList();
                //foreach (ActivityTicketAssign ass in ActivityTicketAssign)
                //{
                //    DateTime dt2 =DateTime.Parse( DateTime.Today.ToString("yyyy-MM-dd"));
                //    if (ass.DateAssign == DateTime.Now.Date && ass.Partner.PartnerCode.ToLower() == partner.PartnerCode.ToLower() && ass.Ticket.ProductCode.ToLower() == ticketCode)
                //    {
                //        thisAss = ass;
                //        break;
                //    }
                //}


                if (assigns.Count== 0)
                {
                    throw new Exception(string.Format( "尚未分票:合作商{0},门票{1},时间{2}",partner.PartnerCode,ticketCode,date));
                }
                if (assigns.Count > 1)
                {
                    throw new Exception(string.Format("多次分票:合作商{0},门票{1},时间{2}", partner.PartnerCode, ticketCode, date));
        
                }


                assigned = assigns[0].AssignedAmount;
                sold = assigns[0].SoldAmount;

            }
            bool hasEnough = sold + requestAmount <= assigned;
            if (!hasEnough)
            {
                if (DateTime.Now.AddDays(1).Date <= EndDate)
                {
                    errMsg = "当天门票已售完,欢迎明天" + BeginHour + "点再来!";
                }
                else
                {
                    errMsg = "活动门票已全部售完, 您可以继续购买.";
                }
            }

            return hasEnough;

        }


        //购买日期是否在活动范围之内
        private  bool CheckBuyTime(out string errMsg)
        {

            errMsg = string.Empty;

            DateTime now = DateTime.Now;
            bool result = true;
            if (DateTime.Now < BeginDate)
            {
                errMsg = "活动尚未开始";
                result = false;
            }
            else
                if (now >= EndDate)
                {
                    errMsg = "活动已经结束";
                    result = false;
                }
            return result;
        }
        private  bool CheckBuyHour(ActivityPartner partner, out string errMsg)
        {
            bool result = true;
            errMsg = string.Empty;
            if (!partner.NeedCheckTime) { return true; }
            if (DateTime.Now.Hour < BeginHour)
            {
                errMsg = string.Format("活动将在{0}点开始", BeginHour);
                result = false;
            }
            else if (DateTime.Now.Hour >= EndHour)
            {
                errMsg = string.Format("今天的活动已于{0}点结束,感谢您的参与.欢迎您明天{1}点再来", EndHour, BeginHour);
                result = false;
            }
            return result;
        }

        //用户地理位置是否符合活动规则
        private  bool CheckUserAreas(string cardid, out string errMsg)
        {

            //CommonLibrary.IdCardInfo idcard = new CommonLibrary.IdCardInfo(cardid).Parse(out errMsg);
            string province = cardid.Substring(0, 2);
            string city = cardid.Substring(2, 2);
            string country = cardid.Substring(4, 2);
            errMsg = "抱歉,您的身份证号码所属地不在本次活动范围之内,不能购票.";
            if (AreasUseBlackList)
            {

                return !(AreasBlackList.Contains(province) || AreasBlackList.Contains(city) || AreasBlackList.Contains(country));
            }
            else
            {
                return AreasBlackList.Contains(province) || AreasBlackList.Contains(city) || AreasBlackList.Contains(country);
            }
        }

        //身份证购得数检测
        private  bool CheckAmountIdcard(IList<OrderDetail> detailOfIdcard
            , string idcardNo, string ticketCode, int requiredAmount, out string errMsg)
        {
            bool result = true;
            errMsg = string.Empty;
            int amountOfIdcardOfTicket = (int)detailOfIdcard.Where(x => x.TicketPrice.Ticket.ProductCode == ticketCode)
                            .Sum(x => x.Quantity);
            int amountOfIdcardAll = (int)detailOfIdcard.Sum(x => x.Quantity);
            if (amountOfIdcardOfTicket + requiredAmount > this.AmountPerIdcardTicket)
            {
                result = false;
                errMsg = "您的身份证号码已购买过本次活动的派送门票,欢迎下次参与.";
            }
           
            return result;
        }
     

        #endregion

        #region Helper Method
        /// <summary>
        /// 某合作伙伴某天所有门票的情况
        /// </summary>
        /// <param name="partnerCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual IList<ActivityTicketAssign> GetActivityAssignForPartnerDate(string partnerCode, DateTime date)
        {
            return ActivityTicketAssign.Where(x => x.DateAssign == date && x.Partner.PartnerCode == partnerCode).ToList();
        }
        /// <summary>
        /// 某门票某天的情况
        /// </summary>
        /// <param name="ticketCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual IList<ActivityTicketAssign> GetActivityAssignForTicketDate(string ticketCode, DateTime date)
        {
            return ActivityTicketAssign.Where(x => x.DateAssign == date && x.Ticket.ProductCode == ticketCode).ToList();
        }
        /// <summary>
        /// 某合作商 某天 某门票的情况 应该只存在一个对象 如果有多个
        /// </summary>
        /// <param name="partnerCode"></param>
        /// <param name="ticketCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual ActivityTicketAssign GetActivityAssignForPartnerTicketDate(string partnerCode, string ticketCode, DateTime date)
        {
            IList<ActivityTicketAssign> assign = ActivityTicketAssign.Where(x => x.DateAssign == date && x.Ticket.ProductCode == ticketCode && x.Partner.PartnerCode == partnerCode).ToList();
            if (assign.Count == 0) { return null; }
            else if (assign.Count == 1) { return assign[0]; }
            else
            {
                throw new Exception(string.Format("合作商{0}在{1}给门票{2}有多种分配."));
            }
        }

        //合作商某门票所有日期的分配,销售情况
        public virtual IList<ActivityTicketAssign> GetActivityAssignAssignForPartner(string partnerCode, string ticketCode)
        {
            return ActivityTicketAssign.Where(x => x.Ticket.ProductCode == ticketCode && x.Partner.PartnerCode == partnerCode).ToList();

        }
        //某合作商某门票的分配总额
        public virtual int GetPartnerAmountAssigned(string partnerCode, string ticketCode)
        {
            return GetActivityAssignAssignForPartner(partnerCode, ticketCode).Sum(x => x.AssignedAmount);
        }
        //某合作商某门票的销售总额
        public virtual int GetPartnerAmountSold(string partnerCode, string ticketCode)
        {
            return GetActivityAssignAssignForPartner(partnerCode, ticketCode).Sum(x => x.SoldAmount);
        }
        //某门票所有日期的验票总额
        #endregion

    }
}
