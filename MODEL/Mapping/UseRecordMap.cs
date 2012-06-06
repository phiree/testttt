using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class UseRecordMap : ClassMap<UseRecord>
    {
        public UseRecordMap()
        {
            Id(x => x.Id);
            Map(x => x.UsedNum);
            Map(x => x.UsedDate);
            References(x => x.User);
            References<Ticket>(x => x.Ticket);
            //References<TransRecord>(x => x.Order);
        }
    }
}
