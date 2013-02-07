using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NHibernate;
using NHibernate.Transform;

namespace DAL
{
    public class DALOrderDetail:DalBase<OrderDetail>
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

        public class SoldReport
        {
            public DateTime SoldDate { get; set; }
            public long SoldAmount { get; set; }
        }
        public void GetSoldReport()
        { 
           // ICriteria crit=session.create

            string sql = @"select detail.Order.BuyTime as SoldDate,sum(detail.Quantity) as SoldAmount
  from OrderDetail detail 
    where
   
   
   detail.TicketPrice.Ticket.Scenic.Id="+437+" group by detail.Order.BuyTime";
            /* detail.Order.BuyTime  between :beginDate and :endDate and*/
            DateTime now = DateTime.Now;
            var query = session.CreateQuery(sql)
              //  .SetParameter("beginDate", now.AddYears(-1))
              //  .SetParameter("endDate", now)
           // .SetParameter("scenicId", 437)
           ;
          var result=  query//.SetResultTransformer(Transformers.AliasToBean<SoldReport>())
                 .Future<object>();
          foreach (object sr in result)
          {
              string aa = "";
          }
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
       
        public IList<OrderDetail> GetOrderDetailForIdcardInActivity(string activityCode, string idcardNo)
        {
          string sql =string.Format( @"select detail from OrderDetail detail
                        inner join detail.TicketAssignList  assign
                       with assign.IdCard='{0}'
                        where detail.TicketPrice.Ticket.TourActivity.ActivityCode='{1}'
                            ",idcardNo,activityCode);
          var iquery = session.CreateQuery(sql).SetCacheMode(CacheMode.Ignore);
          return iquery.List<OrderDetail>();
      //  var queryover = session.QueryOver<OrderDetail>()
      //.Where(x => x.TicketPrice.Ticket.TourActivity != null && x.TicketPrice.Ticket.TourActivity.ActivityCode == activityCode)
      //.Where(x => x.TicketAssignList.ToLookup(y => y.IdCard == idcardNo).Count > 0);
    
        }
        public IList<OrderDetail> GetUsedOrderDetailForIdcardInActivity(string activityCode)
        {
               string sql = string.Format(@"select detail from OrderDetail detail
                        inner join detail.TicketAssignList  assign
                       with assign.IsUsed=1 " +
                            "where detail.TicketPrice.Ticket.TourActivity.ActivityCode='{0}'"
                                , activityCode);
           
            return session.CreateQuery(sql).Future<OrderDetail>().ToList();
        }

        public IList<TicketAssign> GetTaForIdCardInActivity(string activityCode,DateTime dt)
        {
            string sql = "select ta from TicketAssign ta where ta.IsUsed=1 and ta.OrderDetail.OrderDetailForUnionTicket.Id is null"
                + " and ta.UsedTime>='" + dt.ToString() + "' and ta.UsedTime<='" + dt.AddDays(1).ToString() + "'" +
                " and ta.OrderDetail.TicketPrice.Ticket.TourActivity.ActivityCode='" + activityCode + "'";
            return session.CreateQuery(sql).Future<TicketAssign>().ToList();
        }
    }
}
