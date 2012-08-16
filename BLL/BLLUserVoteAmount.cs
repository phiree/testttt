using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLUserVoteAmount : BLLDefault
    {
        IDAL.IUserVoteAmount dalvote = new DAL.DALUserVoteAmount();
        IDAL.IEarnWayAmount dalearnway = new DAL.DALEarnWayAmount();
       
        /// <summary>
        /// 获得选票
        /// </summary>
        public void EarnVote(Model.TourMembership user, Model.EarnWay way)
        {
            UserVoteAmount uva = new UserVoteAmount()
            {
                User = user,
                Amount = dalearnway.GetAmountByWay(way)[0].Amount,
                EarnWay = way,
                EarnDate = DateTime.Now
            };
            dalvote.EarnVote(uva);
        }

        public IList<Model.UserVoteAmount> GetVoteSource(Guid memberid, int pageIndex, int pageSize, out int totalRecord)
        {
            return dalvote.GetVoteSource(memberid,pageIndex,pageSize,out totalRecord);
        }
    }
    public class BLLEarnWayAmount
    {
        IDAL.IEarnWayAmount dal = new DAL.DALEarnWayAmount();
       
        public void Save(EarnWayAmount earnwayamount)
        {
            dal.SaveUpdate(earnwayamount);
        }
        public IList<EarnWayAmount> GetList()
        {
            return dal.GetList();
        }
    }
}
