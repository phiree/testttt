using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALUserVoteAmount : DalBase, IDAL.IUserVoteAmount
    {
        /// <summary>
        /// 用户：增加投票
        /// </summary>
        /// <param name="earnAmount"></param>
        public void EarnVote(Model.UserVoteAmount earnAmount)
        {
            session.Save(earnAmount);
        }
        /// <summary>
        /// 用户：获得投票总数
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public long GetTotalAmount(Guid memberid)
        {
            string query = "select sum(uva.Amount) from UserVoteAmount uva where uva.User.Id=:memberid";
           IQuery qry=session.CreateQuery(query)
               .SetParameter("memberid", memberid);
            IFutureValue<object> ifv=qry.FutureValue<object>();
            if (ifv.Value == null) return 0;
            else return (long)ifv.Value;
        }
        /// <summary>
        /// 用户: 获得投票机会的来源
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public IList<Model.UserVoteAmount> GetVoteSource(Guid memberid, int pageIndex, int pageSize, out int totalRecord)
        {
            int page0Index = pageIndex - 1;
            string strQuery = "select uva from UserVoteAmount uva where uva.User.Id=:memberid";
            string strQueryTotal = "select count(*) from UserVoteAmount uva where uva.User.Id=:memberid";
            IQuery query = session.CreateQuery(strQuery)
                .SetParameter("memberid", memberid);
            IQuery queryTotal = session.CreateQuery(strQueryTotal)
                .SetParameter("memberid", memberid);
            var result = query.Future<Model.UserVoteAmount>().Skip(page0Index * pageSize).Take(pageSize).ToList<Model.UserVoteAmount>();
            totalRecord = 0;
            IFutureValue<object> ifv=queryTotal.FutureValue<object>();
            if (ifv.Value != null) totalRecord = int.Parse(ifv.Value.ToString());
            return result;
        }
    }
    public class DALEarnWayAmount : DalBase, IDAL.IEarnWayAmount
    {
        public void SaveUpdate(Model.EarnWayAmount earnwayAmount)
        {
            session.SaveOrUpdate(earnwayAmount);
        }
        public IList<Model.EarnWayAmount> GetList()
        {
          return  session.QueryOver<Model.EarnWayAmount>().List();
        }

        public IList<Model.EarnWayAmount> GetAmountByWay(Model.EarnWay way)
        {
            string strQuery = "select ewa from EarnWayAmount ewa where ewa.EarnWay=" + (int)way;
            return session.CreateQuery(strQuery).Future<Model.EarnWayAmount>().ToList();
        }
    }
}
