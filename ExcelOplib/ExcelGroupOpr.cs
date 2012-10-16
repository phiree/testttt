using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ExcelOplib
{
    public class ExcelGroupOpr
    {
        public Entity.GroupBasic getBasiclist(string path)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 团队名称,起止时间,天数,人数,成人,儿童,上车集合点,返程点 from [基本信息$]";
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
                //List<Entity.GroupBasic> gblist = new List<Entity.GroupBasic>();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    //如果excel中的某行为空,跳过
                //    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                //    //如果excel中的行不为空,添加
                //    gblist.Add(new Entity.GroupBasic()
                //    {
                //        Name = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                //        Bedate = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                //        Days = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                //        PeopleTotal = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
                //        PeopleAdult = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
                //        PeopleChild = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
                //        StartPlace = dt.Rows[i][6].ToString().Replace("\n", "").Trim(),
                //        EndPlace = dt.Rows[i][7].ToString().Replace("\n", "").Trim()
                //    });
                //}
                Entity.GroupBasic gb = new Entity.GroupBasic();
                if (string.IsNullOrEmpty(dt.Rows[0][1].ToString())) ;

                //如果excel中的行不为空,添加
                gb = new Entity.GroupBasic()
                {
                    Name = dt.Rows[0][0].ToString().Replace("\n", "").Trim(),
                    Begindate = dt.Rows[0][1].ToString().Replace("\n", "").Trim(),
                    Days = dt.Rows[0][2].ToString().Replace("\n", "").Trim(),
                    PeopleTotal = dt.Rows[0][3].ToString().Replace("\n", "").Trim(),
                    PeopleAdult = dt.Rows[0][4].ToString().Replace("\n", "").Trim(),
                    PeopleChild = dt.Rows[0][5].ToString().Replace("\n", "").Trim(),
                    StartPlace = dt.Rows[0][6].ToString().Replace("\n", "").Trim(),
                    EndPlace = dt.Rows[0][7].ToString().Replace("\n", "").Trim()
                };
                //如果获取到了list,就把上传上来的文件删除
                File.Delete(path.Replace('/', '\\'));
                return gb;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Entity.GroupMember> getMemberlist(string path)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 类型,姓名,身份证号,电话号码,导游证号,车牌号 from [团队信息$]";
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
                List<Entity.GroupMember> gmlist = new List<Entity.GroupMember>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                    //如果excel中的行不为空,添加
                    gmlist.Add(new Entity.GroupMember()
                    {
                        Memtype = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Memname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Memid = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Memphone = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        Cardno = dt.Rows[i][4].ToString().Replace("\n", "").Trim()
                    });
                }
                //如果获取到了list,就把上传上来的文件删除
                File.Delete(path.Replace('/', '\\'));
                return gmlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Entity.GroupRoute> getRoutelist(string path)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 日期,早餐,中餐,晚餐,住宿,景点,购物点 from [行程信息$]";
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
                List<Entity.GroupRoute> grlist = new List<Entity.GroupRoute>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                    //如果excel中的行不为空,添加
                    grlist.Add(new Entity.GroupRoute()
                    {
                        RouteDate = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Breakfast = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Lunch = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Dinner = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        Hotel1 = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
                        Scenic1 = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
                        ShoppingPoint1 = dt.Rows[i][6].ToString().Replace("\n", "").Trim()
                    });
                }
                //如果获取到了list,就把上传上来的文件删除
                File.Delete(path.Replace('/', '\\'));
                return grlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Entity.GroupAll getGroup(string path)
        {
            try
            {
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
                #endregion

                #region 基本信息
                //Sheet1为excel中表的名字
                DataTable dt1 = new DataTable();
                string sql1 = "select 团队名称,开始时间,天数,人数,成人,儿童,上车集合点,返程点,结束时间 from [基本信息$]";
                OleDbCommand cmd1 = new OleDbCommand(sql1, new OleDbConnection(conn));
                OleDbDataAdapter ad1 = new OleDbDataAdapter(cmd1);
                ad1.Fill(dt1);

                Entity.GroupBasic gb = new Entity.GroupBasic();
                //if (string.IsNullOrEmpty(dt.Rows[0][1].ToString())) return;

                //如果excel中的行不为空,添加
                gb = new Entity.GroupBasic()
                {
                    Name = dt1.Rows[0][0].ToString().Replace("\n", "").Trim(),
                    Begindate = dt1.Rows[0][1].ToString().Replace("\n", "").Trim(),
                    Days = dt1.Rows[0][2].ToString().Replace("\n", "").Trim(),
                    PeopleTotal = dt1.Rows[0][3].ToString().Replace("\n", "").Trim(),
                    PeopleAdult = dt1.Rows[0][4].ToString().Replace("\n", "").Trim(),
                    PeopleChild = dt1.Rows[0][5].ToString().Replace("\n", "").Trim(),
                    StartPlace = dt1.Rows[0][6].ToString().Replace("\n", "").Trim(),
                    EndPlace = dt1.Rows[0][7].ToString().Replace("\n", "").Trim(),
                    Enddate = dt1.Rows[0][8].ToString().Replace("\n", "").Trim()
                };
                #endregion

                #region 人员信息
                DataTable dt2 = new DataTable();
                string sql2 = "select 类型,姓名,身份证号,电话号码,证号 from [团队信息$]";
                OleDbCommand cmd2 = new OleDbCommand(sql2, new OleDbConnection(conn));
                OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd2);
                ad2.Fill(dt2);
                List<Entity.GroupMember> gmlist = new List<Entity.GroupMember>();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt2.Rows[i][1].ToString())) continue;

                    //如果excel中的行不为空,添加
                    gmlist.Add(new Entity.GroupMember()
                    {
                        Memtype = dt2.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Memname = dt2.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Memid = dt2.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Memphone = dt2.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        Cardno = dt2.Rows[i][4].ToString().Replace("\n", "").Trim()
                    });
                }
                #endregion

                #region 行程信息
                DataTable dt3 = new DataTable();
                string sql3 = "select 日期,早餐,中餐,晚餐,住宿1,住宿2,景点1,景点2,景点3,景点4,景点5,购物点1,购物点2,购物点3,购物点4,购物点5 from [行程信息$]";
                OleDbCommand cmd3 = new OleDbCommand(sql3, new OleDbConnection(conn));
                OleDbDataAdapter ad3 = new OleDbDataAdapter(cmd3);
                ad3.Fill(dt3);
                List<Entity.GroupRoute> grlist = new List<Entity.GroupRoute>();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt3.Rows[i][0].ToString())) continue;

                    //如果excel中的行不为空,添加
                    grlist.Add(new Entity.GroupRoute()
                    {
                        RouteDate = dt3.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        Breakfast = dt3.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        Lunch = dt3.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        Dinner = dt3.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        Hotel1 = dt3.Rows[i][4].ToString().Replace("\n", "").Trim(),
                        Hotel2 = dt3.Rows[i][5].ToString().Replace("\n", "").Trim(),
                        Scenic1 = dt3.Rows[i][6].ToString().Replace("\n", "").Trim(),
                        Scenic2 = dt3.Rows[i][7].ToString().Replace("\n", "").Trim(),
                        Scenic3 = dt3.Rows[i][8].ToString().Replace("\n", "").Trim(),
                        Scenic4 = dt3.Rows[i][9].ToString().Replace("\n", "").Trim(),
                        Scenic5 = dt3.Rows[i][10].ToString().Replace("\n", "").Trim(),
                        ShoppingPoint1 = dt3.Rows[i][11].ToString().Replace("\n", "").Trim(),
                        ShoppingPoint2 = dt3.Rows[i][12].ToString().Replace("\n", "").Trim(),
                        ShoppingPoint3 = dt3.Rows[i][13].ToString().Replace("\n", "").Trim(),
                        ShoppingPoint4 = dt3.Rows[i][14].ToString().Replace("\n", "").Trim(),
                        ShoppingPoint5 = dt3.Rows[i][15].ToString().Replace("\n", "").Trim()
                    });
                }
                //合并route,相同routedate合并
                List<Entity.GroupRoute> grlistNew = new List<Entity.GroupRoute>();
                for (int i = 0; i < grlist.Count; i++)
                {
                    if (grlist.Where(x => x.RouteDate.ToUpper() == "D" + (i + 1)).Count() <= 0)
                        continue;
                    var temp = grlist.Where<Entity.GroupRoute>(x => x.RouteDate.ToUpper() == "D" + (i + 1)).ToList();
                    //只有一行
                    if (temp.Count == 1)
                    {
                        grlistNew.Add(grlist[i]);
                    }
                    //多行
                    if (temp.Count > 1)
                    {
                        var zip1 = temp[0];
                        var zip2 = temp[1];
                        grlistNew.Add(new Entity.GroupRoute()
                        {
                            RouteDate = "D" + (i + 1),
                            Breakfast = string.IsNullOrEmpty(zip1.Breakfast) ? zip2.Breakfast : zip1.Breakfast,
                            Lunch = string.IsNullOrEmpty(zip1.Lunch) ? zip2.Lunch : zip1.Lunch,
                            Dinner = string.IsNullOrEmpty(zip1.Dinner) ? zip2.Dinner : zip1.Dinner,
                            Hotel1 = string.IsNullOrEmpty(zip1.Hotel1) ? zip2.Hotel1 : zip1.Hotel1,
                            Hotel2 = string.IsNullOrEmpty(zip1.Hotel2) ? zip2.Hotel2 : zip1.Hotel2,
                            Scenic1 = string.IsNullOrEmpty(zip1.Scenic1) ? zip2.Scenic1 : zip1.Scenic1,
                            Scenic2 = string.IsNullOrEmpty(zip1.Scenic2) ? zip2.Scenic2 : zip1.Scenic2,
                            Scenic3 = string.IsNullOrEmpty(zip1.Scenic3) ? zip2.Scenic3 : zip1.Scenic3,
                            Scenic4 = string.IsNullOrEmpty(zip1.Scenic4) ? zip2.Scenic4 : zip1.Scenic4,
                            Scenic5 = string.IsNullOrEmpty(zip1.Scenic5) ? zip2.Scenic5 : zip1.Scenic5,
                            ShoppingPoint1 = string.IsNullOrEmpty(zip1.ShoppingPoint1) ? zip2.ShoppingPoint1 : zip1.ShoppingPoint1,
                            ShoppingPoint2 = string.IsNullOrEmpty(zip1.ShoppingPoint2) ? zip2.ShoppingPoint2 : zip1.ShoppingPoint2,
                            ShoppingPoint3 = string.IsNullOrEmpty(zip1.ShoppingPoint3) ? zip2.ShoppingPoint3 : zip1.ShoppingPoint3,
                            ShoppingPoint4 = string.IsNullOrEmpty(zip1.ShoppingPoint4) ? zip2.ShoppingPoint4 : zip1.ShoppingPoint4,
                            ShoppingPoint5 = string.IsNullOrEmpty(zip1.ShoppingPoint5) ? zip2.ShoppingPoint5 : zip1.ShoppingPoint5
                        });
                    }
                }
                #endregion

                //如果获取到了list,就把上传上来的文件删除
                File.Delete(path.Replace('/', '\\'));
                return new Entity.GroupAll() { GroupBasic = gb, GroupMemberList = gmlist, GroupRouteList = grlistNew };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
