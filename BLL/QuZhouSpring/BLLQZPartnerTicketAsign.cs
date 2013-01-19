using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using BLL;

namespace BLL
{
    public class BLLQZPartnerTicketAsign:BLLBase<QZPartnerTicketAsign>
    {
        DAL.DALQZPartnerTicketAsign dalqzPartnerTa = new DAL.DALQZPartnerTicketAsign();
        BLLQZTicketAsign bllqzTa = new BLLQZTicketAsign();
        /// <summary>
        /// 获取某天某企业在某景区分配的票数
        /// </summary>
        /// <param name="dateTime">某天</param>
        /// <returns>该对象</returns>
        public QZPartnerTicketAsign GetOne(DateTime dateTime, string PartnerFriendlyId, string ProductCode)
        {
            return dalqzPartnerTa.GetOne(dateTime, PartnerFriendlyId, ProductCode);
        }

        /// <summary>
        /// 根据时间，接入网站id和门票id查询某个门票分配情况
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <param name="PartnerId">接入网站id</param>
        /// <param name="ticketId">门票id</param>
        /// <returns>分配情况</returns>
        public QZPartnerTicketAsign GetOneByDateAndPartnerIdAndTicketId(DateTime dateTime, Guid PartnerId,int ticketId)
        {
           QZTicketAsign qzTa= bllqzTa.GetQzByDateAndTicket(dateTime, ticketId)[0];
           if (qzTa.PartnerTicketAsign == null || qzTa.PartnerTicketAsign.Count == 0)
           {
               return null;
           }
           else
           {
               List<QZPartnerTicketAsign> ListQzTa= qzTa.PartnerTicketAsign.Where(x => x.Partner.Id == PartnerId).ToList();
               if (ListQzTa.Count() == 0)
               {
                   return null;
               }
               else
               {
                   return ListQzTa[0];
               }
           }
        }
    }
}
