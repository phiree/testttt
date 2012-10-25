using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ExcelOplib
{
    public class ExcelDjsOpr
    {
        public  List<Entity.DJSEntity> getDJSlist()
        {
            try
            {
                DataSet ds = new DataSet();
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=d:\企业数据.xlsx;Extended Properties=""Excel 12.0;HDR=YES""";

                #region 地接社
                string sql1 = "select 一级部门,二级部门,三级部门,地区 from [地接社$]";
                DataTable dt1 = new DataTable();
                OleDbCommand cmd1 = new OleDbCommand(sql1, new OleDbConnection(conn));
                OleDbDataAdapter ad1 = new OleDbDataAdapter(cmd1);
                ad1.Fill(dt1);
                #endregion

                #region 景区
                string sql2 = "select 一级部门,二级部门,三级部门,地区 from [景区$]";
                DataTable dt2 = new DataTable();
                OleDbCommand cmd2 = new OleDbCommand(sql2, new OleDbConnection(conn));
                OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd2);
                ad2.Fill(dt2);
                #endregion

                #region 宾馆
                string sql3 = "select 一级部门,二级部门,三级部门,地区 from [宾馆$]";
                DataTable dt3 = new DataTable();
                OleDbCommand cmd3 = new OleDbCommand(sql3, new OleDbConnection(conn));
                OleDbDataAdapter ad3 = new OleDbDataAdapter(cmd3);
                ad3.Fill(dt3);
                #endregion

                #endregion

                List<Entity.DJSEntity> djslist = new List<Entity.DJSEntity>();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt1.Rows[i][0].ToString())) continue;
                    //如果excel中的行不为空,添加
                    djslist.Add(new Entity.DJSEntity()
                    {
                        Department1 = dt1.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Department2 = dt1.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Department3 = dt1.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Diqu = dt1.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        EnterpType=Entity.数据类型.地接社
                    });
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt1.Rows[i][0].ToString())) continue;
                    //如果excel中的行不为空,添加
                    djslist.Add(new Entity.DJSEntity()
                    {
                        Department1 = dt2.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Department2 = dt2.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Department3 = dt2.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Diqu = dt1.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        EnterpType = Entity.数据类型.景区
                    });
                }
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt1.Rows[i][0].ToString())) continue;
                    //如果excel中的行不为空,添加
                    djslist.Add(new Entity.DJSEntity()
                    {
                        Department1 = dt3.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Department2 = dt3.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Department3 = dt3.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Diqu = dt1.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        EnterpType = Entity.数据类型.宾馆
                    });
                }
                return djslist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
