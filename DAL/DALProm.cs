using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALProm:DalBase,IDAL.IProm
    {
        public IList<Model.PromotionStatic> GetPromById(int psid)
        {
            string sql = "select ps from PromotionStatic ps where ps.Id=" + psid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.PromotionStatic>().ToList<Model.PromotionStatic>();
        }

        public Model.PromotionStatic GetPromByUsername(string username)
        {
            string sql = "select ps from PromotionStatic ps where ps.User.Name='" + username + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.PromotionStatic>().ToList<Model.PromotionStatic>()[0];
        }

        public void AddPromInfo(Model.PromotionStatic prom)
        {
            using (var tx = session.BeginTransaction())
            {
                session.Save(prom);
                tx.Commit();
            }
        }

        public void UpdatePromInfo(Model.PromotionStatic prom)
        {
            using (var tx = session.BeginTransaction())
            {
                session.Update(prom);
                tx.Commit();
            }
        }

    }
}
