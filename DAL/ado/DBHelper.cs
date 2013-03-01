using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DB.Helper
{
    public class DBHelper
    {
        protected static SqlConnection Connection;
        private static string connectionString;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        static DBHelper()
        {
            string connStr;
            connStr = ConfigurationManager.ConnectionStrings["touronline"].ToString();
            connectionString = connStr;
            Connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// 完成SqlCommand对象的实例化
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        private static SqlCommand BuildCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(storedProcName, parameters);
            command.CommandTimeout = 180;
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        /// <summary>
        /// 创建新的SQL命令对象(存储过程)
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private static SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, Connection);
            command.CommandTimeout = 180;
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// 执行存储过程,无返回值
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        public static void ExecuteProcedure(string storedProcName, IDataParameter[] parameters)
        {
            Connection.Open();
            SqlCommand command;
            command = BuildQueryCommand(storedProcName, parameters);
            command.ExecuteNonQuery();
            command.Dispose();
            Connection.Close();

        }

        /// <summary>
        /// 执行存储过程，返回执行操作影响的行数目
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected"></param>
        /// <returns>影响的行数目</returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            int result = 0;
            Connection.Open();
            using (SqlCommand command = BuildCommand(storedProcName, parameters))
                try
                {
                    rowsAffected = command.ExecuteNonQuery();
                    result = (int)command.Parameters["ReturnValue"].Value;
                }
                catch (Exception error)
                {
                    Close();
                    throw (error);
                }
                finally
                {
                    command.Parameters.Clear(); //清空SqlCommand中的参数列表      
                    Connection.Close();
                }
            return result;
        }

        /// <summary>
        /// 重载RunProcedure把执行存储过程的结果放在SqlDataReader中
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlDataReader returnReader;
            Connection.Open();
            SqlCommand command = BuildQueryCommand(storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }

        /// <summary>
        /// 重载RunProcedure把执行存储过程的结果存储在DataSet中和表tableName为可选参数
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">设置表名</param>
        /// <returns>返回DataSet对象</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, params string[] tableName)
        {
            DataSet dataSet = new DataSet();
            Connection.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters);
            string flag;
            flag = "";
            for (int i = 0; i < tableName.Length; i++)
                flag = tableName[i];
            if (flag != "")
                sqlDA.Fill(dataSet, tableName[0]);
            else
                sqlDA.Fill(dataSet);
            Connection.Close();
            return dataSet;
        }

        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>
        /// <param name="sql">返回 DataReader</param>
        /// <returns>返回DataSet对象</returns>
        public static DataSet ReturnDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            Connection.Open();
            using (SqlDataAdapter sqlDA = new SqlDataAdapter(sql, Connection))
                sqlDA.Fill(dataSet, "objDataSet");
            Connection.Close();
            return dataSet;
        }

        /// <summary>
        /// 执行SQL语句，返回 DataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回 DataReader对象</returns>
        private static SqlDataReader ReturnDataReader(String sql)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(sql, Connection);
            command.CommandTimeout = 180;
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
            //Connection.Close(); //不能在此关闭,否则无法返回SqlDataReader
        }
        /// <summary>
        /// 执行SQL语句，返回 SqlDataAdapter
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回 SqlDataAdapter</returns>
        private static SqlDataAdapter ReturnDataAdapter(String sql)
        {
            Connection.Open();
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, Connection);
            Connection.Close();
            return Adapter;
        }

        /// <summary>
        /// 执行SQL语句，返回记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回记录条数</returns>
        public static int ReturnRecordCount(string sql)
        {
            int recordCount = 0;
            Connection.Open();
            SqlCommand command = new SqlCommand(sql, Connection);
            command.CommandTimeout = 180;
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                recordCount++;
            }
            dataReader.Close();
            command.Dispose();
            Connection.Close();


            return recordCount;
        }

        /// <summary>
        /// 执行SQL语句,用于插入、更新和删除
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回true/false,表示是否执行成功</returns>
        public static bool ExecSql(string sql)
        {
            bool successState = false;
            Connection.Open();
            SqlTransaction myTrans = Connection.BeginTransaction();
            SqlCommand command = new SqlCommand(sql, Connection, myTrans);
            command.CommandTimeout = 180;
            try
            {
                command.ExecuteNonQuery();
                myTrans.Commit();
                successState = true;
                Connection.Close();
            }
            catch
            {
                myTrans.Rollback();
            }
            finally
            {
                command.Dispose();
                Connection.Close();
            }
            return successState;
        }

        /// <summary>
        /// 关闭数据库联接
        /// </summary>
        private static void Close()
        {
            ///判断连接是否已经创建
            if (Connection != null)
            {
                ///判断连接的状态是否打开
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

        }
        /// <summary>
        /// 释放所用资源
        /// </summary>
        public static void Dispose()
        {
            ///判断连接是否已经创建
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }

        /// <summary>    
        /// 获取安全的SQL字符串    
        /// </summary>    
        /// <param name="sql语句"></param>    
        /// <returns></returns>    
        public static string GetSafeSQLString(string sql)
        {
            sql = sql.Replace(",", "，");
            sql = sql.Replace(".", "。");
            sql = sql.Replace("(", "（");
            sql = sql.Replace(")", "）");
            sql = sql.Replace(">", "＞");
            sql = sql.Replace("<", "＜");
            sql = sql.Replace("-", "－");
            sql = sql.Replace("+", "＋");
            sql = sql.Replace("=", "＝");
            sql = sql.Replace("?", "？");
            sql = sql.Replace("*", "＊");
            sql = sql.Replace("|", "｜");
            sql = sql.Replace("&", "＆");
            return sql;
        }
    }
}
