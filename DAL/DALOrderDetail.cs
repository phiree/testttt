using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NHibernate;

namespace DAL
{
    public class DALOrderDetail:DalBase,IDAL.IOrderDetail
    {
        public int SaveOrUpdateOrderDetail(OrderDetail orderdetail)
        {
            return (int)session.Save(orderdetail);
        }

        public OrderDetail GetOrderDetailByodid(int odid)
        {
            string sql = "select od from OrderDetail od where od.Id=" + odid + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<OrderDetail>().Value;
        }


        public IList<OrderDetail> GetOrderDetailByorderid(int orderid)
        {
            string sql = "select od from OrderDetail od where od.Order.Id=" + orderid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<OrderDetail>().ToList<OrderDetail>();
        }


        public void saveorupdate(OrderDetail od)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(od);
                x.Commit();
            }
        }
    }
}
