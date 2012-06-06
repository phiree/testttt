using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
namespace DAL
{
   public class DALPayment:DalBase, IDAL.IPayment
    {
        public void Save(Model.Payment payment)
        {
            if (payment.BeginPay.Year<2000) payment.BeginPay = DateTime.Now;
            if (payment.EndPay.Year < 2000) payment.EndPay = DateTime.Now;
            session.SaveOrUpdate(payment);
            session.Flush();
        }

        public Model.Payment GetByOrder(int orderId)
        {
            string query = "select p from Payment p where p.Order.Id="+orderId;
            IQuery qry = session.CreateQuery(query);
           IFutureValue<object> objPayment=  qry.FutureValue<object>();
           if (objPayment == null)
           {
               return null;
           }
           if (objPayment.Value.GetType() == typeof(Model.Payment))
           {
               return (Model.Payment)objPayment.Value;
           }
           else
           {
               return null;
           }
        }
    }
}
