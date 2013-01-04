using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
    /// <summary>
    /// 地接社信息
    /// </summary>
    public class DJ_GovManageDepartmentMap:ClassMap<DJ_GovManageDepartment>
    {

        public DJ_GovManageDepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References<Area>(x => x.Area);
            Map(x => x.Phone);
            Map(x => x.Address);
            Map(x => x.seoname);
            Map(x => x.ChargeName);
            Map(x => x.ChargeTel);
            Map(x => x.ChargeEmail);
      }
    }
}
