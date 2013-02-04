using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLOrderDetail:BLLBase<OrderDetail>
    {
        DAL.DALOrderDetail IOrderDetail = new DAL.DALOrderDetail();

        public int SaveOrUpdateOrderDetail(OrderDetail orderdetail)
        {
            return IOrderDetail.SaveOrUpdateOrderDetail(orderdetail);
        }

        public OrderDetail GetOrderDetailByodid(int odid)
        {
            return IOrderDetail.GetOrderDetailByodid(odid);
        }

        public IList<OrderDetail> GetOrderDetailByorderid(int orderid)
        {
            return IOrderDetail.GetOrderDetailByorderid(orderid);
        }
        public void saveorupdate(OrderDetail od)
        {
            IOrderDetail.saveorupdate(od);
        }

        // 为一张门票创建订单详情,为套票递归
        public OrderDetail CreateDetail(Ticket t, PriceType priceType, string name, string idcardno, int amount, string remark)
        {

            //1为此门票创建订单,如果是套票 则需要创建子detail
            OrderDetail detail = new OrderDetail(amount, t.GetTicketPrice(priceType), remark);
            detail.TicketAssignList.Add(new TicketAssign(name, idcardno, detail,amount));
            if (t.As<Ticket>() is TicketUnion)
            {
                foreach (Ticket childt in ((TicketUnion)t).TicketList)
                {
                    OrderDetail childDetail = CreateDetail(childt, priceType, name, idcardno, amount, remark);
                    detail.ChildTicketDetail.Add(childDetail);
                }

            }
            return detail;

        }

        public IList<OrderDetail> GetOrderDetailForIdcard(string activityCode, string idcardNo)
        { 
          return   IOrderDetail.GetOrderDetailForIdcardInActivity( activityCode, idcardNo);
        }
    }
}
