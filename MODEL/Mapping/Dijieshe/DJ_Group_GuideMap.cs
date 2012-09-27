using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping.Dijieshe
{
    public class DJ_Group_GuideMap: SubclassMap<DJ_Group_Guide>
    {
        public DJ_Group_GuideMap()
        {
            Map(x => x.GuideNo);
        }
    }
}
