using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;

namespace BLL
{
    public class BLLArea
    {
        IArea iarea;

        public IArea Iarea
        {
            get
            {
                if (iarea == null)
                {
                    iarea = new DALArea();
                }
                return iarea;
            }
            set { iarea = value; }
        }



        public IList<Model.Area> GetArea(int areaid)
        {
            return Iarea.GetArea(areaid);
        }

        public IList<Model.Area> GetSubArea(string areacode)
        {
            return Iarea.GetSubArea(areacode);
        }

        public Model.Area GetAreaByAreaid(int areaid)
        {
            return Iarea.GetAreaByAreaid(areaid);
        }

        public Model.Area GetAraByAreaname(string areaname)
        {
            return Iarea.GetAreaByAreaname(areaname);
        }

        public Model.Area GetAreaBySeoName(string seoName)
        {
            return Iarea.GetAreaBySeoName(seoName);
        }
    }
}
