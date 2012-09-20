using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model
{
    //组员
    public class TourGroupMemberMap:ClassMap<DJ_TourGroupMember>
    {
        public TourGroupMemberMap()
        {
            Id(x => x.Id);
            Map(x => x.IdCardNo);
            Map(x => x.IsChild);
            Map(x => x.Keeper);
            Map(x => x.PhoneNum);
            Map(x => x.RealName);
            Map(x => x.Gender);
        }
    }
  
}
