using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALDJEnterprise : DalBase,IDAL.IDJEnterprise
    {
        #region DJS

        public int AddDJS(Model.DJ_TourEnterprise djs)
        {
          
        
            using (var t = session.BeginTransaction())
            {
                session.SaveOrUpdate(djs);
                t.Commit();
            }
            session.Flush();
           return djs.Id;
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
            string sql = "select D from DJ_TourEnterprise D";
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
                sql += " D.Name = '" + namelike + "' and";
            }
            sql = sql.Substring(0, sql.Length - 3);
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourEnterprise>().ToList<Model.DJ_TourEnterprise>();
        }

        /// <summary>
        /// 多个区域内的旅游企业
        /// </summary>
        ///      <param name="areaIds">辖区对应的areaid, 用逗号隔开</param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.DJ_TourEnterprise> GetDJSInAreas(string areaids)
        {
            string where = " and  D.Area.Id in ( " + areaids + ")";

            return GetDJS8Multi(where);

        }

        public IList<Model.DJ_TourEnterprise> GetEnterpriseWithoutScenic(string areaIds)
        {
            string where = string.Empty;
            if(!string.IsNullOrEmpty(areaIds))
            {
                where += " and D.Area.Id in (" + areaIds + ")";
            }
          where = " and D.Type<>"+(int) Model.EnterpriseType.景点;

            return GetDJS8Multi(where);

        }

        private IList<Model.DJ_TourEnterprise> GetDJS8Multi(string where)
        {
            string sql = "select D from DJ_TourEnterprise D where D.Type<>0 ";
            sql = sql + where;
            IQuery query = session.CreateQuery(sql);
            return query.List<Model.DJ_TourEnterprise>();
        }

        #endregion

        #region group

        public Guid AddGroup(Model.DJ_TourGroup tg)
        {
            using (var t = session.BeginTransaction())
            {
                foreach (var item in tg.Members)
                {
                    session.Save(item);
                }
                foreach (var item in tg.Workers)
                {
                    session.Save(item);
                }
                foreach (var item in tg.Vehicles)
                {
                    session.Save(item);
                }
                foreach (var item in tg.Routes)
                {
                    session.Save(item);
                }
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

        #region groupmem

        public void UpdateGuide(Model.DJ_Group_Worker gg)
        {
            using (var t = session.BeginTransaction())
            {
                session.Update(gg);
                t.Commit();
            }
        }

        public void UpdateDriver(Model.DJ_Group_Worker gd)
        {
            using (var t = session.BeginTransaction())
            {
                session.Update(gd);
                t.Commit();
            }
        }


        //public IList<Model.DJ_Group_Base> GetDriver(string id)
        //{
        //    string sql = "select G from DJ_Group_Base G where TourEnterprise.Id='" + id + "'";
        //    IQuery query = session.CreateQuery(sql);
        //    return query.Future<Model.DJ_Group_Base>().ToList<Model.DJ_Group_Base>();
        //}

        public IList<Model.DJ_Group_Worker> GetGroupmem8epid(string id)
        {
            string sql = "select G from DJ_Group_Base G where TourEnterprise.Id='" + id + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Group_Worker>().ToList<Model.DJ_Group_Worker>();
        }


        public IList<Model.DJ_Group_Worker> GetGuide8id(string id)
        {
            string sql = "select G from DJ_Group_Worker G where Id='" + id + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Group_Worker>().ToList();
        }

        public IList<Model.DJ_Group_Worker> GetDriver8id(string id)
        {
            string sql = "select G from DJ_Group_Worker G where Id='" + id + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_Group_Worker>().ToList();
        }

        #endregion

    }
}
