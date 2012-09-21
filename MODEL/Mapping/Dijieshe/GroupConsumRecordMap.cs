using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model
{
    /// <summary>
    /// 团队消费信息,刷卡记录
    /// </summary>
    public class GroupConsumRecordMap:ClassMap<DJ_GroupConsumRecord>
    {
        public GroupConsumRecordMap()
        {
            Id(x => x.Id);
            References<DJ_TourEnterprise>(x => x.Enterprise);
            References<DJ_TourGroup>(x => x.Group);
            Map(x => x.ConsumeTime);
            Map(x => x.AdultsAmount);
            Map(x => x.ChildrenAmount);
        }
    }
}
