using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model
{
    /// <summary>
    /// 旅游企业信息/饭店,宾馆,景点,购物点
    /// </summary>
   public class TourEnterpriseMap:ClassMap<DJ_TourEnterprise>
    {
       public TourEnterpriseMap()
       {
           Id(x => x.Id);
           Map(x => x.Name);
           Map(x => x.Type).CustomType<int>();
       }
       public virtual Guid Id { get; set; }
       public virtual string Name { get; set; }
       public virtual EnterpriseType Type { get; set; }
    }
   
}
