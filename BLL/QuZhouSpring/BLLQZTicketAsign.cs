using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    //将某天某景区门票分发给接入商
    public class BLLQZTicketAsign:BLLBase<QZTicketAsign>
    {
        DALQZTicketAsign dalqzTa = new DALQZTicketAsign();
        public void Asign(DateTime date, Ticket t, Dictionary<Guid, int> partnersAsign, int asignedAmount)
        {
            QZTicketAsign ta = new QZTicketAsign();

        }


        public IList<DateTime> GetAllDateTime()
        {
            IList<QZTicketAsign> listQzTa = dalqzTa.GetAllList().OrderBy(x => x.Date).ToList();
            List<DateTime> listDT = new List<DateTime>();
            foreach (var item in listQzTa)
            {
                if (listDT.Where(x => x == item.Date).Count() == 0)
                {
                    listDT.Add(item.Date);
                }
            }
            return listDT;
        }

        /// <summary>
        /// 生成一个所有接入网站的门票分配表
        /// </summary>
        /// <returns></returns>
        public List<QZPartnerTicketAsign> GetAllQzPartnerTa()
        {
            IList < QZSpringPartner > listQZSP= new BLLQZSpringPartner().GetListByName("");
            List<QZPartnerTicketAsign> ListQzPartnerTa = new List<QZPartnerTicketAsign>();
            foreach (var item in listQZSP)
            {
                if (item.Enable)
                {
                    QZPartnerTicketAsign qzta = new QZPartnerTicketAsign();
                    qzta.Partner = item;
                    ListQzPartnerTa.Add(qzta);
                }
            }
            return ListQzPartnerTa;
        }
        /// <summary>
        /// 根据qzTicketAsign生成所有接入网站的门票分配表
        /// </summary>
        /// <param name="qzTa">qzTicketAsign</param>
        /// <returns></returns>
        public List<QZPartnerTicketAsign> GetAllQzPartnerTa(QZTicketAsign qzTa)
        {
            List<QZPartnerTicketAsign> ListQzTa = GetAllQzPartnerTa();
            foreach (var qzta in ListQzTa)
            {
                //此方法在保存后无法显示其list
                List<QZPartnerTicketAsign> listQzTa2 = new List<QZPartnerTicketAsign>();
                if (qzTa.PartnerTicketAsign!=null)
                    listQzTa2=qzTa.PartnerTicketAsign.Where(x => x.Partner.Id == qzta.Partner.Id).ToList();
                if (listQzTa2.Count() > 0)
                {
                    qzta.Id = listQzTa2[0].Id;
                    qzta.QZTicketAsign = listQzTa2[0].QZTicketAsign;
                    qzta.AsignedAmount = listQzTa2[0].AsignedAmount;
                    qzta.SoldAmount = listQzTa2[0].SoldAmount;
                }
            }
            return ListQzTa;
        }

        public void SaveDate(DateTime beginDate, DateTime endDate, List<Ticket> listTicket)
        {
            //门票分配(日期,景点,合作网站 数量.
            IList<QZTicketAsign> listQzTa = dalqzTa.GetAllList().OrderBy(x => x.Date).ToList();
            //分配门票.
            for (int i = 0; beginDate.AddDays(i) <= endDate; i++)
            {
                //分配每天的门票
                foreach (var ticket in listTicket)
                {
                    QZTicketAsign qz;
                    //如果时间调整.
                    if (listQzTa.Where(x => x.Date == beginDate.AddDays(i)).Count() == 0)
                    {
                        qz = new QZTicketAsign();
                    }
                    else
                    {
                        var list = listQzTa.Where(x => x.Date == beginDate.AddDays(i)).Where(x => x.Ticket.Id == ticket.Id);
                        if (list.Count() > 0)
                        {
                            qz = list.ToList()[0];
                        }
                        else
                        {
                            qz = new QZTicketAsign();
                        }
                    }
                    qz.Date = beginDate.AddDays(i);
                    qz.Ticket = ticket;
                    qz.ProductCode = ticket.ProductCode;
                    //不在此处给它绑定好partnerTicketAsign
                    //if (qz.PartnerTicketAsign == null || qz.PartnerTicketAsign.Count == 0)
                    //    qz.PartnerTicketAsign = createQzPartnerTa();
                    //else
                    //{
                    //    foreach (var item in createQzPartnerTa())
                    //    {
                    //        if (qz.PartnerTicketAsign.Where(x => x.Partner.Id == item.Partner.Id).Count() == 0)
                    //        {
                    //            item.QZTicketAsign = qz;
                    //            new BLLQZPartnerTicketAsign().Save(item);
                    //        }
                    //    }
                    //}
                    dalqzTa.SaveOrUpdate(qz);
                }

            }
        }

        public IList<QZTicketAsign> GetQzByDate(DateTime dateTime)
        {
            return dalqzTa.GetQzByDate(dateTime);
        }

        /// <summary>
        /// 根据门票列表获取QzTa
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public IList<QZTicketAsign> GetQzByDate(DateTime dateTime,List<Ticket> listTicket)
        {
            List<QZTicketAsign> listQzTa= dalqzTa.GetQzByDate(dateTime).ToList();
            foreach (var ticket in listTicket)
            {
                if (listQzTa.Where(x => x.Ticket.Id == ticket.Id).Count() == 0)
                {
                    QZTicketAsign qzTa = new QZTicketAsign();
                    qzTa.Ticket = ticket;
                    qzTa.Date = dateTime;
                    Save(qzTa);
                    listQzTa.Add(qzTa);
                }
            }
            return listQzTa;
        }


        /// <summary>
        /// 根据时间和门票获取ticketAsign
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="ticketId">门票id</param>
        /// <returns>ticketAsign列表</returns>
        public IList<QZTicketAsign> GetQzByDateAndTicket(DateTime dateTime, int ticketId)
        {
            return dalqzTa.GetQzByDateAndTicket(dateTime, ticketId);
        }


        /// <summary>
        /// 获取共发放的门票数
        /// </summary>
        /// <returns>发放的门票数</returns>
        public int getAllTicketCount()
        {
            IList<QZTicketAsign> listQZTa = GetAll<QZTicketAsign>();
            int allTicketCount = 0;
            foreach (var item in listQZTa)
            {
                allTicketCount += item.Amount;
            }
            return allTicketCount;
        }

        /// <summary>
        /// 根据门票Id，获取与它所有相关的网站发送数量
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        public List<int> getPartnerStatisticsByTicketId(int ticketId)
        {
            List<QZSpringPartner> listSp=new BLLQZSpringPartner().GetAll<QZSpringPartner>().ToList();
            IList<QZPartnerTicketAsign> listQZPartnerTa;
            if(ticketId!=0)
               listQZPartnerTa = GetAll<QZPartnerTicketAsign>().Where(x => x.QZTicketAsign.Ticket.Id == ticketId).ToList();
            else
                listQZPartnerTa = GetAll<QZPartnerTicketAsign>().ToList();
            List<int> listCount = new List<int>();
            int spAmount = 0;
            foreach (var sp in listSp)
            {
                List<QZPartnerTicketAsign> listQZPta = listQZPartnerTa.Where(x => x.Partner.Id == sp.Id).ToList();
                int spCount = 0;//这个网站所得到的票数
                foreach (var qzpTa in listQZPta)
                {
                    spCount += qzpTa.AsignedAmount;
                    spAmount += qzpTa.AsignedAmount;
                }
                listCount.Add(spCount);
            }
            listCount.Add(spAmount);
            return listCount;
        }


    }
}
