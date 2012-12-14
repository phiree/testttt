using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队消费信息,刷卡记录
    /// </summary>
    public class DJ_GroupConsumRecord
    {
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 在哪里消费
        /// </summary>
        public virtual DJ_TourEnterprise Enterprise { get; set; }
        /// <summary>
        /// 在此消费的团队中的某条行程
        /// </summary>
        public virtual DJ_Route Route { get; set; }

        public virtual DateTime ConsumeTime { get; set; }
        
        public virtual int AdultsAmount { get; set; }
        public virtual int ChildrenAmount { get; set; }
        //备注
        public virtual string Remarks { get; set; }
        //编号
        public virtual string No { get; set; }
        //如果是住宿的，需要的居住天数
        public virtual int LiveDay { get; set; }
        //如果是住宿的，需要的房间数
        public virtual int RoomNum { get; set; }
        ////如果是住宿的，房间详情
        //public virtual string RoomDetailInfo { get; set; }
        //如果是住宿的，需要的加床数，可以不填
        public virtual int AppendBed { get; set; }
    }
}
