using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IVote
    {
        void SaveVote(Model.Vote vote);

        bool IsVoted(string idcard);
        /// <summary>
        /// 用户：总票数
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        IList<Model.Vote> GetUserVotes(Guid membershipId);
        IList<Model.Vote> GetUserVotes(Guid memberId, int pageIndex, int pageSize, out int totalRecord);
        long GetScenicVoteAmount(int scenicId, bool includeAll);
        long GetVotedAmount(Guid memberid);
        int GetScenicVoteRank(string areacode, int scenicid);
        IList<Model.VoteRank> GetScenicsByVote(string area_code);
        IList<Model.VoteRank> GetScenicsByVote(string area_code,string scenic_name);
    }
}
