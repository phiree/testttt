using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using FluentNHibernate.Mapping;

namespace Model.Mapping.Dijieshe
{
    public class DJ_RecommandMap:ClassMap<DJ_Recommand>
    {
        public DJ_RecommandMap()
        {
            Id(x => x.Id);
            References<DJ_GovManageDepartment>(x => x.DJ_GovManageDepartment);
            Map(x => x.RewardPolicy).CustomSqlType("text");
            Map(x => x.UploadFile);
        }
    }
}
