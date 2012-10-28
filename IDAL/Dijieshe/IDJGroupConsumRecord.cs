using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IDJGroupConsumRecord
    {
        void Save(DJ_GroupConsumRecord group);
        DJ_GroupConsumRecord GetGroupConsumRecordByRouteId(Guid RouteId);
        DJ_GroupConsumRecord GetGcr8Name(string EnterpName,string Groupid);
        IList<DJ_TourGroup> GetFeRecordByETId(int etid);
        List<Model.DJ_GroupConsumRecord> GetRecordByAllCondition(string groupname, string EntName, string BeginTime, string EndTime, int enterid);
        IList<Model.DJ_GroupConsumRecord> GetGCR8Multi(string areacode, string enterpname, string groupid, string routeid, string djsname);
        IList<DJ_GroupConsumRecord> GetRecordByCondition(string dateyear, string EntName,int type, int EntId);
        IList<DJ_GroupConsumRecord> GetByDate(int year, int month, int entid,int djsid);
        IList<DJ_GroupConsumRecord> GetByDate(int year, int month, string code, int djsid);
        IList<DJ_GroupConsumRecord> GetDptRecordByCondition(string begintime, string endtime, string dptname,int entid);
    }
}
