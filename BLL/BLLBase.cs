using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class BLLBase<T>
    {
       DAL.DalBase<T> dalBase;
       public DAL.DalBase<T> DalBase
        {
            get {
                if (dalBase == null)
                    dalBase = new DAL.DalBase<T>();
                return dalBase;
            }
            set {
                dalBase = value;
            } 
       }

       public void Save(T t)
       {
           DalBase.Save(t);
       }

       public void SaveOrUpdate(T t)
       {
           DalBase.SaveOrUpdate(t);
       }
    }
}
