using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALTicket:DalBase
    {

        public IList<Model.Ticket> GetTicketByAreaId(int areaid)
        {
            string sql = "select t from Ticket t where t.Scenic.Area.Id=" + areaid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().ToList<Model.Ticket>();
        }


        public IList<Model.TicketNormal> GetTicketByscId(int scid)
        {
            var ticketList = session.QueryOver<Model.TicketNormal>().Where(x => x.Scenic.Id == scid && x.IsMain == true).List();
            //string sql = "select t from Ticket t where t.Scenic.Id="+scid+"";
            //IQuery query = session.CreateQuery(sql);
            return ticketList;
        }


        public IList<Model.Scenic> GetTicketByAreaIdAndLevel(Model.Area area, int level,string topic,int pageIndex,int pageSize ,out int totalRecord)
        {
            string where = " where IsHide<>true ";
            if (area!=null)
            {
                if (area.Code.Substring(4, 2) == "00")
                    where += " and  s.Area.Code like '%" + area.Code.Substring(0, 4) + "%'";
                else
                    where += " and s.Area.Id=" + area.Id;
            }
            else
            {
                where += " and s.Area.Code like '33%' ";
            }
            if (level > 0)
            {
                where += " and s.Level='" + level + "A'";
            }
            string order = " order by s.ScenicOrder asc";


            string fromwhere = " from Scenic s " + where;
            string strQuery = "select s " + fromwhere + order ;
            string strQueryCount = "select count(*) " + fromwhere;
            if(topic==null)
            {
                return  Search(strQuery, strQueryCount, pageIndex, pageSize, out totalRecord);
            }
            else
            {
                string topicsql = "select st from ScenicTopic st where st.Topic.seoname='" + topic + "'";
                IQuery query = session.CreateQuery(topicsql);
                List<Model.ScenicTopic> listtopic= query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
                query = session.CreateQuery(strQuery);
                List<Model.Scenic> list = query.Future<Model.Scenic>().ToList<Model.Scenic>();
                var result=from t in listtopic join l in list on t.Scenic.Id equals l.Id select l;
                totalRecord = result.ToList<Model.Scenic>().Count;
                return result.ToList<Model.Scenic>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }         
        }
        public IList<Model.Scenic> Search(string q, int pageIndex, int pageSize, out int totalRecord)
        {
            string strQuery, strQueryCount;

            strQuery = "select s from Scenic s where s.Name like '%" + q + "%'";
            strQueryCount = "select count(*) from Scenic s where s.Name like '%"+q+"%'";
            return Search(strQuery, strQueryCount, pageIndex, pageSize, out totalRecord);
        }
        private IList<Model.Scenic> Search(string strQuery, string strQueryCount, int pageIndex, int pageSize, out int totalRecord)
        {
             IQuery qryTotal = session.CreateQuery(strQueryCount);
            IQuery qry = session.CreateQuery(strQuery);

            List<Model.Scenic> ticketList = qry.Future<Model.Scenic>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            totalRecord =(int) qryTotal.FutureValue<long>().Value;
            return ticketList;
        }
        public void SaveOrUpdateTicket(Model.Ticket ticket)
        {
            using (var t=session.BeginTransaction())
            {
                session.SaveOrUpdate(ticket);
                session.Flush();
                t.Commit();
            }
        }

        public void SaveOrUpdateTicket(IList<Model.Ticket> tickets)
        {
            foreach (var item in tickets)
            {
                SaveOrUpdateTicket(item);
            }
        }
        public Model.Ticket Get(int ticketId)
        {
           var t = session.Get<Model.Ticket>(ticketId);
            return t;
        }
        public Model.Ticket GetByScenicSeo(string scenicSeoName)
        {
           var strQuery = "select t from Ticket t where t.Scenic.SeoName ='" + scenicSeoName + "'";
           IQuery qry = session.CreateQuery(strQuery);
           Model.Ticket t= qry.FutureValue<Model.Ticket>().Value;
           return t;
        }


        public IList<Model.Ticket> GetTp(int scid)
        {
            string sql = "select t from Ticket t where t.Scenic.Id=" + scid + " and Lock=false";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().OrderByDescending(x=>x.OrderNumber).ToList();
        }

        public Model.Ticket GetByProductCode(string productCode)
        {
            var strQuery = "select t from Ticket t where t.ProductCode ='" + productCode + "'";
            IQuery qry = session.CreateQuery(strQuery);
            Model.Ticket t =(Model.Ticket)session.GetSessionImplementation().PersistenceContext.Unproxy( qry.FutureValue<Model.Ticket>().Value);
            return t;
        }


        public void Delete(Model.Ticket t)
        {
            session.Delete(t);
            session.Flush();
        }

        public IList<Model.Ticket> GetListByMultitTicketCode(IList<string> ticketCodes)
        {
           return  session.QueryOver<Model.Ticket>()
                .Where(x => ticketCodes.Contains(x.ProductCode)).List();
        }
    }
}
