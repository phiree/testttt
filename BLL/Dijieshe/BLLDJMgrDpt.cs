using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
   public class BLLDJMgrDpt:BLLBase<Model.TourMembership>
    {
       public Model.DJ_GovManageDepartment GetMgrDpt(Guid id)
       {
           return null;
           //session.Get<Model.DJ_GovManageDepartment>(id);
         
       }
       public void Save(Model.DJ_GovManageDepartment mgrDpt)
       {
           //session.Save(mgrDpt);
           //session.Flush();
       }
       public IList<Model.DJ_GovManageDepartment> GetMgrDptList(string dptName,string areaCode)
       {
           string ids = new BLLArea().GetChildAreaIds(areaCode);
           string sql = "select gcr from DJ_GovManageDepartment gcr where 1=1 ";
           if (ids != string.Empty)
           {
              sql+=" and gcr.Area.Id in (" + ids + ")";
           }
           if (!string.IsNullOrEmpty(dptName))
           {
               sql += " and gcr.Name like '%" + dptName + "%'";
           }
           //IQuery query = session.CreateQuery(sql);
           //return query.Future<Model.DJ_GovManageDepartment>().ToList();

           throw new NotImplementedException();
       }
    }
}
