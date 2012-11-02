using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJ_GovManageDepartment : DalBase, IDJ_GovManageDepartment
    {

        public void Save(DJ_GovManageDepartment obj)
        {
            session.Save(obj);
            session.Flush();
        }

        public IList<DJ_GovManageDepartment> GetGovDptByName(string name)
        {
            string sql = "select d from DJ_GovManageDepartment d where d.Name like '%" + name + "%'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<DJ_GovManageDepartment>().ToList<DJ_GovManageDepartment>();
        }


        public DJ_GovManageDepartment GetById(Guid id)
        {
            return session.Get<DJ_GovManageDepartment>(id);
        }
    }
}
