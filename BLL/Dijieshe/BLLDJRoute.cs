using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLDJRoute
    {

        IDAL.IDJRoute Idjroute = new DAL.DALDJ_Route();
        /// <summary>
        /// 根据预报时间得到当前的团队
        /// </summary>
        /// <param name="time">预报时间</param>
        /// <param name="teid">企业id</param>
        /// <returns>团队列表</returns>
        public IList<Model.DJ_TourGroup> GetTgByTime(DateTime time, int teid)
        {
            List<Model.DJ_Product> ListProduct = Idjroute.GetPdByTimeandTEId(time, teid).ToList();
            List<Model.DJ_TourGroup> ListTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_Product product in ListProduct)
            {
                Model.DJ_TourGroup group = new BLLDJTourGroup().GetTgByproductid(product.Id);
                if (group != null)
                {
                    ListTg.Add(group);
                }
            }
            return ListTg;
        }

        public Model.DJ_Route GetById(Guid routeId)
        {
            return Idjroute.GetById(routeId);
        }
    }
}
