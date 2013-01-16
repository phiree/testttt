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
       public DALDJProduct  DalDJProduc = new DALDJProduct();
       public DJ_Product GetById(Guid productId)
       {
           return DalDJProduc.GetOne(productId);
       }
       public void Save(DJ_Product product)
       {
           DalDJProduc.Save(product);
       }
       public IList<DJ_Product> GetListByDjsID(int dijiesheid)
       {
           return DalDJProduc.GetProductListByDjsId(dijiesheid);
       }
      
    }
}
