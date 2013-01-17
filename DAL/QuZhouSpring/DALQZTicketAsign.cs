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
    }
}
