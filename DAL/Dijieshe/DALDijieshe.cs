using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALDijieshe : DalBase,IDAL.IDijieshe
    {
        #region DJS

        public Guid AddDJS(Model.DJ_TourEnterprise djs)
        {
            Guid result=Guid.NewGuid();
            djs.Id = result;
            using (var t = session.BeginTransaction())
            {
                session.Save(djs);
                t.Commit();
            }
            return result;
        }

        public void DeleteDJS()
        {
            throw new NotImplementedException();
        }

        public void UpdateDJS()
        {
            throw new NotImplementedException();
        }

        public IList<Model.DJ_TourEnterprise> GetDJS8All()
        {
            string sql = "select D from DJ_DijiesheInfo D";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourEnterprise>().ToList<Model.DJ_TourEnterprise>();
        }

        public IList<Model.DJ_TourEnterprise> GetDJS8Muti(int areaid, string type, string id, string namelike)
        {
            string sql = "select D from DJ_TourEnterprise D where ";
            if (areaid != 0)
            {
                sql += " D.Area.Id=" + areaid + " and";
            }
            if (!string.IsNullOrEmpty(type))
            {
                sql += " D.Type=" + (int)(Model.EnterpriseType)Enum.Parse(typeof(Model.EnterpriseType), type) + " and";
            }
            if (!string.IsNullOrEmpty(id))
            {
                sql += " D.Id='" + id + "' and";
            }
            if (!string.IsNullOrEmpty(namelike))
            {
                sql += " D.Name like '%" + namelike + "%' and";
            }
            sql = sql.Substring(0, sql.Length - 3);
            IQuery query = session.CreateQuery(sql);
            return query.List<Model.DJ_TourEnterprise>();
        }

        #endregion

        #region group

        public Guid AddGroup(Model.DJ_TourGroup tg)
        {
            using (var t = session.BeginTransaction())
            {
                session.Save(tg);
                t.Commit();
            }
            return tg.Id;
        }

        public void UpdateGroup(Model.DJ_TourGroup tg)
        {
            using (var t = session.BeginTransaction())
            {
                foreach (var item in tg.Members)
                {
                    session.Save(item);
                }
                session.Update(tg);
                t.Commit();
            }
        }

        public Model.DJ_TourGroup GetGroup8name(string name)
        {
            string sql = "select G from DJ_TourGroup G where G.Name='" + name + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_TourGroup>().Value;
        }

        public Model.DJ_TourGroup GetGroup8gid(string groupid)
        {
            string sql = "select G from DJ_TourGroup G where G.Id='" + groupid + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_TourGroup>().Value;
        }

        public IList<Model.DJ_TourGroup> GetGroup8all()
        {
            string sql = "select G from DJ_TourGroup G";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }
        #endregion
    }
}
