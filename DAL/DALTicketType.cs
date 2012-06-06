using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALTicketType:DalBase,ITicketsType
    {
        public IList<Model.TicketsType> GetTicketsType()
        {
            IQuery query = session.CreateQuery("select tt from TicketsType tt");
            return query.Future<Model.TicketsType>().ToList<Model.TicketsType>();
        }
    }
}
