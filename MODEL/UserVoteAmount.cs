using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户的选票总数.
    /// 通过各种方式挣得的选票
    /// 
    /// </summary>
    public class UserVoteAmount
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// 获得选票的途径:
        /// </summary>
        public virtual EarnWay EarnWay { get; set; }
        public virtual int Amount { get; set; }
        public virtual DateTime EarnDate { get; set; }



    }
    public enum EarnWay
    {
        PromoteLink //推广链接
        ,
        BuyTicket//网上买票
            ,
        BuyPostCard//购买纸质明信片
            ,
        BuyDigitalCard//购买电子明信片
            , Visited//刷卡游玩过的.
    }
    /// <summary>
    /// 每种方式增加的票数.
    /// </summary>
    public class EarnWayAmount
    {
        public virtual int Id { get; set; }
        public virtual EarnWay EarnWay { get; set; }
        public virtual int Amount { get; set; }
    }

}


