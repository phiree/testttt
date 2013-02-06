using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL.ado
{
    //参与者获得门票的数量
    public class NativeSqlUtiliity
    {

        public NativeSqlUtiliity(string connectionString)
        {
            this.conn = new SqlConnection(connectionString);
        }
        private SqlConnection conn;
        public int ExecuteScalarInt(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            OpenConn();
            int scalarResult = (int)comm.ExecuteScalar();
            conn.Close();
            return scalarResult;
        }
        public void ExecuteNonResult(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            OpenConn();
          comm.ExecuteNonQuery();
            conn.Close();
            
        }

        public DataSet ExecuteDateSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlCommand comm = new SqlCommand(sql, conn);
            OpenConn();
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            return ds;
        }

        private void OpenConn()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }
        private void CloseConn()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public int IdCardAmountPerActivity(string activityCode, string idcard)
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

    }
}
