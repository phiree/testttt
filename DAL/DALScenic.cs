using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALScenic : DalBase, IDAL.IScenic
    {
        public IList<Scenic> GetScenic()
        {
            string sql = "select sc from Scenic sc";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Scenic>().ToList<Scenic>();
        }

        public Scenic GetScenicBySeoName(string seoName)
        {
            string sql = "select sc from Scenic sc where sc.SeoName='" + seoName + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Scenic>().Value;
        }

        /// <summary>
        /// 通过景区ID获取景区详情
        /// </summary>
        /// <param name="scid"></param>
        /// <returns></returns>
        public Model.Scenic GetScenicById(int scid)
        {
            return session.Get<Scenic>(scid);
        }

        /// <summary>
        /// 通过areacode获取景区详情
        /// </summary>
        /// <param name="areacode"></param>
        /// <returns></returns>
        public IList<Scenic> GetScenicByAreacode(string areacode)
        {
            string sql = "select sc from Scenic sc where sc.Area.Code like '" + areacode.Substring(0,4) + "__'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Scenic>().ToList<Model.Scenic>();
        }

        public Scenic GetScrnicByUserName(string username)
        {
            string sql = "select sc from Scenic sc where sc.TourMembership.Name='" + username + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Scenic>().ToList<Scenic>()[0];
        }

        public void UpdateScenicInfo(Scenic scenic)
        {
            using (var t = session.BeginTransaction())
            {
                foreach (var item in scenic.Tickets)
                {
                    session.SaveOrUpdate(item);
                }
                session.SaveOrUpdate(scenic);
                t.Commit();
            }
        }

        public void UpdateScenicInfo(List<Scenic> slist)
        {
            foreach (Scenic item in slist)
            {
                UpdateScenicInfo(item);
            }
        }

        public IList<Scenic> GetScenicByScenicName(string scenicname, string level, int areaid,string topic)
        {
            string sqlstr = "select s from Scenic s where 1=1 ";
            sqlstr += ConStatement(scenicname, level, areaid);
            if (!string.IsNullOrEmpty(topic))
            {
                IQuery query = session.CreateQuery(sqlstr);
                List<Scenic> List = query.Future<Scenic>().ToList<Scenic>();
                string topicsql = "select st from ScenicTopic st where st.Topic.Name='" + topic + "'";
                query = session.CreateQuery(topicsql);
                List<Model.ScenicTopic> listtopic = query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
                var result = from t in listtopic join l in List on t.Scenic.Id equals l.Id select l;
                return result.ToList<Scenic>();
            }
            else
            {
                IQuery query = session.CreateQuery(sqlstr);
                return query.Future<Scenic>().ToList<Scenic>();
            }
        }

        private string ConStatement(string scenicname, string level, int areaid)
        {
            string sqlstr = "";
            if (!string.IsNullOrEmpty(scenicname))
                sqlstr = " and s.Name like '%" + scenicname + "%'";
            if (areaid != 0)
            {
                string areacode = new DALArea().GetAreaByAreaid(areaid).Code.Substring(0, 4);
                sqlstr += " and s.Area.Code like '" + areacode + "__'";
            }
            else
                sqlstr += " and s.Area.Code like '33____'";
            if (!string.IsNullOrEmpty(level))
                sqlstr += " and s.Level = '" + level + "'";
            return sqlstr;
        }

        public IList<ScenicMap> GetScenicMapByCondition(string scenicname, string level, int areaid, string topic)
        {
            string sqlstr = "select s.Id,s.Name,s.Position,s.SeoName from Scenic s where 1=1 ";
            sqlstr += ConStatement(scenicname, level, areaid);
            IQuery query = session.CreateQuery(sqlstr);
            IList<object[]> List = query.List<object[]>();
            List<ScenicMap> ScenicMapList = new List<ScenicMap>();
            ScenicMap sm;
            foreach (var item in List)
            {
                if (item[2]!=null&&(!string.IsNullOrEmpty(item[2].ToString())) && (item[2].ToString() != "null") && (item[2].ToString() != "undefined"))
                {
                    sm = new ScenicMap();
                    sm.id = int.Parse(item[0].ToString());
                    sm.name = item[1].ToString();
                    sm.position = item[2].ToString();
                    sm.scseoname = item[3].ToString();
                    ScenicMapList.Add(sm);
                }
            }
            if (!string.IsNullOrEmpty(topic))
            {
                string topicsql = "select st from ScenicTopic st where st.Topic.Name='" + topic + "'";
                query = session.CreateQuery(topicsql);
                List<Model.ScenicTopic> listtopic = query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
                var result = from t in listtopic join l in ScenicMapList on t.Scenic.Id equals l.id select l;
                return result.ToList<ScenicMap>();
            }
            else
                return ScenicMapList;
        }



        public IList<Scenic> GetScenicByScenicPosition(string position)
        {
            string sqlstr = "select s from Scenic s where s.Position like '" + position.Split(',')[0] + "%," + position.Split(',')[1] + "%'";
            IQuery query = session.CreateQuery(sqlstr);
            return query.Future<Scenic>().ToList<Scenic>();
        }

        public ScenicCheckProgress GetStatus(int scenicId, ScenicModule module)
        {
            string sql = "select s from ScenicCheckProgress s where s.Scenic.Id=" + scenicId
                + " and s.Module=" + (int)module;
            IQuery query = session.CreateQuery(sql);
            var result = query.Future<Object>();
            if (result.Count() == 0)
            {
                return new ScenicCheckProgress() { CheckStatus = CheckStatus.NotApplied };
            }
            return (ScenicCheckProgress)result.First();
        }

        public IList<ScenicCheckProgress> GetStatus(int scenicId)
        {
            string sql = "select s from ScenicCheckProgress s where s.Scenic.Id=" + scenicId;
            IQuery query = session.CreateQuery(sql);
            var result = query.Future<ScenicCheckProgress>();
            if (result.Count() == 0)
            {
                return new List<ScenicCheckProgress>(1) { 
                    new ScenicCheckProgress(){
                        CheckStatus = CheckStatus.NotApplied
                    }
                };
            }
            return (IList<ScenicCheckProgress>)result;
        }

        public void SaveCheckProgress(ScenicCheckProgress progress)
        {
            session.SaveOrUpdate(progress);
            session.Flush();
        }
        #region Contract

        public void UploadContractImg(ContractImg contractimg)
        {
            session.Flush();
            session.Clear();
            session.SaveOrUpdate(contractimg);
            session.Flush();
        }

        public ContractImg GetContractImg(int scenicid)
        {
            string sql = "select c from ContractImg c where c.Scenic.Id=" + scenicid;
            IQuery query = session.CreateQuery(sql);
            var result = query.Future<ContractImg>().ToList();
            if (result.Count == 0)
                return null;
            else
                return result[0];
        }

        #endregion


        public ScenicCheckProgress GetCheckProgressByscidandmouid(int scid, int module)
        {
            string sql = "select scp from ScenicCheckProgress scp where scp.Scenic.Id=" + scid + " and Module=" + module + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<ScenicCheckProgress>().Value;
        }


        public void UpdateCheckState(ScenicCheckProgress scp)
        {
            using (var x = session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(scp);
                x.Commit();
            }
        }

        #region 景区图片
        public void SaveScenicimg(List<ScenicImg> silist)
        {
            foreach (ScenicImg item in silist)
            {
                session.SaveOrUpdate(item);
            }
        }
        public void DeleteScenicimg()
        {
            string sql = "delete from ScenicImg si";
            IQuery query = session.CreateQuery(sql);
            query.ExecuteUpdate();
        }
        #endregion


        public Scenic GetScenicBySeoName(string aseoname, string sseoname)
        {
            string sql = "select s from Scenic s where s.SeoName='" + sseoname + "' and s.Area.SeoName='" + aseoname + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Scenic>().Value;
        }
    }
}
