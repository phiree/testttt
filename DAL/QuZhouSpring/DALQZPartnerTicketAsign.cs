using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALQZPartnerTicketAsign:DalBase<QZPartnerTicketAsign>
    {
        public QZPartnerTicketAsign GetOne(DateTime dateTime, string PartnerFriendlyId, string ProductCode)
        {
            string sql = "select qz from QZPartnerTicketAsign qz where 1=1 ";
            sql += " and qz.QZTicketAsign.Date='" + dateTime.ToString("yyyy-MM-dd") + "' ";
            sql += " and qz.Partner.FriendlyId='" + PartnerFriendlyId + "' ";
            sql += " and qz.QZTicketAsign.Ticket.ProductCode='" + ProductCode + "'";
            return GetOneByQuery(sql);
        }
    }
}
