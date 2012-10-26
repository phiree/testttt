using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;

namespace BLL
{
    public class BLLArea:DalBase
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
        public Model.Area GetAreaByCode(string code)
        {
            return Iarea.GetAreaByCode(code);
        }
        /// <summary>
        /// 获取辖区范围内行政区域的areaid, 用逗号连接,用于 sql的 In 查询
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public string  GetChildAreaIds(string areacode)
        {
            string ids = string.Empty;
            Model.Area currentArea = GetAreaByCode(areacode);
            if (currentArea == null)
            {
                return ids;
            }
            ids += currentArea.Id + ",";
            IList<Model.Area> Areas = GetSubArea(areacode);
            if (Areas == null) {
                ids += areacode;
                return ids;
            }
            foreach (Model.Area a in Areas)
            {
                ids += a.Id + ",";
            }
            ids = ids.TrimEnd(',');
            return ids;

            
            
        }
        public Model.Area ParseArea(string  cityname)
        {
            Model.Area area = new Model.Area();
            if (!cityname.EndsWith("市"))
            {
                cityname += "市";
            }



            return area;
        }
    }
}
