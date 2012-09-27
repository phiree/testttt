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
    public class DJ_GroupConsumRecordMap:ClassMap<DJ_GroupConsumRecord>
    {
        public DJ_GroupConsumRecordMap()
        {
            Id(x => x.Id);
            References<DJ_TourEnterprise>(x => x.Enterprise);
            References<DJ_Route>(x => x.Route);
            Map(x => x.ConsumeTime);
            Map(x => x.AdultsAmount);
            Map(x => x.ChildrenAmount);
        }
    }
}
