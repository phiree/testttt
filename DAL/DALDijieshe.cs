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
            string sql = "select TE from DJ_TourEnterprise TE where ";
            if (areaid != 0)
            {
                sql += " TE.Area.Id=" + areaid + " and";
            }
            if (!string.IsNullOrEmpty(type))
            {
                sql += " TE.Type=" + (int)(Model.EnterpriseType)Enum.Parse(typeof(Model.EnterpriseType), type) + " and";
            }
            if (!string.IsNullOrEmpty(id))
            {
                sql += " TE.Id='" + id + "' and";
            }
            if (!string.IsNullOrEmpty(namelike))
            {
                sql += " TE.Name like '%" + namelike + "%' and";
            }
            sql = sql.Substring(0, sql.Length - 3);
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourEnterprise>().ToList<Model.DJ_TourEnterprise>();
        }

        #endregion

        #region group

        public Guid AddGroup(Model.DJ_TourGroup tg)
        {
            Guid result = Guid.NewGuid();
            tg.Id = result;
            using (var t = session.BeginTransaction())
            {
                session.Save(tg);
                t.Commit();
            }
            return result;
        }

        public void UpdateGroup(Model.DJ_TourGroup tg)
        {
            using (var t = session.BeginTransaction())
            {
                session.Update(tg);
                t.Commit();
            }
        }

        #endregion


    }
}
