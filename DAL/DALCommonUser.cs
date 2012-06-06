using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALCommonUser:DalBase,IDAL.ICommonUser
    {
        public IList<Model.CommonUser> GetCommonUserByUserIdandidcard(Guid userid)
        {
            string sql = "select cu from CommonUser cu where cu.User.Id='" + userid + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<CommonUser>().ToList();
        }


        public void SaveCommonUser(CommonUser commonuser)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Save(commonuser);
                x.Commit();
            }
        }
        public Model.CommonUser GetCommonUserByUserIdandidcard(Guid userid, string idcard)
        {
            string sql = "select cu from CommonUser cu where cu.User.Id='" + userid + "' and IdCard='" + idcard + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<CommonUser>().Value;
        }


        public CommonUser Get(Guid userid, string name, string idcard)
        {
            string sql = "select cu from CommonUser cu where cu.User.Id='" + userid + "' and IdCard='" + idcard + "' and Name='"+name+"'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<CommonUser>().Value;
        }


        public IList<CommonUser> SearchCommonUser(string name)
        {
            string sql = "select cu from CommonUser cu  where cu.Name like '%" + name + "%'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<CommonUser>().ToList<CommonUser>();
        }


        public void deleteCommonUser(int id)
        {
            string sql = "select cu from CommonUser cu where cu.Id=" + id + "";
            IQuery query = session.CreateQuery(sql);
            CommonUser cu = query.FutureValue<CommonUser>().Value;
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Delete(cu);
                x.Commit();
            }
        }


        public CommonUser GetCommonUserByid(int id)
        {
            string sql = "select cu from CommonUser cu where cu.Id=" + id + "";
            IQuery query = session.CreateQuery(sql);
           return query.FutureValue<CommonUser>().Value;
        }


        public void updatecu(CommonUser cu)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Update(cu);
                x.Commit();
            }
        }


        public IList<CommonUser> GetCommonUserByIdCard(string idcard)
        {
            string sql = "select cu from CommonUser cu where cu.IdCard='" + idcard + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<CommonUser>().ToList<CommonUser>();
        }
    }
}
