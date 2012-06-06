using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALVote : DalBase, IDAL.IVote
    {
        public void SaveVote(Model.Vote vote)
        {
            session.Save(vote);
        }


        public bool IsVoted(string idcard)
        {
            IQuery query = session.CreateQuery("select v from Vote v where IdCard='" + idcard + "'");
            int i = query.Future<Model.Vote>().Count();
            if (i > 0)
                return true;
            else
                return false;
        }
        public IList<Model.Vote> GetUserVotes(Guid memberId)
        {
            IQuery query = session.CreateQuery("select v from Vote v where TourMembershipId='" + memberId + "'");
            IList<Model.Vote> vote = query.Future<Model.Vote>().ToList();
            return vote;
        }
        public IList<Model.Vote> GetUserVotes(Guid memberId, int pageIndex, int pageSize, out int totalRecord)
        {
            int page0Index = pageIndex - 1;
            string strQuery = "select v from Vote v where TourMembershipId='" + memberId + "'";
            string strQueryTotal = "select count(*) from Vote v where TourMembershipId='" + memberId + "'";
            IQuery query = session.CreateQuery(strQuery);
            IQuery queryTotal = session.CreateQuery(strQueryTotal);
            List<Model.Vote> voteList = query.Future<Model.Vote>().Skip(page0Index * pageSize).Take(pageSize).ToList<Model.Vote>();
            totalRecord = (int)queryTotal.FutureValue<long>().Value;
            return voteList;
        }
        /// <summary>
        /// 景区：景区获得的总票数
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public long GetScenicVoteAmount(int scenicId)
        {
            return GetScenicVoteAmount(scenicId, false);
        }
        /// <summary>
        /// 景区：景区获得的总票数
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="includeAll">是否包括无效</param>
        /// <returns></returns>
        public long GetScenicVoteAmount(int scenicId, bool includeAll)
        {
            string strQuery = "select count(v.Num) from Vote v where v.Scenic.Id=" + scenicId;
            if (!includeAll)
            {
                strQuery += " and v.IsEffect=" + includeAll;
            }
            IQuery query = session.CreateQuery(strQuery);
            IFutureValue<long> futureamount = query.FutureValue<long>();
            if (futureamount != null)
                return futureamount.Value;
            else
                return 0;
        }

        public int GetScenicVoteRank(string areacode,int scenicid)
        {
            IList<Model.VoteRank> ranklist = GetScenicsByVote(areacode);
            Model.VoteRank voteResult = ranklist.FirstOrDefault<Model.VoteRank>(x => x.ScenicId == scenicid.ToString());
            if (null == voteResult)
                return 0;
            else
                return voteResult.Rank;
        }

        /// <summary>
        /// 景区: 根据地区获得voterank
        /// </summary>
        /// <param name="area_code"></param>
        /// <returns></returns>
        public IList<Model.VoteRank> GetScenicsByVote(string area_code)
        {
            return GetScenicsByVote(area_code, null);
        }

        /// <summary>
        /// 景区: 根据地区和景区名次获得voterank
        /// </summary>
        /// <param name="area_code">地区编码</param>
        /// <param name="scenic_name">景区名称</param>
        /// <returns></returns>
        public IList<Model.VoteRank> GetScenicsByVote(string area_code, string scenic_name)
        {
            area_code = area_code.Substring(0, 2) + "__00";
            string strQuery = "select v.Scenic.Id,v.Scenic.Name,sum(v.Num),v.Scenic.Photo,v.Scenic.Desec from Vote v where ";
            if (!string.IsNullOrWhiteSpace(area_code))
            {
                strQuery += " v.Scenic.Area.Code like '" + area_code+"'";
                if (!string.IsNullOrWhiteSpace(scenic_name))
                {
                    strQuery += " and v.Scenic.Name='" + scenic_name + "'";
                }
            }
            else if(!string.IsNullOrWhiteSpace(scenic_name))
            {
                strQuery += " v.Scenic.Name='" + scenic_name + "'";
            }
            strQuery += " group by v.Scenic.Name,v.Scenic.Id,v.Scenic.Photo,v.Scenic.Desec order by sum(v.Num) desc";
            var query = session.CreateQuery(strQuery).List<object[]>().Take(20);
            if (query.Count() ==0) return null;
            IList<Model.VoteRank> result=new List<Model.VoteRank>();
            int ranknum = 1;
            foreach (var item in query)
            {
                result.Add(new Model.VoteRank() {
                    ScenicId=item[0].ToString(),
                    ScenicName = item[1].ToString(),
                    Rank = ranknum++,
                    Num = int.Parse(item[2].ToString()),
                    Photo = item[3] == null ? "" : item[3].ToString(),
                    Description = item[4]==null?"暂无介绍":item[4].ToString()
                });
            }
            return result;
        }
        
#region 用户相关

        /// <summary>
        /// 用户: 获得用户的投票信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        
        /// <summary>
        /// 用户：投出的总票数
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public long GetVotedAmount(Guid memberid)
        {
            string query = "select sum(v.Num) from Vote v where v.TourMembershipId='" + memberid.ToString() + "'";
            IQuery qry = session.CreateQuery(query);
            //如果没有相关的v.num数据,查询返回结果为null,不能直接转换为long
            var result = qry.UniqueResult();
            long votedAmount = 0;
            if (result != null)
            {
                votedAmount = (long)result;
            }
            return votedAmount;
        }
	#endregion
    }
}
