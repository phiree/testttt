using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;

namespace BLL
{
    public class BLLArea:DalBase<Model.Area>
    {
        DALArea iarea;

        public DALArea DalArea
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
            return DalArea.GetArea(areaid);
        }

        public IList<Model.Area> GetSubArea(string areacode)
        {
            return DalArea.GetSubArea(areacode);
        }

        public Model.Area GetAreaByAreaid(int areaid)
        {
            return DalArea.GetAreaByAreaid(areaid);
        }

        public Model.Area GetAraByAreaname(string areaname)
        {
            return DalArea.GetAreaByAreaname(areaname);
        }

        public Model.Area GetAreaBySeoName(string seoName)
        {
            return DalArea.GetAreaBySeoName(seoName);
        }
        public Model.Area GetAreaByCode(string code)
        {
            return DalArea.GetAreaByCode(code);
        }
        /// <summary>
        /// 获取辖区范围内行政区域的areaid, 用逗号连接,用于 sql的 In 查询
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public string  GetChildAreaIds(string areacode)
        {
            return DalArea.GetSubAreaIds(areacode);

            
            
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
