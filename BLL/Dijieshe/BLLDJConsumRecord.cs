using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;
using Model;

namespace BLL
{
    public class BLLDJConsumRecord
    {
        IDJGroupConsumRecord IDjgroup = new DALDJ_GroupConsumRecord();

        public void Save(DJ_TourEnterprise Enterprise, DJ_Route route, DateTime consumtime, int AdultsAmount, int ChildrenAmount)
        {
            DJ_GroupConsumRecord dj_group = new DJ_GroupConsumRecord();
            dj_group.AdultsAmount = AdultsAmount;
            dj_group.ChildrenAmount = ChildrenAmount;
            dj_group.ConsumeTime = consumtime;
            dj_group.Enterprise = Enterprise;
            dj_group.Route = route;
            dj_group.No = "Lv" + new Random((int)DateTime.Now.Ticks).Next(100000, 999999);
            if (IDjgroup.GetGroupConsumRecordByRouteId(route.Id)==null)
                IDjgroup.Save(dj_group);
        }

        public Model.DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(Guid RouteId)
        {
            return IDjgroup.GetGroupConsumRecordByRouteId(RouteId);
        }

        public Model.DJ_GroupConsumRecord GetGCR8Name(string EnterpName,string groupid)
        {
            return IDjgroup.GetGcr8Name(EnterpName,groupid);
        }

        public IList<Model.DJ_TourGroup> GetFeRecordByETId(int etid, int day, int pageIndex, int pageSize, out int totalRecord)
        {
            List<Model.DJ_TourGroup> ListTg = IDjgroup.GetFeRecordByETId(etid).ToList();
            totalRecord = ListTg.Where(x => x.BeginDate.AddDays(day) <= DateTime.Now).Count();
            ListTg = ListTg.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return ListTg;
        }

        public void GetCountInfoByETid(int etid,out int groupcount,out int adultcount,out int childrencount)
        {
            List<Model.DJ_TourGroup> ListTg = IDjgroup.GetFeRecordByETId(etid).ToList();
            adultcount = 0;
            childrencount = 0;
            groupcount = ListTg.GroupBy(x => x.Id).Count();
            foreach (DJ_TourGroup group in ListTg)
            {
                adultcount += group.AdultsAmount;
                childrencount += group.ChildrenAmount;
            }
        }
    }
}
