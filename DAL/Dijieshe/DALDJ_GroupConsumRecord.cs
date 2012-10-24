using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJ_GroupConsumRecord:DalBase,IDJGroupConsumRecord
    {

        public void Save(Model.DJ_GroupConsumRecord group)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Save(group);
                x.Commit();
            }
        }


        public Model.DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(Guid RouteId)
        {
            string sql = "select gcr from DJ_GroupConsumRecord gcr where gcr.Route.Id='" + RouteId + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_GroupConsumRecord>().Value;
        }

        public Model.DJ_GroupConsumRecord GetGcr8Name(string EnterpName,string Groupid)
        {
            string sql = "select gcr from DJ_GroupConsumRecord gcr where gcr.Enterprise.Name='" + EnterpName
                + "' and gcr.Route.DJ_TourGroup.Id='" + Groupid + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_GroupConsumRecord>().Value;
        }


        public IList<Model.DJ_TourGroup> GetFeRecordByETId(int etid)
        {
            //在dal中只查询出该旅游单位的记录
            string sql = "select r.Route.DJ_TourGroup from DJ_GroupConsumRecord r where r.Enterprise.Id=" + etid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }




        public List<Model.DJ_GroupConsumRecord> GetRecordByAllCondition(string groupname, string EntName, string BeginTime, string EndTime, int enterid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select d from DJ_GroupConsumRecord d where 1=1");
            sql.Append(" and d.Route.DJ_TourGroup.Name like '%" + groupname + "%'");
            sql.Append(" and d.Route.DJ_TourGroup.DJ_DijiesheInfo.Name like '%" + EntName + "%'");
            sql.Append(" and d.Enterprise.Id=" + enterid + "");
            if (BeginTime != "" && EndTime == "")
            {
                sql.Append(" and d.ConsumeTime>='" + BeginTime + "'");
            }
            if (BeginTime == "" && EndTime != "")
            {
                sql.Append(" and d.ConsumeTime<='" + DateTime.Parse(EndTime).AddDays(1).ToShortDateString() + "'");
            }
            if (BeginTime != "" && EndTime != "")
            {
                sql.Append(" and d.ConsumeTime>='" + BeginTime + "' and d.ConsumeTime<='" + DateTime.Parse(EndTime).AddDays(1).ToShortDateString() + "'");
            }
            sql.Append(" order by d.ConsumeTime desc");
            IQuery query = session.CreateQuery(sql.ToString());
            return query.Future<Model.DJ_GroupConsumRecord>().ToList<Model.DJ_GroupConsumRecord>();
        }

        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="areacode"></param>
        /// <param name="enterpname">消费场所</param>
        /// <param name="groupid"></param>
        /// <param name="routeid"></param>
        /// <param name="djsname">所属地接社</param>
        /// <returns></returns>
        public IList<Model.DJ_GroupConsumRecord> GetGCR8Multi(string areacode, string enterpname, string groupid, string routeid,string djsname)
        {
            bool ifcondition = false;
            string sql = "select gcr from DJ_GroupConsumRecord gcr where";
            if (!string.IsNullOrEmpty(areacode))
            {
                ifcondition = true;
                sql += " gcr.Enterprise.Area.Code='" + areacode + "' and";
            }
            if (!string.IsNullOrEmpty(enterpname))
            {
                ifcondition = true;
                sql += " gcr.Enterprise.Name='" + enterpname + "' and";
            }
            if (!string.IsNullOrEmpty(djsname))
            {
                ifcondition = true;
                sql += " gcr.Route.DJ_TourGroup.DJ_DijiesheInfo.Name='" + djsname + "' and";
            }
            if (!string.IsNullOrEmpty(groupid))
            {
                ifcondition = true;
                sql += " gcr.Route.DJ_TourGroup.Id='" + groupid + "' and";
            }
            if (!string.IsNullOrEmpty(routeid))
            {
                ifcondition = true;
                sql += " gcr.Route.Id='" + routeid + "' and";
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
            return query.Future<Model.DJ_GroupConsumRecord>().ToList();
        }
    }
}
