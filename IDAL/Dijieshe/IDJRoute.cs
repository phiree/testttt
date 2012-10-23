using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
    public interface IDJRoute
    {
        DJ_Route GetById(Guid routeId);
        void SaveOrUpdate(DJ_Route route);
        void Delete(DJ_Route route);
        IList<DJ_Route> GetRouteByentid(int entid);
        //预报时间
        IList<Model.DJ_Product> GetPdByTimeandTEId(DateTime time, int teid);
        //根据其他旅游单位id，选择行程
        IList<Model.DJ_Route> GetRouteByTEid(int teid);
        //选择还没有结束的团队
        IList<Model.DJ_TourGroup> GetNotendGroup();
        //通过DayNo和groupid
        IList<Model.DJ_Route> GetRouteByDayNoandGroupid(int dayno, Guid groupid,int entid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname">团队名称</param>
        /// <param name="EntName">团队所在旅行社名称</param>
        /// <param name="BeginTime">起始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="enterid">验票企业id</param>
        /// <returns></returns>
        IList<Model.DJ_Route> GetRouteByAllCondition(string groupname, string EntName, string BeginTime, string EndTime,int enterid);
    }
  
}
