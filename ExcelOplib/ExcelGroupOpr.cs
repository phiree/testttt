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
        //废弃的方法
        //public Entity.GroupBasic getBasiclist(string path)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        #region 07
        //        //path即是excel文档的路径。
        //        string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
        //        //Sheet1为excel中表的名字
        //        string sql = "select 团队名称,起止时间,天数,人数,成人,儿童,上车集合点,返程点 from [基本信息$]";
        //        OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
        //        OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
        //        ad.Fill(dt);
        //        #endregion
        //        #region 03
        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=Excel 8.0";
        //            cmd = new OleDbCommand(sql, new OleDbConnection(conn));
        //            ad = new OleDbDataAdapter(cmd);
        //            ad.Fill(dt);
        //        }
        //        #endregion
        //        //List<Entity.GroupBasic> gblist = new List<Entity.GroupBasic>();
        //        //for (int i = 0; i < dt.Rows.Count; i++)
        //        //{
        //        //    //如果excel中的某行为空,跳过
        //        //    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

        //        //    //如果excel中的行不为空,添加
        //        //    gblist.Add(new Entity.GroupBasic()
        //        //    {
        //        //        Name = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
        //        //        Bedate = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
        //        //        Days = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
        //        //        PeopleTotal = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
        //        //        PeopleAdult = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
        //        //        PeopleChild = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
        //        //        StartPlace = dt.Rows[i][6].ToString().Replace("\n", "").Trim(),
        //        //        EndPlace = dt.Rows[i][7].ToString().Replace("\n", "").Trim()
        //        //    });
        //        //}
        //        Entity.GroupBasic gb = new Entity.GroupBasic();
        //        if (string.IsNullOrEmpty(dt.Rows[0][1].ToString())) ;

        //        //如果excel中的行不为空,添加
        //        gb = new Entity.GroupBasic()
        //        {
        //            Name = dt.Rows[0][0].ToString().Replace("\n", "").Trim(),
        //            Begindate = dt.Rows[0][1].ToString().Replace("\n", "").Trim()
        //            //Days = dt.Rows[0][2].ToString().Replace("\n", "").Trim(),
        //            //PeopleTotal = dt.Rows[0][3].ToString().Replace("\n", "").Trim(),
        //            //PeopleAdult = dt.Rows[0][4].ToString().Replace("\n", "").Trim(),
        //            //PeopleChild = dt.Rows[0][5].ToString().Replace("\n", "").Trim(),
        //            //StartPlace = dt.Rows[0][6].ToString().Replace("\n", "").Trim(),
        //            //EndPlace = dt.Rows[0][7].ToString().Replace("\n", "").Trim()
        //        };
        //        //如果获取到了list,就把上传上来的文件删除
        //        File.Delete(path.Replace('/', '\\'));
        //        return gb;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public List<ExcelOplib.Entity.GroupMember> getMemberlist(string path, out string message)
        {
            message = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
                //Sheet1为excel中表的名字
                string sql = "select 类型,姓名,证件号,电话号码,其他证件 from [Sheet1$]";
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
                List<ExcelOplib.Entity.GroupMember> gmlist = new List<ExcelOplib.Entity.GroupMember>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                    //如果excel中的行不为空,添加
                    gmlist.Add(new ExcelOplib.Entity.GroupMember()
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
                message = ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// v.12.24
        /// 获得简单的团队信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Entity.GroupAll getGroup(string path, out string message)
        {
            message = string.Empty;
            try
            {
                #region 07
                //path即是excel文档的路径。
                //string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
                #endregion
                #region 03
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=Excel 8.0";
                #endregion
                //Sheet1为excel中表的名字
                DataTable dt0 = new DataTable();
                string sql0 = "select 团队名称,开始时间,天数,导游姓名,导游身份证号,导游电话号码,导游证号,司机姓名,司机身份证号,司机电话号码,司机证号," +
                    "类型,游客姓名,游客证件号码,游客电话号码,日程,景点,住宿 from [Sheet1$]";
                OleDbCommand cmd0 = new OleDbCommand(sql0, new OleDbConnection(conn));
                OleDbDataAdapter ad0 = new OleDbDataAdapter(cmd0);
                ad0.Fill(dt0);

                #region 基本信息
                Entity.GroupBasic gb = new Entity.GroupBasic();
                //如果excel中的行不为空,添加
                gb = new Entity.GroupBasic()
                {
                    Name = dt0.Rows[0][0].ToString().Replace("\n", "").Trim(),
                    Begindate = string.IsNullOrWhiteSpace(dt0.Rows[0][1].ToString()) ?
                    DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") : dt0.Rows[0][1].ToString().Replace("\n", "").Trim(),
                    Days = dt0.Rows[0][2].ToString().Replace("\n", "").Trim()
                };
                #endregion

                #region 团员信息
                List<Entity.GroupMember> gmlist = new List<Entity.GroupMember>();
                for (int i = 0; i < dt0.Rows.Count; i++)
                {
                    //如果excel中的行不为空,添加导游
                    if (!string.IsNullOrEmpty(dt0.Rows[i][3].ToString()))
                    {
                        gmlist.Add(new Entity.GroupMember()
                        {
                            Memtype = Model.DJ_GroupWorkerType.导游.ToString(),
                            Memname = dt0.Rows[i][3].ToString().Replace("\n", "").Trim(),
                            Memid = dt0.Rows[i][4].ToString().Replace("\n", "").Trim(),
                            Memphone = dt0.Rows[i][5].ToString().Replace("\n", "").Trim(),
                            Cardno = dt0.Rows[i][6].ToString().Replace("\n", "").Trim()
                        });
                    }
                    //如果excel中的行不为空,添加司机
                    if (!string.IsNullOrEmpty(dt0.Rows[i][7].ToString()))
                    {
                        gmlist.Add(new Entity.GroupMember()
                        {
                            Memtype = Model.DJ_GroupWorkerType.司机.ToString(),
                            Memname = dt0.Rows[i][7].ToString().Replace("\n", "").Trim(),
                            Memid = dt0.Rows[i][8].ToString().Replace("\n", "").Trim(),
                            Memphone = dt0.Rows[i][9].ToString().Replace("\n", "").Trim(),
                            Cardno = dt0.Rows[i][10].ToString().Replace("\n", "").Trim()
                        });
                    }
                    //如果excel中的行不为空,添加游客
                    if (!string.IsNullOrEmpty(dt0.Rows[i][11].ToString()))
                    {
                        gmlist.Add(new Entity.GroupMember()
                        {
                            Memtype = dt0.Rows[i][11].ToString().Replace("\n", "").Trim(),
                            Memname = dt0.Rows[i][12].ToString().Replace("\n", "").Trim(),
                            Memid = dt0.Rows[i][13].ToString().Replace("\n", "").Trim(),
                            Memphone = dt0.Rows[i][14].ToString().Replace("\n", "").Trim()
                        });
                    }
                }
                #endregion

                #region 行程信息
                List<Entity.GroupRoute> grlist = new List<Entity.GroupRoute>();
                for (int i = 0; i < dt0.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt0.Rows[i][15].ToString())) continue;

                    //如果excel中的行不为空,添加
                    grlist.Add(new Entity.GroupRoute()
                    {
                        RouteDate = dt0.Rows[i][15].ToString().Replace("\n", "").Trim(),
                        Scenic = dt0.Rows[i][16].ToString().Replace("\n", "").Trim(),
                        Hotel = dt0.Rows[i][17].ToString().Replace("\n", "").Trim()
                    });
                }
                //合并route,相同routedate合并
                #endregion

                //如果获取到了list,就把上传上来的文件删除
                File.Delete(path.Replace('/', '\\'));
                return new Entity.GroupAll() { GroupBasic = gb, GroupMemberList = gmlist, GroupRouteList = grlist };
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return null;
            }
        }

        //没有引用的方法
        //public List<Entity.GroupRoute> getRoutelist(string path)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        #region 07
        //        //path即是excel文档的路径。
        //        string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
        //        //Sheet1为excel中表的名字
        //        string sql = "select 日期,早餐,中餐,晚餐,住宿,景点,购物点 from [行程信息$]";
        //        OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
        //        OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
        //        ad.Fill(dt);
        //        #endregion
        //        #region 03
        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=Excel 8.0";
        //            cmd = new OleDbCommand(sql, new OleDbConnection(conn));
        //            ad = new OleDbDataAdapter(cmd);
        //            ad.Fill(dt);
        //        }
        //        #endregion
        //        List<Entity.GroupRoute> grlist = new List<Entity.GroupRoute>();
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            //如果excel中的某行为空,跳过
        //            if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

        //            //如果excel中的行不为空,添加
        //            grlist.Add(new Entity.GroupRoute()
        //            {
        //                RouteDate = dt.Rows[i][0].ToString().Replace("\n", "").Trim()
        //                //Breakfast = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
        //                //Lunch = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
        //                //Dinner = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
        //                //Hotel1 = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
        //                //Scenic1 = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
        //                //ShoppingPoint1 = dt.Rows[i][6].ToString().Replace("\n", "").Trim()
        //            });
        //        }
        //        //如果获取到了list,就把上传上来的文件删除
        //        File.Delete(path.Replace('/', '\\'));
        //        return grlist;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //更改的方法
        ///// <summary>
        ///// v.10/31
        ///// 获得简单的团队信息
        ///// </summary>
        ///// <param name="path"></param>
        ///// <returns></returns>
        //public Entity.GroupAll getGroup(string path,out string message)
        //{
        //    message = string.Empty;
        //    try
        //    {
        //        #region 07
        //        //path即是excel文档的路径。
        //        string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.Replace('/', '\\') + @";Extended Properties=""Excel 12.0;HDR=YES""";
        //        #endregion

        //        //Sheet1为excel中表的名字
        //        DataTable dt0 = new DataTable();
        //        string sql0 = "select 团队名称,开始时间,天数,类型,导游姓名,导游身份证号,导游电话号码,导游证号,日期,景点,住宿 from [Sheet1$]";
        //        OleDbCommand cmd0 = new OleDbCommand(sql0, new OleDbConnection(conn));
        //        OleDbDataAdapter ad0 = new OleDbDataAdapter(cmd0);
        //        ad0.Fill(dt0);

        //        #region 基本信息
        //        Entity.GroupBasic gb = new Entity.GroupBasic();
        //        //如果excel中的行不为空,添加
        //        gb = new Entity.GroupBasic()
        //        {
        //            Name = dt0.Rows[0][0].ToString().Replace("\n", "").Trim(),
        //            Begindate = dt0.Rows[0][1].ToString().Replace("\n", "").Trim(),
        //            Days = dt0.Rows[0][2].ToString().Replace("\n", "").Trim()
        //        };
        //        #endregion

        //        #region 团员信息
        //        List<Entity.GroupMember> gmlist = new List<Entity.GroupMember>();
        //        for (int i = 0; i < dt0.Rows.Count; i++)
        //        {
        //            //如果excel中的某行为空,跳过
        //            if (string.IsNullOrEmpty(dt0.Rows[i][5].ToString())) continue;

        //            //如果excel中的行不为空,添加
        //            gmlist.Add(new Entity.GroupMember()
        //            {
        //                Memtype = dt0.Rows[i][3].ToString().Replace("\n", "").Trim(),
        //                Memname = dt0.Rows[i][4].ToString().Replace("\n", "").Trim(),
        //                Memid = dt0.Rows[i][5].ToString().Replace("\n", "").Trim(),
        //                Memphone = dt0.Rows[i][6].ToString().Replace("\n", "").Trim(),
        //                Cardno = dt0.Rows[i][7].ToString().Replace("\n", "").Trim()
        //            });
        //        }
        //        #endregion

        //        #region 行程信息
        //        List<Entity.GroupRoute> grlist = new List<Entity.GroupRoute>();
        //        for (int i = 0; i < dt0.Rows.Count; i++)
        //        {
        //            //如果excel中的某行为空,跳过
        //            if (string.IsNullOrEmpty(dt0.Rows[i][9].ToString())) continue;

        //            //如果excel中的行不为空,添加
        //            grlist.Add(new Entity.GroupRoute()
        //            {
        //                RouteDate = dt0.Rows[i][8].ToString().Replace("\n", "").Trim(),
        //                Scenic = dt0.Rows[i][9].ToString().Replace("\n", "").Trim(),
        //                Hotel = dt0.Rows[i][10].ToString().Replace("\n", "").Trim()
        //            });
        //        }
        //        //合并route,相同routedate合并
        //        #endregion

        //        //如果获取到了list,就把上传上来的文件删除
        //        File.Delete(path.Replace('/', '\\'));
        //        return new Entity.GroupAll() { GroupBasic = gb, GroupMemberList = gmlist, GroupRouteList = grlist };
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.ToString();
        //        return null;
        //    }
        //}
    }
}
