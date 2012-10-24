using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Web.Security;

namespace DAL
{
    public class DalBase
    {
        protected DALMembership mtms = new DALMembership();
        protected ISession session = new HybridSessionBuilder().GetSession();
        public void Delete(object o)
        {
            session.Delete(o);
            session.Flush();
        }
        public void Save(object o)
        {
            session.Save(o);
            session.Flush();
        }
        public void Update(object o)
        {
            session.Update(o);
            session.Flush();
        }
        
    }
}
