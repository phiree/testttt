using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALQZPartnerTicketAsign : DalBase<QZPartnerTicketAsign>
    {
        public QZPartnerTicketAsign GetOne(DateTime dateTime, string PartnerFriendlyId, string ProductCode)
        {
            string sql = "select qz from QZPartnerTicketAsign qz where 1=1 ";
            sql += " and qz.QZTicketAsign.Date='" + dateTime.ToString("yyyy-MM-dd") + "' ";
            sql += " and qz.Partner.FriendlyId='" + PartnerFriendlyId + "' ";
            sql += " and qz.QZTicketAsign.Ticket.ProductCode='" + ProductCode + "'";
            return GetOneByQuery(sql);
        }
        //合作商 某个景区 总分配数量,总派发数量
        public int[] GetTotalAssignAndSold(string partnerId, string ticketCode)
        {
           // List<int> result = new List<int>();
            string sql = @"select SUM(a.AsignedAmount)as totalAssigned, SUM(a.SoldAmount) as totalSold, a.Partner_id,b.ProductCode
                            from QZPartnerTicketAsign a, QZTicketAsign b
                            where a.QZTicketAsign_id=b.id 
                            and 
                            group by a.Partner_id,b.ProductCode";

            var result1 = session.CreateSQLQuery(sql).UniqueResult<object[]>();
            if (result1 != null || result1.Length !=2)
            {
                return new int[]{-1,-1};
                //result.Add(-1);
                //result.Add(-1);
            }

            else 
            {
                int totalAssign =Convert.ToInt32( result1[0]);
                int totalSold = Convert.ToInt32(result1[0]);
                //result.Add(totalAssign);
                //result.Add(totalSold);
                int[] a = {totalAssign,totalSold };
                return a;
            }
           
        }
    }
}
