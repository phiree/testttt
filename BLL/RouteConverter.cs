using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace BLL
{
    /// <summary>
    /// 将routelist转换为ui使用的格式
    /// </summary>
    public class RouteConverter
    {

        public static List<UIRoute> ConvertToUI(DJ_TourGroup Group)
        {
            IList<DJ_Route> routes = Group.Routes;
            List<UIRoute> uiRoutes = new List<UIRoute>();
           // if (routes.Count == 0) { return uiRoutes; }
            int totalDays = Group.DaysAmount;
            for (int i = 1; i <= totalDays; i++)
            {
                List<DJ_TourEnterprise> scenics = new List<DJ_TourEnterprise>();
                List<DJ_TourEnterprise> hotels = new List<DJ_TourEnterprise>();
                UIRoute uiroute = new UIRoute();
                IList<DJ_Route> dayRoutes = routes.Where(x => x.DayNo == i).ToList<DJ_Route>();
                foreach (DJ_Route dayroute in dayRoutes)
                {
                    DJ_TourEnterprise ent = dayroute.Enterprise;
                    EnterpriseType type = dayroute.Enterprise.Type;
                    string entName = dayroute.Enterprise.Name;
                    switch (type)
                    {
                        case EnterpriseType.景点:
                            scenics.Add(ent);
                            break;
                        case EnterpriseType.宾馆:
                            hotels.Add(ent);
                            break;
                    }

                }
                uiroute.DayNo = i;
                uiroute.Hotels = hotels;
                uiroute.Scenics = scenics;
                uiRoutes.Add(uiroute);
            }
            return uiRoutes;
        }

        public static List<DJ_Route> ConvertToModel(DJ_TourGroup group, IList<UIRoute> uiRoutes, out string errMsg)
        {
            errMsg = string.Empty;
            BLLDJEnterprise bllEnt = new BLLDJEnterprise();
            List<DJ_Route> routes = new List<DJ_Route>();

            foreach (UIRoute uiroute in uiRoutes)
            {
                int dayNo = uiroute.DayNo;
                IList<DJ_TourEnterprise> scenics = uiroute.Scenics;
                IList<DJ_TourEnterprise> hotels = uiroute.Hotels;

                IList<DJ_TourEnterprise> enterprises = scenics.Concat(hotels).ToList();
                foreach (DJ_TourEnterprise ent in enterprises)
                {
                 
                    DJ_Route route = new DJ_Route();
                    route.Enterprise = ent;
                    route.DayNo = dayNo;
                    route.DJ_TourGroup = group;
                    routes.Add(route);
                }
            }
            return routes;
        }
    }

    public class UIRoute
    {
        public int DayNo { get; set; }
        public IList<DJ_TourEnterprise> Scenics { get; set; }
        public IList<DJ_TourEnterprise> Hotels { get; set; }
    }
}
