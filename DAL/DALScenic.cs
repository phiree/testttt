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
            string sql = "select sc from Scenic sc where sc.Area.Code=" + areacode + "";
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
            using (var t = session.Transaction)
            {
                t.Begin();
                session.Update(scenic);
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

        public IList<Ticket> GetScenicByScenicName(string scenicname, string level, int areaid)
        {
            string sqlstr = "";
            if (areaid == 0)
                if (level != "")
                    sqlstr = "select t from Ticket t where t.Scenic.Name like '%" + scenicname + "%' and t.Scenic.Level like '%" + level + "%'";
                else
                {
                    sqlstr = "select t from Ticket t where t.Scenic.Name like '%" + scenicname + "%'";
                }
            else
            {
                if (level != "")
                    sqlstr = "select t from Ticket t where t.Scenic.Name like '%" + scenicname + "%' and t.Scenic.Level like '%" + level + "%' and t.Scenic.Area.Id=" + areaid + "";
                else
                {
                    sqlstr = "select t from Ticket t where t.Scenic.Name like '%" + scenicname + "%' and t.Scenic.Area.Id=" + areaid + "";
                }
            }
            IQuery query = session.CreateQuery(sqlstr);
            return query.Future<Ticket>().ToList<Ticket>();
        }


        public IList<Ticket> GetScenicByScenicPosition(string position)
        {
            string sqlstr = "select t from Ticket t where t.Scenic.Position like '" + position.Split(',')[0] + "%," + position.Split(',')[1] + "%'";
            IQuery query = session.CreateQuery(sqlstr);
            return query.Future<Ticket>().ToList<Ticket>();
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
    }
}
