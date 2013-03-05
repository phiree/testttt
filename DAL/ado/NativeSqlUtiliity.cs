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
            if (string.IsNullOrEmpty(connectionString))
            {
                this.conn = new SqlConnection("Server=.\\sql2008;database=ttt;uid=sa;pwd=aa123");
            }
            else
            {
                this.conn = new SqlConnection(connectionString);
            }
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
        public DataSet ExecuteDataSetProc(string StoreProcName, string[] aParamList, out string returnMsg)
        {
            returnMsg = string.Empty;

            DataSet Result = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand(StoreProcName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlCommandBuilder.DeriveParameters(cmd);
                int ParamCount = aParamList.Length + 1;

                if (cmd.Parameters.Count != ParamCount)
                {
                    returnMsg = "输入的参数和存储过程的参数数目不符合";

                }
                else
                {
                    for (int i = 0; i < aParamList.Length; i++)
                    {
                        cmd.Parameters[i + 1].DbType = DbType.String;
                        if (aParamList[i] == null)
                            cmd.Parameters[i + 1].Value = DBNull.Value;
                        else
                            cmd.Parameters[i + 1].Value = aParamList[i];
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(Result);

                    if (Result.Tables.Count > 0 && Result.Tables[Result.Tables.Count - 1].Rows.Count > 0)
                    {
                        if (Result.Tables[Result.Tables.Count - 1].Rows[0][0].ToString() == "F")
                        {
                            //r = false;
                            if (Result.Tables[Result.Tables.Count - 1].Columns.Count > 1)
                                returnMsg = Result.Tables[Result.Tables.Count - 1].Rows[0][1].ToString();
                        }
                        else
                        {
                            returnMsg = "T";
                        }
                    }

                }
            }

            catch (Exception ee)
            {
                returnMsg = ee.Message;
            }
            return Result;
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
