using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
    public interface IDJProduct
    {
        DJ_Product GetById(Guid productId);

        void Save(DJ_Product product);

        IList<DJ_Product> GetListByTEId(Guid TEId);

    }
}
