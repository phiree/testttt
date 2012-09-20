using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLOrderDetail
    {
        IDAL.IOrderDetail IOrderDetail =new DAL.DALOrderDetail();

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
    }
}
