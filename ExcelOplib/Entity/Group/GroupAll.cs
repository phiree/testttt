using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelOplib.Entity
{
    public class GroupAll
    {
        #region v.10/22
        //public int DjsId { get; set; }
        //public Entity.GroupBasic GroupBasic { get; set; }
        //public List<Entity.GroupMember> GroupMemberList { get; set; }
        //public List<Entity.GroupRoute> GroupRouteList { get; set; }
        #endregion

        #region v.10/31
        public int DjsId { get; set; }
        public Entity.GroupBasic GroupBasic { get; set; }
        public List<Entity.GroupMember> GroupMemberList { get; set; }
        public List<Entity.GroupRoute> GroupRouteList { get; set; }
        #endregion
    }
}
