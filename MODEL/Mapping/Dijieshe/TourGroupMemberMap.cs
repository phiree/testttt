using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model
{
    //组员
    public class DJ_TourGroupMemberMap:ClassMap<DJ_TourGroupMember>
    {
        public DJ_TourGroupMemberMap()
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
