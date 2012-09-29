using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model
{
    //团队信息
    public class DJ_TourGroupMap:ClassMap<DJ_TourGroup>
    {
        public DJ_TourGroupMap()
        {
            Id(x => x.Id);
            References<DJ_DijiesheInfo>(x => x.DJ_DijiesheInfo);
            Map(x => x.Name);
            Map(x => x.BeginDate);
            Map(x => x.EndDate);
          
            Map(x => x.DaysAmount);
           
            Map(x => x.AdultsAmount);
            Map(x => x.ChildrenAmount);

            HasMany<DJ_TourGroupMember>(x => x.Members);
            HasMany<DJ_Group_Vehicle>(x => x.Vehicles);
            HasMany<DJ_Group_Worker>(x => x.Workers);
            HasMany<DJ_Route>(x => x.Routes);
        }
    }
}
