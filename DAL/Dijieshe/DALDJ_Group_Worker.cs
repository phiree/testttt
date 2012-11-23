using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALDJ_Group_Worker:DalBase,IDAL.IDJ_Group_Worker
    {
        #region 关系表

        public IList<Model.DJ_TourGroup> GetTgListByIdcard(string idcard)
        {
         string sql = "select gw.DJ_TourGroup from DJ_Group_Worker gw where gw.IDCard='" + idcard + "' and gw.WorkerType=1 ";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }

        public Model.DJ_Group_Worker GetById(Guid id)
        {
            return session.Get<Model.DJ_Group_Worker>(id);
        }

        public Model.DJ_Group_Worker GetByIdCard(string idcard)
        {
            string sql = "select gw from DJ_TourGroupMember gw where gw.IdCardNo='" + idcard + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_Group_Worker>().Value;
        }

        public IList<Model.DJ_Group_Worker> Get8Multi(string id, string name, string phone, string idcard, string specificidcard, object memtype, string gid,string djsid)
        {
            bool ifcondition = false;
            string sql = "select gw from DJ_Group_Worker gw where ";
            if (!string.IsNullOrEmpty(id))
            {
                ifcondition = true;
                sql += " gw.DJ_Workers.Id='" + id + "' and";
            }
            if (!string.IsNullOrEmpty(name))
            {
                ifcondition = true;
                sql += "gw.DJ_Workers.Name='" + name + "' and";
            }
            if (!string.IsNullOrEmpty(phone))
            {
                ifcondition = true;
                sql += " gw.DJ_Workers.Phone='" + phone + "' and";
            }
            if (!string.IsNullOrEmpty(idcard))
            {
                ifcondition = true;
                sql += " gw.DJ_Workers.IDCard='" + idcard + "' and";
            }
            if (!string.IsNullOrEmpty(specificidcard))
            {
                ifcondition = true;
                sql += " gw.DJ_Workers.SpecificIdCard='" + specificidcard + "' and";
            }
            if (memtype!=null)
            {
                ifcondition = true;
                sql += " gw.DJ_Workers.WorkerType=" + (int)(Model.MemberType)memtype + " and";
            }
            if (!string.IsNullOrEmpty(gid))
            {
                ifcondition = true;
                sql += " gw.DJ_TourGroup.Id='" + gid + "' and";
            }
            if (!string.IsNullOrEmpty(djsid))
            {
                ifcondition = true;
                sql += " gw.DJ_Workers.DJ_Dijiesheinfo.Id='" + djsid + "' and";
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
            return query.Future<Model.DJ_Group_Worker>().ToList();
        }

        #endregion
    }
}
