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
        public virtual  int AmountPerIdcardTicket { get; set; }
        /// <summary>
        /// 身份证号在本次活动中能购买的最大数量
        /// </summary>
        public virtual int AmountPerIdcardInActivity { get; set; }
        //合作分票者
        public virtual IList<ActivityPartner> Partners { get; set; }
        //参与活动的门票
        public virtual List<Ticket> Tickets { get; set; }
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
        public virtual bool HasEnoughAmount(int ticketId, string partnerCode, DateTime date, int requestAmount)
        {
         ActivityTicketAssign assign=   ActivityTicketAssign.Where(x => x.DateAssign == date 
                                        && x.Partner.PartnerCode == partnerCode
                                        && x.Ticket.Id == ticketId).Single();
         int assigned = assign.AssignedAmount;
         int sold = assign.SoldAmount;
         return sold + requestAmount <= assigned;

        }

        public virtual bool CheckIdCardAmountPerTicket(IList<TicketAssign> ticketAssigns, string idcard, string ticketCode, int amount)
        {
            int taCount = ticketAssigns.Where(x => x.IdCard == idcard && x.TicketCode == ticketCode).Count();
            return taCount + amount <= AmountPerIdcardTicket;
        }

        public virtual bool CheckIdCardAmountPerActivity(IList<TicketAssign> ticketAssigns, string idcard, int amount)
        {
            int taCount = ticketAssigns.Where(x => x.IdCard == idcard).Count();
            return taCount + amount <= AmountPerIdcardInActivity;
        }

        public virtual bool CheckBuyTime()
        {
            return DateTime.Now >= BeginDate && DateTime.Now < EndDate;
        }
        public virtual bool CheckBuyHour()
        {
            return DateTime.Now.Hour >= BeginHour && DateTime.Now.Hour < EndHour;
        }

        public virtual bool CheckUserAreas(string userArea)
        {
            if (AreasUseBlack)
            {
                return !AreasBlackList.Contains(userArea);
            }
            else
            {
                return AreasWhiteList.Contains(userArea);
            }
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
            return ActivityTicketAssign.Where(x => x.DateAssign == date && x.Ticket.ProductCode==ticketCode).ToList();
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
            return ActivityTicketAssign.Where(x => x.DateAssign == date && x.Ticket.ProductCode == ticketCode&&x.Partner.PartnerCode==partnerCode).ToList();
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
