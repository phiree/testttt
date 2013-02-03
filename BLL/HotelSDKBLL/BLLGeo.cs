using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel.HotelSDKModel;
using HotelModel.HotelDB;

namespace BLL
{
    public class BLLGeo
    {
        DAL.DALHotel DataBaseManager = new DAL.DALHotel();
        /// <summary>
        /// 获得城市Geo信息
        /// </summary>
        /// <returns></returns>
        public List<Geo> GetCityCeo()
        {
            List<Geo> Geos = new List<Geo>();
            List<nbapisdk_Location> DBGeos = DataBaseManager.GetGeos(WebConst.GeoEnum.City.GetHashCode().ToString());
            if (DBGeos != null && DBGeos.Count > 0)
            {
                foreach (nbapisdk_Location geo in DBGeos)
                {
                    Geo webgeo = new Geo();
                    webgeo.ID = geo.locationId;
                    webgeo.Name = geo.name;
                    Geos.Add(webgeo);
                }
            }
            return Geos;
        }

        /// <summary>
        /// 根据城市ID获取商业区信息
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public List<Geo> GetCommercialCeo(string cityid)
        {
            List<Geo> Geos = new List<Geo>();
            List<nbapisdk_Location> DBGeos = DataBaseManager.GetGeos(WebConst.GeoEnum.Commercial.GetHashCode().ToString(), cityid);
            if (DBGeos != null && DBGeos.Count > 0)
            {
                foreach (nbapisdk_Location geo in DBGeos)
                {
                    Geo webgeo = new Geo();
                    webgeo.ID = geo.locationId;
                    webgeo.Name = geo.name;
                    Geos.Add(webgeo);
                }
            }
            return Geos;
        }
    }
}
