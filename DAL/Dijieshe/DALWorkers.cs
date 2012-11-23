using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NHibernate;

namespace DAL
{
    public class DALWorkers:DalBase
    {

        #region 导游司机列表

        public IList<Model.DJ_Workers> Get8Multi(string id, string name, string phone, string idcard, string specificidcard, object memtype, string djsid)
        {
            bool ifcondition = false;
            string sql = "select w from DJ_Workers w where ";
            if (!string.IsNullOrEmpty(id))
            {
                ifcondition = true;
                sql += " w.Id='" + id + "' and";
            }
            if (!string.IsNullOrEmpty(name))
            {
                ifcondition = true;
                sql += " w.Name='" + name + "' and";
            }
            if (!string.IsNullOrEmpty(phone))
            {
                ifcondition = true;
                sql += " w.Phone='" + phone + "' and";
            }
            if (!string.IsNullOrEmpty(idcard))
            {
                ifcondition = true;
                sql += " w.IDCard='" + idcard + "' and";
            }
            if (!string.IsNullOrEmpty(specificidcard))
            {
                ifcondition = true;
                sql += " w.SpecificIdCard='" + specificidcard + "' and";
            }
            if (memtype != null)
            {
                ifcondition = true;
                sql += " w.WorkerType=" + (int)(Model.MemberType)memtype + " and";
            }
            if (!string.IsNullOrEmpty(djsid))
            {
                ifcondition = true;
                sql += " w.DJ_Dijiesheinfo.Id='" + djsid + "' and";
            }

            if (ifcondition)//如果有条件的string截取方式
            {
                sql = sql.Substring(0, sql.Length - 3);
            }
            else//如果没条件的string截取方式
            {
                sql = sql.Substring(0, sql.Length - 5);
            }
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Workers>().ToList();
        }

        #endregion
    }
}
