using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALRefund : DalBase
    {
        public IList<Model.Refund> GetList()
        {
            return session.QueryOver<Refund>().List();
        }
        public Refund GetList(object id)
        {
            return session.Get<Refund>(id);
        }
        public void Save(Refund refund)
        {
            session.SaveOrUpdate(refund);
            session.Flush();
        }
    }
}
