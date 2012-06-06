using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;
using NHibernate;

namespace DAL
{
    public class DALDiscountCode:DalBase,IDiscountCode
    {
        public IList<Model.DiscountCode> GetDiscountCodeByCardid(string cardid)
        {
            string sqlstr = "select dc from DiscountCode dc where dc.IdCard='" + cardid + "'";
            IQuery query = session.CreateQuery(sqlstr);
            return query.Future<Model.DiscountCode>().ToList<Model.DiscountCode>();
        }




        public DiscountCode GetDiscountByDisCode(string DisCode)
        {
            string sqlstr = "select dc from DiscountCode dc where dc.DisCode='" + DisCode + "'";
            IQuery query = session.CreateQuery(sqlstr);
            return query.FutureValue<Model.DiscountCode>().Value;
        }

        public void updateDiscountCode(Model.DiscountCode dc)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.Update(dc);
                x.Commit();
            }
            
        }
    }
}
