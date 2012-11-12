using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJ_GovManageDepartment : DalBase<DJ_GovManageDepartment>, IDJ_GovManageDepartment
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

        public IList<DJ_GovManageDepartment> GetSubDptByCode(string code)
        {
            string sql="select d from DJ_GovManageDepartment d where 1=1";
            if (code.Substring(2) == "0000")
            {
                sql += " and d.Area.Code like '" + code.Substring(0, 2) + "____'";
            }
            else if (code.Substring(4) == "00")
            {
                sql += " and d.Area.Code like '" + code.Substring(0, 4) + "__'";
            }
            else
            {
                sql += "and d.Area.Code='" + code + "'";
            }
            int total;
            return this.GetList(sql, 1, 9999, out total);
        }
    }
}
