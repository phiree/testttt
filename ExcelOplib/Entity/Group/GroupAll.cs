using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupAll
    {
        public Entity.GroupBasic GroupBasic { get; set; }
        public List<Entity.GroupMember> GroupMemberList { get; set; }
        public List<Entity.GroupRoute> GroupRouteList { get; set; }
    }
}
