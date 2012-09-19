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
    public class DijiesheInfoMap:ClassMap<DJ_DijiesheInfo>
    {

      public DijiesheInfoMap(){
          Id(x => x.Id);
          References<Area>(x => x.Area);
          Map(x => x.Name);
          Map(x => x.Address);
          Map(x => x.ChargePersonName);
          Map(x => x.ChargePersonPhone);
          
          HasMany<DJ_TourGroup>(x => x.Groups);
          Map(x => x.Phone);

       

      }
    }
}
