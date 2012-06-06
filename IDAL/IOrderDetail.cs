using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IOrderDetail
    {
        int SaveOrUpdateOrderDetail(OrderDetail orderdetail);
        OrderDetail GetOrderDetailByodid(int odid);
        IList<OrderDetail> GetOrderDetailByorderid(int orderid);
        void saveorupdate(OrderDetail od);
    }
}
