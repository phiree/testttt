using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ExcelOplib
{
    public class ExcelDjsOpr
    {
        public  List<Entity.DJSEntity> getDJSlist(string path)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @";Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 类型,姓名,身份证号,电话号码 from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                ad.Fill(dt);
                #endregion
                #region 03
                if (dt == null || dt.Rows.Count == 0)
                {
                    conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=Excel 8.0";
                    cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                    ad = new OleDbDataAdapter(cmd);
                    ad.Fill(dt);
                }
                #endregion
                List<Entity.DJSEntity> djslist = new List<Entity.DJSEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                    //对景区详情处理
                    string scdetail = dt.Rows[i][6].ToString().Replace("\n", "").Trim();

                    //如果excel中的行不为空,添加
                    djslist.Add(new Entity.DJSEntity()
                    {
                        MemType = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        MemName = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        MemID = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        MemPhone = dt.Rows[i][3].ToString().Replace("\n", "").Trim()
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
