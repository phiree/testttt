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
        public IList<Model.DJ_Workers> GetWorkers8Multy(string id, string name, string idcard,string SpecificIdCard,
            int WorkerType, DJ_DijiesheInfo DJ_DijiesheInfo, string CompanyBelong)
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
                sql += "w.Name='" + name + "' and";
            }
            if (!string.IsNullOrEmpty(idcard))
            {
                ifcondition = true;
                sql += " w.IDCard='" + idcard + "' and";
            }
            if (!string.IsNullOrEmpty(SpecificIdCard))
            {
                ifcondition = true;
                sql += " w.SpecificIdCard='" + SpecificIdCard + "' and";
            }
            if (WorkerType!=0)
            {
                ifcondition = true;
                sql += " w.WorkerType='" + WorkerType + "' and";
            }
            if (DJ_DijiesheInfo != null)
            {
                ifcondition = true;
                sql += " w.DJ_Dijiesheinfo=" + DJ_DijiesheInfo + " and";
            }
            if (!string.IsNullOrEmpty(CompanyBelong))
            {
                ifcondition = true;
                sql += " w.CompanyBelong.Id='" + CompanyBelong + "' and";
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
    }
}
