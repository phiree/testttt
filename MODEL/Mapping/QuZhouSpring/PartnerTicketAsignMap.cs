using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
  public  class PartnerTicketAsignMap:ClassMap<PartnerTicketAsign>
    {
      public PartnerTicketAsignMap()
      {
          Id(x => x.Id);
          Map(x => x.AsignedAmount);
          Map(x => x.SoldAmount);
          References<QZSpringPartner>(x => x.Partner);
        
      }
    }
}
