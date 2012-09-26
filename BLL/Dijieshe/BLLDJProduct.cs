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
       IDAL.IDJProduct IDJProduc = new DALDJProduct();
       public DJ_Product GetById(Guid productId)
       {
           return IDJProduc.GetById(productId);
       }
       public void Save(DJ_Product product)
       {
           IDJProduc.Save(product);
       }

       public IList<DJ_Product> GetList()
       { 
        
       }
    }
}
