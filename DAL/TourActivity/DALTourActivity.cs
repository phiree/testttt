using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALTourActivity:DalBase<Model.TourActivity>
    {
        /// <summary>
        /// 所有常规查询都综合到一个综合方法内
        /// </summary>
        /// <param name="activitycode"></param>
        /// <returns></returns>
        public Model.TourActivity GetOneCode(string activitycode)
        {
          return  session.QueryOver<Model.TourActivity>().Where(x => x.ActivityCode == activitycode).SingleOrDefault();
        }
    }
}
