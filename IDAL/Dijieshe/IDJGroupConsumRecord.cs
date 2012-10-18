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
    }
}
