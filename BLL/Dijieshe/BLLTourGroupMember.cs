using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
   public class BLLTourGroupMember:BLLBase<DJ_TourGroupMember>
    {
    //   private DALDJTourGroupMember dalMember;
       public DALDJTourGroupMember DalMember
       {
           get {
               if (dalBase == null)
               {
                   dalBase = new DALDJTourGroupMember();
               }
               return dalBase;
           }
           set { dalMember = value; }
       }

       public void SaveOrUpdate(Model.DJ_TourGroupMember member)
       {
           DalMember.SaveOrUpdate(member);
       }
       public Model.DJ_TourGroupMember GetOne(Guid id)
       {
           return DalMember.GetOne(id);
       }
       public void Delete(Model.DJ_TourGroupMember member)
       {
           DalMember.Delete(member);
       }
    }
}
