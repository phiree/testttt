using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using DAL;
namespace BLL
{
   public class BLLDJ_Route
    {
       IDAL.IDJRoute idalroute = new DAL.DALDJ_Route();
       public DJ_Route GetById(Guid routeid)
       {
           return idalroute.GetById(routeid);
       }
       public void SaveOrUpdate(DJ_Route route)
       {
           idalroute.SaveOrUpdate(route);
       }
       public void Delete(DJ_Route route)
       {
           idalroute.Delete(route);
       }
    }
}
