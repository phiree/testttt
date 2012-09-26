using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
    public interface IDJRoute
    {
        DJ_Route GetById(Guid routeId);
        void SaveOrUpdate(DJ_Route route);
        void Delete(DJ_Route route);
    }
  
}
