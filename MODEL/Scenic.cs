using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Model
{
    public class Scenic
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SeoName { get; set; }
        public virtual string Address { get; set; }
        public virtual int ScenicOrder { get; set; }
        public virtual string Level { get; set; }
        public virtual string Photo { get; set; }
      
        //public virtual string ActiveTime { get; set; } 更改结构,删除该字段
        /// <summary>
        /// 交通信息
        /// </summary>
        public virtual string Trafficintro { get; set; }
        public virtual Area Area { get; set; }
        /// <summary>
        /// 景区详情
        /// </summary>
        public virtual string ScenicDetail { get; set; }
        public virtual string Desec { get; set; }
        public virtual string Position { get; set; }
        public virtual string BookNote { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        public virtual string TransGuid { get; set; }
        public virtual IList<ScenicCheckProgress> CheckProgress { get; set; }

        /// <summary>
        /// 已经开启的功能
        /// </summary>
        /// <returns></returns>
        public virtual ScenicModule ActiveModules() {
            ScenicModule module = 0;
            foreach (ScenicCheckProgress progress in CheckProgress)
            {
                if (progress.CheckStatus == CheckStatus.Pass)
                {
                    module = module | progress.Module;
                }
            }
            return module;
        }
    }

    //景区各个功能的审核跟踪
    //只维护一条记录.
    public class ScenicCheckProgress
    {
        public virtual Guid Id { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual ScenicModule Module { get; set; }
        public virtual CheckStatus CheckStatus { get; set; }
        /// <summary>
        /// 审核过程中的消息记录
        /// </summary>
        public virtual string CheckMessage { get; set; }
        /// <summary>
        /// 审核zhe
        /// </summary>
        public virtual TourMembership Checker { get; set; }
        /// <summary>
        /// 提交申请的用户
        /// </summary>
        public virtual TourMembership Applier { get; set; }
        public virtual DateTime CheckTime { get; set; }
    }

    /// <summary>
    /// 上传的图片
    /// </summary>
    public class ScenicCheckImage
    {
        public virtual Guid Id { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual ScenicModule Module { get; set; }
    }

    public enum ScenicModule
    {
        SellOnLine = 1 //网上售票
        ,
        JoinVoting = 2 //参与评选
        , JoinPostCardPromotion = 4 //参与明信片促销
    }
    /// <summary>
    /// 景区资料审核状态
    /// </summary>
    public enum CheckStatus
    { 
       [Description("未申请")]
        NotApplied //尚未提交审核
        ,
        [Description("已申请,等待审核")]
        Applied //已经提交 等待审核
        ,
        [Description("审核通过")]
        Pass//审核通过
        ,
        [Description("审核未通过")]
        NotPass//审核未通过
        ,
        [Description("无数据")]
        None
    }

    //景区图片对应关系
    public class ScenicImg
    {
        public virtual int Id { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual ImgType ImgType { get; set; }
        public virtual string Name { get; set; }
    }

    public enum ImgType
    {
        主图=1,
        辅图=2,
        备图=3
    }

    //投票排名
    public class VoteRank
    {
        public string ScenicId { get; set; }
        public string ScenicName { get; set; }
        public virtual int Rank{get;set;}
        public int Num { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}
