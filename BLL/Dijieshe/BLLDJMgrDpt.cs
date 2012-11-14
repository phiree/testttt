using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;
using NHibernate;
namespace BLL
{
   public class BLLDJMgrDpt:DalBase
    {
       public Model.DJ_GovManageDepartment GetMgrDpt(Guid id)
       {
         return  session.Get<Model.DJ_GovManageDepartment>(id);
         
       }
       public void Save(Model.DJ_GovManageDepartment mgrDpt)
       {
           session.Save(mgrDpt);
           session.Flush();
       }
       public IList<Model.DJ_GovManageDepartment> GetMgrDptList(string areaCode)
       {
           string ids = new BLLArea().GetChildAreaIds(areaCode);
           string sql = "select gcr from DJ_GovManageDepartment gcr";
           if (ids != string.Empty)
           {
              sql+=" where gcr.Area.Id in (" + ids + ")";
           }
      
           IQuery query = session.CreateQuery(sql);
           return query.Future<Model.DJ_GovManageDepartment>().ToList();

           //throw new NotImplementedException();
       }
    }
}
