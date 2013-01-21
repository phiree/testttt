using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model.Mapping
{
  public  class QZTicketAsignMap:ClassMap<QZTicketAsign>
    {
      public QZTicketAsignMap()
      {
          Id(x => x.Id);
          Map(x => x.ProductCode);
          //Map(x => x.SoldAmount);
          References<Ticket>(x => x.Ticket);
          Map(x => x.Date);
          HasMany<QZPartnerTicketAsign>(x => x.PartnerTicketAsign).Cascade.All();
          Map(x => x.Amount);
      }
    }
}
