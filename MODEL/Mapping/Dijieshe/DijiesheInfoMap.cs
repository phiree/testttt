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
    public class DijiesheInfoMap : SubclassMap<DJ_DijiesheInfo>
    {
        public DijiesheInfoMap()
        {
            HasMany<DJ_TourGroup>(x => x.Groups);
        }
    }
}
