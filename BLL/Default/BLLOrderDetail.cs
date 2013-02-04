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

    public IList<OrderDetail> CreateDetail(Ticket t, PriceType priceType, string name, string idcardno, int amount, string remark)
        {
            IList<OrderDetail> details = new List<OrderDetail>();

            //1为此门票创建订单,如果是套票 则需要创建子detail
            OrderDetail detail = new OrderDetail(amount, t.GetTicketPrice(priceType), remark);
            detail.TicketAssignList.Add(new TicketAssign(name, idcardno, detail,amount));
            details.Add(detail);
           if (t.As<Ticket>() is TicketUnion)
            {
                foreach (Ticket childt in ((TicketUnion)t).TicketList)
                {
                    CreateChildDetail(details, detail, childt, priceType, name, idcardno, amount, remark);
                }

            }
            return details;

        }
        public void CreateChildDetail(IList<OrderDetail>details,OrderDetail parentDetail, Ticket t, PriceType priceType, string name, string idcardno, int amount, string remark)
        {

            //1为此门票创建订单,如果是套票 则需要创建子detail
            OrderDetail detail = new OrderDetail(amount, t.GetTicketPrice(priceType), remark);
            detail.TicketAssignList.Add(new TicketAssign(name, idcardno, detail, amount));
            detail.OrderDetailForUnionTicket = parentDetail;
          details.Add(detail);
            if (t.As<Ticket>() is TicketUnion)
            {
                foreach (Ticket childt in ((TicketUnion)t).TicketList)
                {
                    CreateChildDetail(details,detail, childt, priceType, name, idcardno, amount, remark);   
                }

            }
          

        }
        /*递归生成 orderdetail的方法
         * orderdetail ChildTicketDetail 的,mapping 没有起作用 */
        /*
        public OrderDetail CreateDetail(Ticket t, PriceType priceType, string name, string idcardno, int amount, string remark)
        {

            //1为此门票创建订单,如果是套票 则需要创建子detail
            OrderDetail detail = new OrderDetail(amount, t.GetTicketPrice(priceType), remark);
            detail.TicketAssignList.Add(new TicketAssign(name, idcardno, detail,amount));
           if (t.As<Ticket>() is TicketUnion)
            {
                foreach (Ticket childt in ((TicketUnion)t).TicketList)
                {
                    CreateChildDetail(detail, childt, priceType, name, idcardno, amount, remark);
                }

            }
            return detail;

        }
        public void CreateChildDetail(OrderDetail parentDetail, Ticket t, PriceType priceType, string name, string idcardno, int amount, string remark)
        {

            //1为此门票创建订单,如果是套票 则需要创建子detail
            OrderDetail detail = new OrderDetail(amount, t.GetTicketPrice(priceType), remark);
            detail.TicketAssignList.Add(new TicketAssign(name, idcardno, detail, amount));
            parentDetail.ChildTicketDetail.Add(detail);
            if (t.As<Ticket>() is TicketUnion)
            {
                foreach (Ticket childt in ((TicketUnion)t).TicketList)
                {
                   CreateChildDetail(detail, childt, priceType, name, idcardno, amount, remark);   
                }

            }
          

        }
        */
        public IList<OrderDetail> GetOrderDetailForIdcard(string activityCode, string idcardNo)
        { 
          return   IOrderDetail.GetOrderDetailForIdcardInActivity( activityCode, idcardNo);
        }
    }
}
