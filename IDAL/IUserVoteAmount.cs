using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IUserVoteAmount
    {
        /// <summary>
        /// 用户：增加投票
        /// </summary>
        /// <param name="earnAmount"></param>
        void EarnVote(Model.UserVoteAmount earnAmount);
        /// <summary>
        /// 用户：获得投票总数
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        long GetTotalAmount(Guid memberid);
        /// <summary>
        /// 用户: 获得投票机会的来源
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        IList<Model.UserVoteAmount> GetVoteSource(Guid memberid, int pageIndex, int pageSize, out int totalRecord);
    }
    public interface IEarnWayAmount
    {
        void SaveUpdate(Model.EarnWayAmount earnwayamount);

        IList<Model.EarnWayAmount> GetList();

        IList<Model.EarnWayAmount> GetAmountByWay(Model.EarnWay way);
    }
}
