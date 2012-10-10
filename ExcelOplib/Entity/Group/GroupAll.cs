using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupAll
    {
        public Entity.GroupBasic gb { get; set; }
        public List<Entity.GroupMember> gmlist { get; set; }
        public List<Entity.GroupRoute> grlist { get; set; }
    }
}
