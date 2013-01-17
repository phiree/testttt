using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    //将某天某景区门票分发给接入商
    public class BLLTicketAsign
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

        public void SaveDate(DateTime beginDate, DateTime endDate, List<Ticket> listTicket)
        {
            IList<QZTicketAsign> listQzTa = dalqzTa.GetAllList().OrderBy(x => x.Date).ToList();
            for (int i = 0; beginDate.AddDays(i) <= endDate; i++)
            {
                foreach (var ticket in listTicket)
                {
                    QZTicketAsign qz;
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
                    dalqzTa.Save(qz);
                }

            }
        }
    }
}
