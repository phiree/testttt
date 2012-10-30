using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace BLL
{
   public class BLLTourGroupMember:DAL.DalBase
    {
       public void DeleteMember(DJ_TourGroupMember member)
       {
           session.Delete(member);
       }

       
    }
}
