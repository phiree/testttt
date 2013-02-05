using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DAL.ado
{
    //参与者获得门票的数量
   public class commsql
    {
       SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["touronline"].ConnectionString);

       public int IdCardAmountPerActivity(string activityCode,string idcard)
       {
           string sql = string.Format(@"select count(*)
                                    from TicketAssign ta,OrderDetail detail
                                    ,TicketPrice tp,Ticket t,TourActivity act
                                    where ta.OrderDetail_id=detail.Id
                                    and detail.TicketPrice_id=tp.Id
                                    and tp.Ticket_id=t.Id
                                    and t.TourActivity_id=act.Id
                                    and ta.IdCard='{0}'
                                    and ActivityCode='{1}'", idcard, activityCode);
           return ExecuteScalarInt(sql);

       }
       public int IdCardAmountPerActivityPerTicket(string activityCode, string ticketcode, string idcard)
       {
           string sql = string.Format(@"select count(*)
                                    from TicketAssign ta,OrderDetail detail
                                    ,TicketPrice tp,Ticket t,TourActivity act
                                    where ta.OrderDetail_id=detail.Id
                                    and detail.TicketPrice_id=tp.Id
                                    and tp.Ticket_id=t.Id
                                    and t.TourActivity_id=act.Id
                                    and ta.IdCard='{0}'
                                    and ActivityCode='{1}'
                                    and t.ProductCode='{2}'", idcard, activityCode, ticketcode);
           return ExecuteScalarInt(sql);

       }
       public int ExecuteScalarInt(string sql)
       {
           SqlCommand comm = new SqlCommand(sql, conn);
           OpenConn();
           int scalarResult =(int) comm.ExecuteScalar();
           conn.Close();
           return scalarResult;
       }

       

       public void OpenConn()
       {
            if (conn.State != System.Data.ConnectionState.Open)
           {
               conn.Open();
           }
       }
       public void CloseConn()
       {
           if (conn.State != System.Data.ConnectionState.Closed)
           {
               conn.Close();
           }
       }
    }
}
