using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace BLL
{
    public class BLLTicketAssign
    {
        IDAL.ITicketAssign Iticketassign = new DAL.DALTicketAssign();

        public void SaveOrUpdate(TicketAssign ticketassign)
        {
            Iticketassign.SaveOrUpdate(ticketassign);
        }

        public TicketAssign GetTicketAssignById(Guid assignID)
        {
            return Iticketassign.GetTicketAssignByID(assignID);
        }

        public IList<TicketAssign> GetTicketAssignByUserId(Guid userid)
        {
            return Iticketassign.GetTicketAssignByUserId(userid);
        }
        public IList<TicketAssign> GetTicketAssignByUserId(Guid userid,bool isUsed)
        {
            return Iticketassign.GetTicketAssignByUserId(userid, isUsed);
        }
        public IList<TicketAssign> GetIsUsedCountByAsodid(int odid)
        {
            return Iticketassign.GetIsUsedCountByAsodid(odid);
        }
        public IList<TicketAssign> GetByodid(int odid)
        {
            return Iticketassign.GetByodid(odid);
        }
        public IList<DataTable> GetTicketAssignBynameandidcard(string name, string idcard, Scenic scenic)
        {
            return Iticketassign.GetTicketAssignBynameandidcard(name, idcard, scenic);
        }
        public List<TicketAssign> GetIdcardandname(string name, string idcard, Scenic scenic)
        {
            return Iticketassign.GetIdcardandname(name, idcard, scenic);
        }
        public void GetTicketInfoByIdCard(string idcard, Scenic scenic, out int ydcount, out int usedcount,int type)
        {
            Iticketassign.GetTicketInfoByIdCard(idcard, scenic,out ydcount,out usedcount,type);
        }
        public IList<TicketAssign> GetNotUsedTicketAssign(string idcard, Scenic scenic,int type)
        {
            return Iticketassign.GetNotUsedTicketAssign(idcard, scenic,type);
        }
        public TicketAssign GetLasetRecordByidcard(string idcard, Scenic scenic,int type)
        {
            return Iticketassign.GetLasetRecordByidcard(idcard, scenic,type);
        }
        public void GetOlTicketInfoByIdcard(string idcard, Scenic scenic, out int olcount, out int usedolcount, int type)
        {
            Iticketassign.GetOlTicketInfoByIdcard(idcard, scenic, out olcount, out usedolcount, type);
        }
        public IList<TicketAssign> Getolnotusedticketassign(string idcard, Scenic scenic, int type)
        {
            return Iticketassign.Getolnotusedticketassign(idcard, scenic, type);
        }
        public List<TicketAssign> GetUsedRecord(string idcard)
        {
            return Iticketassign.GetUsedRecord(idcard);
        }
        public int GetUsedCount(string idcard, DateTime dt)
        {
            return Iticketassign.GetUsedCount(idcard, dt);
        }

        public int GetUsedCount(string idcard)
        {
            return Iticketassign.GetUsedCount(idcard);
        }
        public int GetDdCount(string idcard)
        {
            return Iticketassign.GetDdCount(idcard);
        }
        public List<TicketAssign> GetYwCount(string idcard)
        {
            return Iticketassign.GetYwCount(idcard);
        }
        public IList<TicketAssign> GetTaByIdCard(string idcard)
        {
            return Iticketassign.GetTaByIdCard(idcard);
        }
    }
}
