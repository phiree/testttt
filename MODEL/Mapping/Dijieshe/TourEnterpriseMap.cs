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
   public class DJ_TourEnterpriseMap:ClassMap<DJ_TourEnterprise>
    {
       public DJ_TourEnterpriseMap()
       {
           Id(x => x.Id);
           References<Area>(x => x.Area).UniqueKey("UniqueNameInSameArea").Not.Nullable();
           Map(x => x.Name).UniqueKey("UniqueNameInSameArea").Not.Nullable();
           Map(x => x.Address).Not.Nullable();
           Map(x => x.ChargePersonName).Nullable();
           Map(x => x.ChargePersonPhone).Nullable();
           Map(x => x.Phone).Nullable();
           //Map(x => x.IsVeryfied);
           Map(x => x.ProvinceVeryfyState).CustomType<int>();
           Map(x => x.CityVeryfyState).CustomType<int>();
           Map(x => x.CountryVeryfyState).CustomType<int>();
           Map(x => x.Type).CustomType<int>().UniqueKey("UniqueNameInSameArea");
           Map(x => x.SeoName);
           Map(x => x.Buslicense).Nullable();
           Map(x => x.Email).Nullable();
           Map(x => x.Fax).Nullable();
           Map(x => x.Url).Nullable();
           Map(x => x.Level);
           Map(x => x.LastUpdateTime);
       }
    }
}
