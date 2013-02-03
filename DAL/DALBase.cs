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
            session.SaveOrUpdate(o);
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
        public void SaveOrUpdate(T o)
        {


            session.SaveOrUpdate(o);
            session.Flush();



        }
        public T GetOne(object id)
        {
            return session.Get<T>(id);
        }
        protected T GetOneByQuery(string where)
        {
            IList<T> listT = GetList(where);

            if (listT.Count == 1)
            {
                return listT[0];
            }
            else if (listT.Count == 0)
            {
                return default(T);
            }
            else
            {
                throw new Exception("有" + listT.Count + "个值返回.应该只能返回一个值.");
            }
        }
        protected T GetOneByQuery(IQueryOver<T, T> queryOver)
        {
            return queryOver.SingleOrDefault();
        }
        public IList<T> GetAll<T>() where T : class
        {
            return session.QueryOver<T>().List();
        }

        public IList<T> GetList(string where)
        {
            int totalRecords;
            return GetList(where, 0, 99999, out totalRecords);
        }
        protected IList<T> GetList(IQueryOver<T, T> queryOver)
        {
            return queryOver.List();
        }

        public IList<T> GetList(string query, int pageIndex, int pageSize, out int totalRecords)
        {
            IQuery qry = session.CreateQuery(query);
            var itemList = qry.Future<T>().ToList();
            totalRecords = itemList.Count;
            var returnList = itemList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return returnList;
        }


    }
}
