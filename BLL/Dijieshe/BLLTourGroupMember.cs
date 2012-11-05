using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
   public class BLLTourGroupMember
    {
       private DALDJTourGroupMember dalMember;
       public DALDJTourGroupMember DalMember
       {
           get {
               if (dalMember == null)
               {
                   dalMember = new DALDJTourGroupMember();
               }
               return dalMember;
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
