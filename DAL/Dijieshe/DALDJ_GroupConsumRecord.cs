﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;
using Model;
namespace DAL
{
    public class DALDJ_GroupConsumRecord:DalBase
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
            if (!string.IsNullOrEmpty(groupname))
            {
                sql.Append(" and d.Route.DJ_TourGroup.Name like '%" + groupname + "%'");
            }
            if (!string.IsNullOrEmpty(EntName))
            {


                sql.Append(" and d.Route.DJ_TourGroup.DJ_DijiesheInfo.Name like '%" + EntName + "%'");
            }
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
                sql.Append(" and d.ConsumeTime>='" + BeginTime + "' and d.ConsumeTime<='" + DateTime.Parse(EndTime).ToShortDateString() + "'");
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
        public IList<Model.DJ_GroupConsumRecord> GetGCR8Multi(string areacode, string enterpname, string groupid, string routeid, string djsname)
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
            //if (!string.IsNullOrEmpty(b_date))
            //{
            //    string[] temp = b_date.Split(new char[] { '-'});
            //    if (temp.Length >= 2)
            //    {
            //        ifcondition = true;
            //        sql += " gcr.ConsumeTime>=" + new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1) +
            //            " and gcr.ConsumeTime<" + new DateTime(int.Parse(temp[0]), int.Parse(temp[1]) + 1, 1) + " and";
            //    }
            //}
            //if (string.IsNullOrEmpty(b_date))
            //{
            //    ifcondition = true;
            //    sql += " gcr.ConsumeTime>=" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) +
            //        " and gcr.ConsumeTime<" + new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1) + " and";
            //}

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


        public IList<Model.DJ_GroupConsumRecord> GetRecordByCondition(string begintime,string endtime, string EntName,int type, int EntId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select r from DJ_GroupConsumRecord r where 1=1");
            sql.Append(" and r.Enterprise.Name like '%" + EntName + "%'");
            sql.Append(" and r.Route.DJ_TourGroup.DJ_DijiesheInfo.Id=" + EntId + "");
            if (begintime != "")
            {
                sql.Append(" and r.ConsumeTime>= '" + begintime + "'");
            }
            if (endtime != "")
            {
                sql.Append(" and r.ConsumeTime<'" + endtime + "'");
            }
            if (type != 0)
                sql.Append(" and r.Enterprise.Type=" + type + "");
            sql.Append(" order by ConsumeTime desc");
            IQuery query = session.CreateQuery(sql.ToString());
            List<Model.DJ_GroupConsumRecord> ListRecord = new List<Model.DJ_GroupConsumRecord>();
            ListRecord = query.Future<Model.DJ_GroupConsumRecord>().ToList<Model.DJ_GroupConsumRecord>();
            //if(dateyear!="")
            //     ListRecord = query.Future<Model.DJ_GroupConsumRecord>().Where(x => x.ConsumeTime.Year == DateTime.Parse(dateyear).Year).ToList();
            //else
            //    ListRecord = query.Future<Model.DJ_GroupConsumRecord>().Where(x => x.ConsumeTime.Year == DateTime.Now.Year).ToList();
            return ListRecord;
        }


        public IList<Model.DJ_GroupConsumRecord> GetByDate(int year, int month, int entid, int djsid, bool? IsVerified_City, bool? IsVerified_Country)
        {
            string sql = "select r from DJ_GroupConsumRecord r where r.Enterprise.Id=" + entid + " and r.Route.DJ_TourGroup.DJ_DijiesheInfo.Id=" + djsid + "";
            sql += " and ConsumeTime>='" + year.ToString() + "-" + month.ToString() + "-01 00:00:00" + "' and  ConsumeTime<'" +DateTime.Parse(year+"-"+month+"-"+"1").AddMonths(1) + "'";
            IQuery query = session.CreateQuery(sql);
            List<DJ_GroupConsumRecord> ListRecord = query.Future<Model.DJ_GroupConsumRecord>().ToList<Model.DJ_GroupConsumRecord>();
            if (IsVerified_City == true)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CityVeryfyState == RewardType.已纳入).ToList();
            }
            if (IsVerified_City == false)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CityVeryfyState != RewardType.已纳入).ToList();
            }
            if (IsVerified_Country == true)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CountryVeryfyState == RewardType.已纳入).ToList();
            }
            if (IsVerified_Country == false)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CountryVeryfyState != RewardType.已纳入).ToList();
            }
            return ListRecord;
        }


        public IList<Model.DJ_GroupConsumRecord> GetDptRecordByCondition(string begintime, string endtime, string dptname, int entid, bool? IsVerified_City, bool? IsVerified_Country)
        {
            string sql = "select r from DJ_GroupConsumRecord r where 1=1";
            
            sql += " and r.Route.DJ_TourGroup.DJ_DijiesheInfo.Id=" + entid + "";
            if (begintime != "")
            {
                sql += " and r.ConsumeTime>='" + begintime + "'";
                    
            }
            if ( endtime != "")
            {
                sql += " and r.ConsumeTime<'" + endtime + "'";
            }
            IQuery query = session.CreateQuery(sql);
            List<DJ_GroupConsumRecord> ListRecord= query.Future<Model.DJ_GroupConsumRecord>().ToList<Model.DJ_GroupConsumRecord>();
            if (IsVerified_City == true)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CityVeryfyState == RewardType.已纳入).ToList();
            }
            if (IsVerified_City == false)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CityVeryfyState != RewardType.已纳入).ToList();
            }
            if (IsVerified_Country == true)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CountryVeryfyState == RewardType.已纳入).ToList();
            }
            if (IsVerified_Country == false)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CountryVeryfyState != RewardType.已纳入).ToList();
            }
            return ListRecord;
        }


        public IList<Model.DJ_GroupConsumRecord> GetByDate(int year, int month, string code, int djsid, bool? IsVerified_City, bool? IsVerified_Country)
        {
            //string sql = "select r from DJ_GroupConsumRecord r where r.Enterprise.Area.Code like '%"+code+"%' and r.Route.DJ_TourGroup.DJ_DijiesheInfo.Id=" + djsid + "";

            StringBuilder sql = new StringBuilder();
            sql.Append("select r from DJ_GroupConsumRecord r where 1=1 and r.Route.DJ_TourGroup.DJ_DijiesheInfo.Id=" + djsid + "");
            if (code.Substring(2) == "0000")
            {
                sql.Append(" and r.Enterprise.Area.Code like '%" + code.Substring(0,2) + "%'");
            }
            else if (code.Substring(4) == "00")
            {
                sql.Append(" and r.Enterprise.Area.Code like '%" + code.Substring(0, 4) + "%'");
            }
            else
            {
                sql.Append(" and r.Enterprise.Area.Code like '%" + code.Substring(0, 6) + "%'");
            }
            sql.Append(" and ConsumeTime>='" + year.ToString() + "-" + month.ToString() + "-01 00:00:00" + "' and  ConsumeTime<'" + DateTime.Parse(year + "-" + month + "-" + "1").AddMonths(1) + "'");
            IQuery query = session.CreateQuery(sql.ToString());
            List<DJ_GroupConsumRecord> ListRecord = query.Future<Model.DJ_GroupConsumRecord>().ToList<Model.DJ_GroupConsumRecord>();
            if (IsVerified_City == true)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CityVeryfyState == RewardType.已纳入).ToList();
            }
            if (IsVerified_City == false)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CityVeryfyState != RewardType.已纳入).ToList();
            }
            if (IsVerified_Country == true)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CountryVeryfyState == RewardType.已纳入).ToList();
            }
            if (IsVerified_Country == false)
            {
                ListRecord = ListRecord.Where(x => x.Enterprise.CountryVeryfyState != RewardType.已纳入).ToList();
            }
            return ListRecord;
        }

        public IList<DJ_GroupConsumRecord> GetList_DemoRecords(string groupNamePrefix)
        {
            string modelShortName = "gr";
            string conditions = " and gr.Route.DJ_TourGroup.Name like '"+groupNamePrefix+"%'";
            int totalRecord;
            return GetListByConditions(modelShortName, conditions, "", true, 1, 99999, out totalRecord);
        }

        /// <summary>
        /// 针对DJ_GroupConsumRecord的通用查询
        /// </summary>
        /// <param name="modelShortName">该对象在nql里的简称,传空或null则使用默认值"GR"</param>
        /// <param name="where"></param>
        /// <param name="orderField"></param>
        /// <param name="isDesc"></param>
        /// <param name="pageIndex">起始值为1</param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecord"></param>
        /// <returns></returns>
        public IList<DJ_GroupConsumRecord> GetListByConditions(string modelShortName, string conditions, string orderField, bool isDesc, int pageIndex, int pageSize, out int totalRecord)
        {
            totalRecord = 0;
            if (string.IsNullOrEmpty(modelShortName))
            {
                modelShortName = "GR";
            }
            if (string.IsNullOrEmpty(orderField))
            {
                orderField = "ConsumeTime";
            }
            List<DJ_GroupConsumRecord> records = new List<DJ_GroupConsumRecord>();
            string className = "DJ_GroupConsumRecord";
            string whereStr = " where 1=1 " + conditions;
            string orderStr = " order by  " + modelShortName + "." + orderField;
            if (isDesc) orderStr += " desc ";
            string qryString = string.Format("select {0} from {1} as {2} where 1=1 " + whereStr + orderStr, modelShortName, className,modelShortName);
            NHibernate.IQuery qry = session.CreateQuery(qryString);
            records = qry.Future<DJ_GroupConsumRecord>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return records;
        }
    }
}
