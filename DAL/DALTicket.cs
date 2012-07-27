using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALTicket:DalBase,ITicket
    {

        public IList<Model.Ticket> GetTicketByAreaId(int areaid)
        {
            string sql = "select t from Ticket t where t.Scenic.Area.Id=" + areaid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().ToList<Model.Ticket>();
        }


        public IList<Model.Ticket> GetTicketByscId(int scid)
        {
            string sql = "select t from Ticket t where t.Scenic.Id="+scid+"";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Ticket>().ToList<Model.Ticket>();
        }


        public IList<Model.Ticket> GetTicketByAreaIdAndLevel(int areaId, int level,int pageIndex,int pageSize ,out int totalRecord)
        {

            string where = " where  1=1 and Lock=false ";
            if (areaId > 0)
            {
                where += " and  t.Scenic.Area=" + areaId;
            }
            if (level > 0)
            {
                where += " and t.Scenic.Level='" + level + "A'";
            }
            string order = " order by t.Scenic.Name desc";


            string fromwhere = " from Ticket t " + where;
            string strQuery = "select t " + fromwhere + order ;
            string strQueryCount = "select count(*) " + fromwhere;


            return Search(strQuery, strQueryCount, pageIndex, pageSize, out totalRecord);


          
        }
        public IList<Model.Ticket> Search(string q, int pageIndex, int pageSize, out int totalRecord)
        {
            string strQuery, strQueryCount;

            strQuery = "select t from Ticket t where t.Scenic.Name like '%" + q + "%'";
            strQueryCount = "select count(*) from Ticket t where t.Scenic.Name like '%"+q+"%'";
            return Search(strQuery, strQueryCount, pageIndex, pageSize, out totalRecord);
        }
        private IList<Model.Ticket> Search(string strQuery, string strQueryCount, int pageIndex, int pageSize, out int totalRecord)
        {
             IQuery qryTotal = session.CreateQuery(strQueryCount);
            IQuery qry = session.CreateQuery(strQuery);

            List<Model.Ticket> ticketList = qry.Future<Model.Ticket>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            totalRecord =(int) qryTotal.FutureValue<long>().Value;
            return ticketList;
        }
        public void SaveOrUpdateTicket(Model.Ticket ticket)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(ticket);
                x.Commit();
            }
        }
        public Model.Ticket Get(int ticketId)
        {
            Model.Ticket t = session.Get<Model.Ticket>(ticketId);
            return t;
        }
        public Model.Ticket GetByScenicSeo(string scenicSeoName)
        {
           var strQuery = "select t from Ticket t where t.Scenic.SeoName ='" + scenicSeoName + "'";
           IQuery qry = session.CreateQuery(strQuery);
           Model.Ticket t= qry.FutureValue<Model.Ticket>().Value;
           return t;
        }
    }
}
