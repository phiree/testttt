using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLBase<T> where T:class
    {
        //todo: bll factory using cache.
        DAL.DalBase<T> dalBase;
        public DAL.DalBase<T> DalBase
        {
            get
            {
                if (dalBase == null)
                    dalBase = new DAL.DalBase<T>();
                return dalBase;
            }
            set
            {
                dalBase = value;
            }
        }
        public T GetOne(object id)
        {
            return DalBase.GetOne(id);
        }
       
    
        public void Delete(T t)
        {
            DalBase.Delete(t);
        }
        public void SaveOrUpdate(T t)
        {
            DalBase.SaveOrUpdate(t);
        }
        public void Save(T t)
        {
            DalBase.Save(t);
        }
        public IList<T> GetAll<T>() where T : class
        {
            return DalBase.GetAll<T>();
        }
        protected IList<T> GetList(string where)
        {
            return DalBase.GetList(where);
        }
        protected IList<T> GetList(string where, int pageIndex, int pageSize, out int totalRecord)
        {
            return DalBase.GetList(where, pageIndex, pageSize, out totalRecord);
        }
    }
    //to be used for bll factory
    public enum BLLName
    {
        BLLQZSpringPartner
    }
}
