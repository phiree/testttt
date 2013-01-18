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
        /// <summary>
        /// 获取某天某企业在某景区分配的票数
        /// </summary>
        /// <param name="dateTime">某天</param>
        /// <returns>该对象</returns>
        public QZPartnerTicketAsign GetOne(DateTime dateTime, string PartnerFriendlyId, string ProductCode)
        {
            return dalqzPartnerTa.GetOne(dateTime, PartnerFriendlyId, ProductCode);
        }
    }
}
