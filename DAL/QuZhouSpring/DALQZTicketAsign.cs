using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALQZTicketAsign:DalBase<QZTicketAsign>
    {
        public IList<QZTicketAsign> GetAllList()
        {
            return GetAll<QZTicketAsign>();
        }

        public IList<QZTicketAsign> GetQzByDate(DateTime dateTime)
        {
            string sql = "select qz from QZTicketAsign qz where qz.Date='" + dateTime + "'";
            return GetList(sql);
        }

        /// <summary>
        /// 根据时间和门票获取ticketAsign
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="ticketId">门票id</param>
        /// <returns>ticketAsign列表</returns>
        public IList<QZTicketAsign> GetQzByDateAndTicket(DateTime dateTime, int ticketId)
        {
            string sql = "select qz from QZTicketAsign qz where qz.Date='" + dateTime + "' and qz.Ticket.Id=" + ticketId + "";
            return GetList(sql);
        }
    }
}
