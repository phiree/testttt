using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using BLL;
using System.Data;
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

        public DataSet ProductInfoAll(string partnerCode, DateTime date)
        {
            IList<Model.QZPartnerTicketAsign> assigns = dalqzPartnerTa.GetAllTicketAssignForPartner(partnerCode, date)
                .OrderByDescending(x=>x.AsignedAmount-x.SoldAmount).ToList();

             DataSet ds = new DataSet();
         
            DataTable dt = new DataTable("ticketamounts");
            string colScenicName="ScenicName";
            string colProductCode = "ProductCode";
            string colLastAmount="LastAmount";
            dt.Columns.Add(colScenicName);
            dt.Columns.Add(colProductCode);
            dt.Columns.Add(colLastAmount);
            foreach (QZPartnerTicketAsign ta in assigns)
            {

                DataRow dr = dt.NewRow();
                dr[colScenicName] = ta.QZTicketAsign.Ticket.Scenic.Name;
              ;
                dr[colProductCode] = ta.QZTicketAsign.Ticket.ProductCode;
                dr[colLastAmount]=ta.AsignedAmount-ta.SoldAmount;
                dt.Rows.Add(dr);
            }
            
            ds.Tables.Add(dt);

            return ds;
        
        }
    }
}
