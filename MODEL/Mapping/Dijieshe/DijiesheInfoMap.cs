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
    public class DJ_DijiesheInfoMap : SubclassMap<DJ_DijiesheInfo>
    {
        public DJ_DijiesheInfoMap()
        {
            HasMany<DJ_TourGroup>(x => x.Groups);
        }
    }
}
