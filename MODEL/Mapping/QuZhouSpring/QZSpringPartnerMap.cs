using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
    public class QZSpringPartnerMap : ClassMap<QZSpringPartner>
    {
      public QZSpringPartnerMap()
      {
          Id(x => x.Id);
          Map(x => x.Enable);
          Map(x => x.FriendlyId);
          
          Map(x => x.Name);
          
          Map(x => x.RequestSource);
      }
    }
}
