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


        /// <summary>
        /// 获取省份下的市,
        /// </summary>
        /// <param name="areaid">6位数中的前两位,如浙江的33</param>
        /// <returns>330000,330100,330200------331100</returns>
        public IList<Model.Area> GetArea(int areaid)
        {
            return DalArea.GetArea(areaid);
        }

        /// <summary>
        /// 寻找某个地区的下属地区
        /// </summary>
        /// <param name="areacode">地区编号</param>
        /// <returns>该地区的下属地区</returns>
        public IList<Model.Area> GetSubArea(string areacode)
        {
            if (string.IsNullOrEmpty(areacode) || areacode.Length!=6)
            {
                return null;
            }
            return DalArea.GetSubArea(areacode);
        }
        /// <summary>
        /// 根据areaid获取area
        /// </summary>
        /// <param name="areaid">areaid</param>
        /// <returns>area实体</returns>
        public Model.Area GetAreaByAreaid(int areaid)
        {
            return DalArea.GetAreaByAreaid(areaid);
        }

        /// <summary>
        /// 根据areaname获得area
        /// </summary>
        /// <param name="areaname">area名称</param>
        /// <returns>area实体</returns>
        public Model.Area GetAreaByAreaname(string areaname)
        {
            if (string.IsNullOrEmpty(areaname))
            {
                return null;
            }
            return DalArea.GetAreaByAreaname(areaname);
        }

        /// <summary>
        /// 根据areaname获得area
        /// </summary>
        /// <param name="areaname">area名称</param>
        /// <returns>area实体</returns>
        public Model.Area GetAreaByAreanamelike(string areaname)
        {
            if (string.IsNullOrEmpty(areaname))
            {
                return null;
            }
            return DalArea.GetAreaByAreanamelike(areaname);
        }

        /// <summary>
        /// 根据seoname查询area
        /// </summary>
        /// <param name="seoName">seoname</param>
        /// <returns>area实体</returns>
        public Model.Area GetAreaBySeoName(string seoName)
        {
            return DalArea.GetAreaBySeoName(seoName);
        }

        /// <summary>
        /// 根据code获得area
        /// </summary>
        /// <param name="code">areacode</param>
        /// <returns></returns>
        public Model.Area GetAreaByCode(string code)
        {
            return DalArea.GetAreaByCode(code);
        }

        /// <summary>
        /// 获得所有省份
        /// </summary>
        /// <returns></returns>
        public IList<Model.Area> GetAreaProvince()
        {
            return DalArea.GetAreaProvince();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityname"></param>
        /// <returns></returns>
        //public Model.Area ParseArea(string cityname)
        //{
        //    Model.Area area = new Model.Area();
        //    if (!cityname.EndsWith("市"))
        //    {
        //        cityname += "市";
        //    }
        //    return area;
        //}
    }
}
