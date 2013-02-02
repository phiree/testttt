using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace DAL
{
    public class DALActivityTicketAssign : DalBase<Model.ActivityTicketAssign>
    {

        /// <summary>
        ///所有根据对象属性查询一个对象的 查询都在此方法上做扩展
        /// </summary>
        /// <param name="activityCode"></param>
        /// <param name="partnerCode"></param>
        /// <param name="ticketCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ActivityTicketAssign GetOneByQuery(string activityCode, string partnerCode, string ticketCode, DateTime date)
        {
            var queryover = session.QueryOver<ActivityTicketAssign>().Where(x => x.DateAssign == date
                && x.TourActivity.ActivityCode==activityCode
                &&x.Ticket.ProductCode==ticketCode
                &&x.Partner.PartnerCode==partnerCode
                );
            return GetOneByQuery(queryover);
        }

        public IList<ActivityTicketAssign> GetList(string activityCode, string partnerCode, DateTime date)
        {
            var queryover = session.QueryOver<ActivityTicketAssign>().Where(x => x.DateAssign == date
               && x.TourActivity.ActivityCode == activityCode
          
               && x.Partner.PartnerCode == partnerCode
               );
            return GetList(queryover);
        }
        
    }
}
