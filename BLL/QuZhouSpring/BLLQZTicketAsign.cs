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


        private List<QZPartnerTicketAsign> createQzPartnerTa()
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
                    if (qz.PartnerTicketAsign == null || qz.PartnerTicketAsign.Count == 0)
                        qz.PartnerTicketAsign = createQzPartnerTa();
                    else
                    {
                        foreach (var item in createQzPartnerTa())
                        {
                            if (qz.PartnerTicketAsign.Where(x => x.Partner.Id == item.Partner.Id).Count() == 0)
                            {
                                item.QZTicketAsign = qz;
                                new BLLQZPartnerTicketAsign().Save(item);
                            }
                        }
                    }
                    dalqzTa.SaveOrUpdate(qz);
                }

            }
        }

        public IList<QZTicketAsign> GetQzByDate(DateTime dateTime)
        {
            return dalqzTa.GetQzByDate(dateTime);
        }
    }
}
