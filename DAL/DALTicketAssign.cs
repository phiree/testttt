using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;
using System.Data;
 
namespace DAL
{
    public class DALTicketAssign:DalBase<TicketAssign>
    {
        public void SaveOrUpdate(TicketAssign ticketassign)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(ticketassign);
                x.Commit();
            }
        }

        public TicketAssign GetTicketAssignByID(Guid assignID)
        {
            string sql = "select ta from TicketAssign ta where ta.Id='" + assignID + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().First();
        }

        public IList<TicketAssign> GetTicketAssignByUserId(Guid userid)
        {
            string sql = "select ta from TicketAssign ta where ta.OrderDetail.Order.MemberId='" + userid + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }
        public IList<TicketAssign> GetTicketAssignByUserId(Guid userid,bool isUsed)
        {
            string sql = "select ta from TicketAssign ta where ta.OrderDetail.Order.MemberId='" + userid + "'";
            sql += " and ta.IsUsed=" + isUsed;
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }

        public IList<TicketAssign> GetIsUsedCountByAsodid(int odid)
        {
            string sql = "select ta  from TicketAssign ta where ta.OrderDetail.Id=" + odid + " and IsUsed=false";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }



        public IList<TicketAssign> GetByodid(int odid)
        {
            string sql = "select ta from TicketAssign ta where ta.OrderDetail.Id=" + odid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }


        public IList<DataTable> GetTicketAssignBynameandidcard(string name, string idcard, Scenic scenic)
        {
            string sql = "select ta.Name,ta.OrderDetail.Quantity,ta.OrderDetail.TicketPrice.Price,OrderDetail.Order.BuyTime from TicketAssign ta where ta.Name like '%" + name + "%' and ta.IdCard like '%" + idcard + "%' and ta.OrderDetail.TicketPrice.Ticket.Scenic.Id=" + scenic.Id + " and ta.OrderDetail.TicketPrice.PriceType=2 group by ta.Name,ta.OrderDetail.Quantity,ta.OrderDetail.TicketPrice.Price,OrderDetail.Order.BuyTime";
            IQuery query = session.CreateQuery(sql);
            return query.Future<DataTable>().ToList<DataTable>();
        }


        public List<TicketAssign> GetIdcardandname(string name, string idcard, Scenic scenic)
        {
            string sql = "select ta.Name,ta.IdCard from TicketAssign ta where ta.Name like '%" + name + "%' and ta.IdCard like '%" + idcard + "%' and ta.OrderDetail.TicketPrice.Ticket.Scenic.Id=" + scenic.Id + " and ta.IsUsed=0  group by ta.Name,ta.IdCard";
            IQuery query = session.CreateQuery(sql);
            IList<Object[]> list;
            list = query.List<object[]>();
            List<TicketAssign> listticketassign = new List<TicketAssign>();
            foreach (object[] item in list)
            {
                TicketAssign ta = new TicketAssign();
                ta.Name = item[0].ToString();
                ta.IdCard = item[1].ToString();
                listticketassign.Add(ta);
            }
            //必须加上联票买票的人
            List<Ticket> listticket = new DALScenicTicket().GetTicketByScenicId(scenic.Id).ToList();
            foreach (Ticket item in listticket)
            {
                sql = "select ta.Name,ta.IdCard from TicketAssign ta where ta.Name like '%" + name + "%' and ta.IdCard like '%" + idcard + "%' and ta.OrderDetail.TicketPrice.Ticket.Id=" + item.Id + "  group by ta.Name,ta.IdCard";
                query = session.CreateQuery(sql);
                list = query.List<object[]>();
                foreach (object[] oitem in list)
                {
                    TicketAssign ta = new TicketAssign();
                    ta.Name = oitem[0].ToString();
                    ta.IdCard = oitem[1].ToString();
                    listticketassign.Add(ta);
                }
            }
            return listticketassign;
        }


        public void GetTicketInfoByIdCard(string idcard, Ticket ticket, out int ydcount, out int usedcount,int type)
        {
            string sqlyd = "select count(ta) from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticket.Id + " and ta.OrderDetail.TicketPrice.PriceType="+type+"";
            IQuery queryyd = session.CreateQuery(sqlyd);
            ydcount =(int)queryyd.FutureValue<long>().Value;
            string sqlused = "select count(ta) from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticket.Id + " and ta.IsUsed=true and ta.OrderDetail.TicketPrice.PriceType=" + type + "";
            IQuery queryused = session.CreateQuery(sqlused);
            usedcount = (int)queryused.FutureValue<long>().Value;
        }


        public IList<TicketAssign> GetNotUsedTicketAssign(string idcard, Ticket ticket,int type)
        {
            string sql = "select ta from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticket.Id + " and ta.IsUsed=false and ta.OrderDetail.TicketPrice.PriceType=" + type + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }


        public TicketAssign GetLasetRecordByidcard(string idcard, Ticket ticket,int type)
        {
            string sql = "select ta from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticket.Id + " and ta.OrderDetail.TicketPrice.PriceType=" + type + " order by ta.Id desc";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<TicketAssign>().Value;
        }


        public void GetOlTicketInfoByIdcard(string idcard, Ticket ticket, out int olcount, out int usedolcount, int type)
        {
            string sqlyd = "select count(ta) from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticket.Id + " and ta.OrderDetail.TicketPrice.PriceType=" + type + " and ta.OrderDetail.Order.IsPaid=true";
            IQuery queryyd = session.CreateQuery(sqlyd);
            olcount = (int)queryyd.FutureValue<long>().Value;
            string sqlused = "select count(ta) from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticket.Id + " and ta.IsUsed=true and ta.OrderDetail.TicketPrice.PriceType=" + type + "";
            IQuery queryused = session.CreateQuery(sqlused);
            usedolcount = (int)queryused.FutureValue<long>().Value;
        }

        public IList<TicketAssign> Getolnotusedticketassign(string idcard, int ticketid, int type)
        {
            string sql = "select ta from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Id=" + ticketid + " and ta.IsUsed=false and ta.OrderDetail.TicketPrice.PriceType=" + type + " and ta.OrderDetail.Order.IsPaid=true ";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }

        public List<TicketAssign> GetUsedRecord(string idcard)
        {
            StringBuilder sql=new StringBuilder();
            sql.Append("select ta.Name,ta.UsedTime,ta.OrderDetail.TicketPrice.Ticket.Scenic.Name,ta.OrderDetail.TicketPrice.PriceType,");
            sql.Append("ta.OrderDetail.TicketPrice.Price,ta.OrderDetail.Id from TicketAssign ta where ta.IsUsed=true and ta.IdCard='"+idcard+"'");
            sql.Append(" group by ta.Name,ta.UsedTime,ta.OrderDetail.TicketPrice.Ticket.Scenic.Name,ta.OrderDetail.TicketPrice.PriceType,");
            sql.Append("ta.OrderDetail.TicketPrice.Price,ta.OrderDetail.Id");
            IQuery query = session.CreateQuery(sql.ToString());
            IList<Object[]> list;
            list = query.List<object[]>();
            List<TicketAssign> listticket = new List<TicketAssign>();
            foreach (object[] item in list)
            {
                TicketAssign ta = new TicketAssign();
                ta.Name = item[0].ToString();
                ta.UsedTime = DateTime.Parse(item[1].ToString());
                OrderDetail od = new OrderDetail();
                TicketPrice tp = new TicketPrice();
                tp.PriceType = (PriceType)int.Parse(item[3].ToString());
                tp.Price = decimal.Parse(item[4].ToString());
                Ticket t = new Ticket();
                Scenic s = new Scenic();
                s.Name = item[2].ToString();
                t.Scenic = s;
                tp.Ticket = t;
                od.TicketPrice = tp;
                ta.OrderDetail = od;
                listticket.Add(ta);
            }
            return listticket;
        }

        public int GetUsedCount(string idcard, DateTime dt)
        {
            string sql = "select count(*) from TicketAssign ta where ta.UsedTime='" + dt + "' and ta.IsUsed=true and ta.IdCard='" + idcard + "'";
            IQuery query = session.CreateQuery(sql);
            return (int)query.FutureValue<long>().Value;
        }

        public int GetUnusedCount(string idcard)
        {
            string sql = "select count(*) from TicketAssign ta where ta.IsUsed=false and ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.PriceType=3";
            IQuery query = session.CreateQuery(sql);
            return (int)query.FutureValue<long>().Value;
        }

        public int GetDdCount(string idcard)
        {
            string sql = "select count(*) from TicketAssign ta where  ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.PriceType=2";
            IQuery query = session.CreateQuery(sql);
            return (int)query.FutureValue<long>().Value;
        }


        public List<TicketAssign> GetYwCount(string idcard)
        {
            string sql = "select ta.UsedTime from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.IsUsed=true group by ta.UsedTime";
            IQuery query = session.CreateQuery(sql);
            IList<object> list;
            list = query.List<object>();
            List<TicketAssign> listticket = new List<TicketAssign>();
            foreach (object item in list)
            {
                TicketAssign ta = new TicketAssign();
                ta.UsedTime = DateTime.Parse(item.ToString());
                listticket.Add(ta);
            }
            return listticket;
        }


        public IList<TicketAssign> GetTaByIdCard(string idcard)
        {
            string sql = "select ta from TicketAssign ta where ta.IdCard='" + idcard + "'";
            IQuery query = session.CreateQuery(sql).SetCacheable(false);
            //session.Flush();
            return query.List<TicketAssign>();
        }

      
        public IList<TicketAssign> GetTaByIdcardandscenic(string idcard, Scenic scenic)
        {
            string sql = "select ta from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.Scenic.Id=" + scenic.Id + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }
        public IList<TicketAssign> GetTaByIdcardandTicketCode(string idcard, string ticketCode)
        {
            string sql = "select ta from TicketAssign ta where ta.IdCard='" + idcard + "' and ta.OrderDetail.TicketPrice.Ticket.ProductCode='" + ticketCode+ "'";
            IQuery query = session.CreateQuery(sql);

            return query.Future<TicketAssign>().ToList<TicketAssign>();
        }

        public IList<Ticket> GetTicketTypeByIdCard(string idcard)
        {
            string sql = "select ta.OrderDetail.TicketPrice.Ticket.Id,ta.OrderDetail.TicketPrice.Ticket.Name from TicketAssign ta";
            sql += " where ta.IdCard='" + idcard + "' group by ta.OrderDetail.TicketPrice.Ticket.Id,ta.OrderDetail.TicketPrice.Ticket.Name";
            IQuery query = session.CreateQuery(sql.ToString());
            IList<Object[]> list;
            list = query.List<object[]>();
            List<Ticket> listticket = new List<Ticket>();
            foreach (object[] item in list)
            {
                Ticket t = new Ticket();
                t.Id = int.Parse(item[0].ToString());
                t.Name = item[1].ToString();
                listticket.Add(t);
            }
            return listticket;
        }
        public void UpdateIdCardNo(string oldNo, string newNo)
        {
            string sql =string.Format( "update TicketAssign as ta  set IdCard='{1}' where IdCard='{0}'"
                ,oldNo,newNo);
            IQuery query = session.CreateQuery(sql);
           int result= query.ExecuteUpdate();
        }

        public IList<TicketAssign> GetList(string areaCodeHead, int? entId, DateTime? dateBegin, DateTime? dateEnd, bool? isUsed)
        {
            string select = "select ta from TicketAssign ta ";
            string where = " where 1=1 ";
            //使用linq是否可以解决单元测试的数据库交互问题?
            if (entId.HasValue)
            {

                where += " and  ta.OrderDetail.TicketPrice.Ticket.Scenic.Id=" + entId.Value;
            }
            if (!string.IsNullOrEmpty(areaCodeHead))
            {
                where += " and ta.OrderDetail.TicketPrice.Ticket.Scenic.Area.Code like '" + areaCodeHead + "%'";
            }
            if (dateBegin.HasValue)
            {
                where += " and ta.OrderDetail.Order.BuyTime>=" + dateBegin.Value;
            }
            if (dateEnd.HasValue)
            {
                where += " and ta.OrderDetail.Order.BuyTime<=" + dateEnd.Value;
            }
            if (isUsed.HasValue)
            {
                where += " and ta.IsUsed=" + isUsed.Value;
            }

            return GetList(select + where);
            
        }

    }
}
