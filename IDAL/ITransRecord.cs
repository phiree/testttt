using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
   public interface ITransRecord
    {
       IList<Model.Order> GetListForUser(Guid memberId);
       int SaveTrans(Order trans);
       Model.Order BuyTicketByTransID(int transid);
       IList<Model.Order> GetListByscidandcardid(int scid, string cardid);
       void UpdateTrans(Order trans);
       IList<Model.Order> GetListByscid(int scid);
       void SelectInfo(int scid, DateTime pretime, DateTime nexttime, decimal price, out int ticketcount, out decimal sumprice);
    }
}
