using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class UserMap : SubclassMap<User>
    {
        public UserMap()
        {
            //Id(x =>x.ID);
            Map(x => x.RealName);
            Map(x => x.Phone);
            Map(x => x.Address);
            Map(x => x.IdCard);
            //References<Membership>(x => x.Membership);
        }
    }
}
