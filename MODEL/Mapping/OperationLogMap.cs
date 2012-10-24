using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class OperationLogMap : ClassMap<OperationLog>
    {
        public OperationLogMap()
        {
            Id(x => x.Id);
            Map(x => x.Content);
            References<TourMembership>(x => x.Member);
            Map(x => x.OperationTime);
            Map(x => x.OprationType).CustomType<int>();
            Map(x => x.TargetId);
        }
    }
   

}
