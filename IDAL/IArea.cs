using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IArea
    {
        IList<Model.Area> GetArea(int areaid);
        IList<Model.Area> GetAreaProvince();
        IList<Model.Area> GetSubArea(string areacode);
        Model.Area GetAreaByAreaid(int areaid);
        Model.Area GetAreaByAreaname(string areaname);
        Model.Area GetAreaBySeoName(string seoName);
    }
}
