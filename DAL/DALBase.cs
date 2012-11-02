using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Hql;
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
    public class DalBase<T>
    {

        protected ISession session = new HybridSessionBuilder().GetSession();
        public void Delete(T o)
        {
            session.Delete(o);
            session.Flush();
        }
        public virtual void Save(T o)
        {
            session.Save(o);
            session.Flush();
        }
        public void Update(T o)
        {
            session.Update(o);
            session.Flush();
        }

        public T GetOne(object id)
        {
            return session.Get<T>(id);
        }
        public IList<T> GetAll<T>() where T:class 
        {
            return session.QueryOver<T>().List();
        }
       

        protected IList<T> GetList(string where,int pageIndex, int pageSize, out int totalRecords)
        {
            IQuery qry = session.CreateQuery(where);

            IList<T> itemList = new List<T>();
            totalRecords = itemList.Count;
          
                itemList = qry.Future<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<T>();
           
            return itemList;
        }

    }
}
