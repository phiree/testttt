
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Model.Mapping
{
    public class ScenicMap : SubclassMap<Scenic>
    {
        public ScenicMap()
        {
           
            Map(x => x.IsHide);
            Map(x => x.Name);
            Map(x => x.Address);
            Map(x => x.ScenicOrder);
            Map(x => x.MipangId);
            Map(x => x.Level);
            Map(x => x.Photo);
            //Map(x => x.ActiveTime);
            Map(x => x.Trafficintro).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.ScenicDetail).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.Desec);
            Map(x => x.Position);
            Map(x => x.SeoName);
            Map(x => x.BookNote).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.TransGuid);
            References<Area>(x => x.Area);
            HasMany<ScenicCheckProgress>(x => x.CheckProgress);
            HasMany<Ticket>(x => x.Tickets);
        }
    }
    public class ScenicCheckProgressMap : ClassMap<ScenicCheckProgress>
    {
        public ScenicCheckProgressMap()
        {
            Id(x => x.Id);
            References<TourMembership>(x => x.Applier);
            References<TourMembership>(x => x.Checker);
            Map(x => x.CheckMessage);
            Map(x => x.CheckStatus).CustomType<int>();
            Map(x => x.CheckTime);
            Map(x => x.Module).CustomType<int>();
            References<Scenic>(x => x.Scenic);
        }
    }
    public class ScenicImgMap : ClassMap<ScenicImg>
    {
        public ScenicImgMap() {
            Id(x => x.Id);
            References<Scenic>(x => x.Scenic);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.ImgType).CustomType<int>();
            Map(x => x.Name);
        }
    }
}
