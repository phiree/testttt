using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IOrder
    {
        IList<Model.Order> GetListForUser(Guid memberId);
        //IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID );
        IList<Model.OrderDetail> GetListForUser(int orderID, int scenicID, bool? isPaid, string dbegin, string dend);
        int SaveOrUpdateOrder(Order order);
        IList<Model.TicketAssign> GetListByscidandcardid(int scenicid, string idcard);
        Order GetOrderByOrderid(int orderid);
        IList<Model.OrderDetail> GetMonthOrder(int scenicid, string dateBegin, string dateEnd, bool? paidstate);
        IList<Model.OrderDetail> GetMonthOrder(int scenicid, string dateBegin, string dateEnd);
        MonthOrder GetPaidstate(string yearmonth, int scenicid,string orderway);
        void AddMonthBill(string date,Model.Scenic scenic, string orderway, int num, decimal price, bool state);
    }
}
