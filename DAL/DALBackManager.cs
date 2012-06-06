using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALBackManager:DalBase,IDAL.IBackManager
    {
        public List<Model.Scenic> GetScenicList(string strCondition)
        {
            string str="select s from Scenic s";
            if (!string.IsNullOrWhiteSpace(strCondition))
            {
                str += strCondition;
            }
            IQuery query = session.CreateQuery(str);
            return query.Future<Model.Scenic>().ToList<Model.Scenic>();
        }
        
        public List<Model.Scenic> GetScenicList(string strCondition, int pageIndex, int pageSize,out long totalRecord)
        {
            
            string strQuery="select s from Scenic s";
            string strQueryCount="select count(*) from Scenic s";
            
            if (!string.IsNullOrWhiteSpace(strCondition))
            {
                strQuery += strCondition;
                strQueryCount+=strCondition;
            }
            IQuery qryTotal = session.CreateQuery(strQueryCount);
            IQuery qry = session.CreateQuery(strQuery) ;
            List<Model.Scenic> scenicList = qry.Future<Model.Scenic>().Skip(pageIndex*pageSize).Take(pageSize). ToList();
            totalRecord = qryTotal.FutureValue<long>().Value;
            return scenicList;
        }

        public bool ScenicinfoPass(int id)
        {
            bool result = false;
            return result;
        }

        public List<Model.PromotionStatic> GetPromList(string strCondition)
        {
            string str = "select ps from PromotionStatic ps";
            if (!string.IsNullOrWhiteSpace(strCondition))
            {
                str += strCondition;
            }
            IQuery query = session.CreateQuery(str);
            return query.Future<Model.PromotionStatic>().ToList<Model.PromotionStatic>();
        }

        public List<Model.PromotionStatic> GetPromList(string strCondition, int pageIndex, int pageSize, out long totalRecord)
        {
            pageIndex -= 1;
            string strQuery = "select ps from PromotionStatic ps";
            string strQueryCount = "select count(*) from PromotionStatic ps";

            if (!string.IsNullOrWhiteSpace(strCondition))
            {
                strQuery += strCondition;
                strQueryCount += strCondition;
            }
            IQuery qryTotal = session.CreateQuery(strQueryCount);
            IQuery qry = session.CreateQuery(strQuery)
               ;
            List<Model.PromotionStatic> promList = qry.Future<Model.PromotionStatic>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            totalRecord = qryTotal.FutureValue<long>().Value;
            return promList;
        }

        public void AddProm(Model.PromotionStatic prom)
        {

        }
    }
}
