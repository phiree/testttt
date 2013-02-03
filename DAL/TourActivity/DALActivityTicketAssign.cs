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
            string sql = string.Format(@"select ata 
                            from ActivityTicketAssign ata 
                            where ata.DateAssign='{0}'
                                and ata.TourActivity.ActivityCode='{1}'
                                and ata.Ticket.ProductCode='{2}'
                                and ata.Partner.PartnerCode='{3}'"
                , date,activityCode,ticketCode,partnerCode
                );
            //var queryover = session.QueryOver<ActivityTicketAssign>(()=>activityalias).JoinAlias(()=>activityalias,()=>TourActivityAlias)
            //    .Where(x => x.DateAssign == date)
            //    .Where(x => x.TourActivity.ActivityCode == activityCode)
            //    .Where(x => x.Ticket.ProductCode == ticketCode)
            //    .Where(x => x.Partner.PartnerCode == partnerCode);
             
            return GetOneByQuery(sql);
        }

        public IList<ActivityTicketAssign> GetList(string activityCode, string partnerCode, DateTime date)
        {
            string sql = string.Format(@"select ata from ActivityTicketAssign ata 
                        where ata.DateAssign='{0}'
                        and ata.TourActivity.ActivityCode='{1}'
                        and ata.Partner.PartnerCode='{2}'", date, activityCode, partnerCode);
            //var queryover = session.QueryOver<ActivityTicketAssign>().Where(x => x.DateAssign == date
            //   && x.TourActivity.ActivityCode == activityCode
          
            //   && x.Partner.PartnerCode == partnerCode
            //   );
            return GetList(sql);
        }
        
    }
}
