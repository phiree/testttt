using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;
namespace DAL
{
    public class DALDJ_Route:DalBase,IDAL.IDJRoute
    {

        public Model.DJ_Route GetById(Guid routeId)
        {
            return session.Get<DJ_Route>(routeId);
        }

        public void SaveOrUpdate(Model.DJ_Route route)
        {
            session.SaveOrUpdate(route);
        }

        public void Delete(Model.DJ_Route route)
        {
            session.Delete(route);
        }
    }
}
