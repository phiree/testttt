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
        public void Asign(DateTime date, Ticket t, Dictionary<Guid,int> partnersAsign, int asignedAmount)
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
    }
}
