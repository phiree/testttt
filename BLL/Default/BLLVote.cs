using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLVote:BLLDefault
    {
        IDAL.IVote dal = new DAL.DALVote();
        IDAL.IUserVoteAmount dalEarn = new DAL.DALUserVoteAmount();
        public bool isVoted(string idcard)
        {
            return dal.IsVoted(idcard);
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="scenic"></param>
        /// <param name="num"></param>
        /// <param name="votetype"></param>
        /// <param name="time"></param>
        /// <param name="note"></param>
        /// <param name="iseffect"></param>
        public void Vote(Guid memberId, string idcard, Model.Scenic scenic, int num, string votetype, DateTime time,
            string note, bool iseffect)
        {
            long totalAmount = GetUserTotalAmount(memberId);
            long usedAmount = GetUserVotedAmount(memberId);

            if (num + usedAmount > totalAmount)
            {
                throw new Exception("投票数大于剩余票数");
            }

            Model.Vote vote = new Model.Vote()
            {
                IdCard = idcard,
                Scenic = scenic,
                Num = num,
                Type = votetype,
                Time = time,
                Note = note,
                IsEffect = iseffect,
                TourMembershipId=memberId
            };
            dal.SaveVote(vote);

        }
        /// <summary>
        /// 用户的投票列表
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public IList<Model.Vote> GetUserVote(Guid memberId)
        {
            return dal.GetUserVotes(memberId);
        }

        public IList<Model.Vote> GetUserVote(Guid memberId, int pageIndex, int pageSize, out int totalRecord)
        {
            return dal.GetUserVotes(memberId, pageIndex, pageSize,out totalRecord);
        }
        /// <summary>
        /// 用户总的投票数.
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public long GetUserVotedAmount(Guid memberid)
        {
            return dal.GetVotedAmount(memberid);
        }
        /// <summary>
        /// 用户拥有的总票数
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public long GetUserTotalAmount(Guid memberId)
        {
            return dalEarn.GetTotalAmount(memberId);
        }
        /// <summary>
        /// 获取景区的投票数
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public long GetVoteAmount(int scenicId)
        {
            return dal.GetScenicVoteAmount(scenicId, false);
        }
        public int GetScenicVoteRank(string areacode, int scenicid)
        {
            return dal.GetScenicVoteRank(areacode, scenicid);
        }
        /// <summary>
        /// 通过地区获得景区投票排行
        /// </summary>
        /// <param name="areacode">浙江地区是:330000:</param>
        /// <returns></returns>
        public IList<Model.VoteRank> GetScenicsByVote(string areacode)
        {
            return dal.GetScenicsByVote(areacode);
        }
    }
}
