using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface ITicketAssign
    {
        void SaveOrUpdate(TicketAssign ticketassign);
        TicketAssign GetTicketAssignByID(Guid assignID);
        IList<TicketAssign> GetTicketAssignByUserId(Guid userid);
        IList<TicketAssign> GetTicketAssignByUserId(Guid userid,bool isUsed);
       // TicketAssign GetTicketAssignById(Guid taid);
        IList<TicketAssign> GetIsUsedCountByAsodid(int odid);

        IList<TicketAssign> GetByodid(int odid);
        //验票
        IList<DataTable> GetTicketAssignBynameandidcard(string name, string idcard, Scenic scenic);
        List<TicketAssign> GetIdcardandname(string name, string idcard, Scenic scenic);
        void GetTicketInfoByIdCard(string idcard, Scenic scenic, out int ydcount, out int usedcount,int type);
        IList<TicketAssign> GetNotUsedTicketAssign(string idcard, Scenic scenic,int type);
        TicketAssign GetLasetRecordByidcard(string idcard, Scenic scenic,int type);
        void GetOlTicketInfoByIdcard(string idcard, Scenic scenic, out int olcount, out int usedolcount, int type);
        IList<TicketAssign> Getolnotusedticketassign(string idcard, Scenic scenic, int type);
        List<TicketAssign> GetUsedRecord(string idcard);
        int GetUsedCount(string idcard, DateTime dt);
        int GetUnusedCount(string idcard);
        int GetDdCount(string idcard);

        List<TicketAssign> GetYwCount(string idcard);
        IList<TicketAssign> GetTaByIdCard(string idcard);
        IList<TicketAssign> GetTaByIdcardandscenic(string idcard, Scenic scenic);
    }
}
