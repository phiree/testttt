using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 活动类
    /// </summary>
    public class TourActivity : IActivityRule
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
        public virtual bool AreasUseBlack { get; set; }
        //逗号隔开  3301,3302,330
        public virtual string AreasBlackList { get; set; }
        public virtual string AreasWhiteList { get; set; }

        #region Irule implention
        public virtual bool HasEnoughAmount(int ticketId, string partnerCode, DateTime date, int requestAmount, out string errMsg)
        {
            errMsg = string.Empty;
            ActivityTicketAssign assign = ActivityTicketAssign.Where(x => x.DateAssign == date
                                           && x.Partner.PartnerCode == partnerCode
                                           && x.Ticket.Id == ticketId).Single();
            int assigned = assign.AssignedAmount;
            int sold = assign.SoldAmount;
            bool result = sold + requestAmount > assigned;
            if (result)
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

            return result;

        }

        public virtual bool CheckIdCardAmountPerTicket(IList<TicketAssign> ticketAssigns, string idcard, string ticketCode, int amount,out string errMsg)
        {
            errMsg = string.Empty;
            int taCount = ticketAssigns.Where(x => x.IdCard == idcard && x.TicketCode == ticketCode).Count();
            bool result = taCount + amount <= AmountPerIdcardTicket;
            if (!result)
            {
                errMsg = string.Format("号码为{0}的身份证已经购买了这个景区的{1}张门票,不能继续购买", "****" + idcard.Remove(0, 12), taCount);
            }
            return result;
        }

        public virtual bool CheckIdCardAmountPerActivity(IList<TicketAssign> ticketAssigns, string idcard, int amount,out string errMsg)
        {
            errMsg = string.Empty;
     
            int taCount = ticketAssigns.Where(x => x.IdCard == idcard).Count();
            bool result = taCount + amount <= AmountPerIdcardInActivity;
            if (!result)
            {
                errMsg = string.Format("号码为{0}的身份证已经购买了{1}张门票,不能继续购买", "****" + idcard.Remove(0, 12), taCount);
       
            }
            return result;
        }

        public virtual bool CheckBuyTime(out string errMsg)
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
        public virtual bool CheckBuyHour(out string errMsg)
        {
            bool result = true;
            errMsg = string.Empty;
            if(DateTime.Now.Hour < BeginHour)
            {
              errMsg=string.Format( "活动将在{0}点开始,感谢您的耐心等待并欢迎您继续等待",BeginHour);
            }
            else if (DateTime.Now.Hour >= EndHour)
            {
                errMsg = string.Format("今天的活动已于{0}点结束,感谢您的参与.欢迎您明天{1}点再来", EndHour,BeginHour);
      
            }
            return result;
        }

        public virtual bool CheckUserAreas(string cardid, out string errMsg)
        {

            CommonLibrary.IdCardInfo idcard = new CommonLibrary.IdCardInfo(cardid);
            string province = idcard.Province;
            string city = idcard.City;
            string country = idcard.Country;
            
            errMsg = "抱歉,您的身份证号码所属地不在本次活动范围之内,不能购票.";
            if (AreasUseBlack)
            {

                return !(AreasBlackList.Contains(province) || AreasBlackList.Contains(city) || AreasBlackList.Contains(country));
            }
            else
            {
                return AreasBlackList.Contains(province) || AreasBlackList.Contains(city) || AreasBlackList.Contains(country);
            }
        }
        #endregion

        #region 总规则检查

        public virtual bool IntergrationCheck(IList<TicketAssign> talist,string idcardNo,string ticketCode,int buyAmount, out string errMsg)
        {
            bool result = true;
           

            if (!CheckBuyHour(out errMsg))
            {
                return false;
            }
            if (!CheckBuyTime(out errMsg))
            {
                return false;
            }
            if (!this.CheckUserAreas(idcardNo, out errMsg))
            {
                return false;
            }
            if (!this.CheckIdCardAmountPerTicket(talist, idcardNo,ticketCode, buyAmount, out errMsg))
            {
                return false;
            }
            if (!this.CheckIdCardAmountPerActivity(talist,idcardNo,buyAmount, out errMsg))
            {
                return false;
            }
         
            return result;
        }

        #endregion

        #region Helper Method
        /// <summary>
        /// 某合作伙伴某天的门票情况
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
        /// 某合作商 某天 某门票的情况
        /// </summary>
        /// <param name="partnerCode"></param>
        /// <param name="ticketCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual IList<ActivityTicketAssign> GetActivityAssignForPartnerTicketDate(string partnerCode, string ticketCode, DateTime date)
        {
            return ActivityTicketAssign.Where(x => x.DateAssign == date && x.Ticket.ProductCode == ticketCode && x.Partner.PartnerCode == partnerCode).ToList();
        }
        public virtual IList<ActivityTicketAssign> GetActivityAssignAssignForPartner(string partnerCode, string ticketCode)
        {
            return ActivityTicketAssign.Where(x => x.Ticket.ProductCode == ticketCode && x.Partner.PartnerCode == partnerCode).ToList();

        }
        public virtual int GetPartnerAmountAssigned(string partnerCode, string ticketCode)
        {
            return GetActivityAssignAssignForPartner(partnerCode, ticketCode).Sum(x => x.AssignedAmount);
        }
        public virtual int GetPartnerAmountSold(string partnerCode, string ticketCode)
        {
            return GetActivityAssignAssignForPartner(partnerCode, ticketCode).Sum(x => x.SoldAmount);
        }
        #endregion

    }
}
