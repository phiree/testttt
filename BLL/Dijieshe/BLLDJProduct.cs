using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using DAL;
namespace BLL
{
   public class BLLDJProduct
    {
       IDAL.IDJProduct IDJProduct;
       public DJ_Product GetById(Guid productId)
       {
           return IDJProduct.GetById(productId);
       }
    }
}
