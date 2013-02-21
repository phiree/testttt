using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Web;

namespace ExcelOplib
{
    /// <summary>
    /// Excel操作类 
    /// </summary>
    public class ExcelOpr
    {
        private readonly BLL.BLLArea bllarea = new BLL.BLLArea();
        private readonly BLL.BLLTicket bllticket = new BLL.BLLTicket();
        private readonly string mappath = HttpContext.Current.Server.MapPath(null) + "/d";

        public void Run()
        {
            if(!Directory.Exists(mappath))
            {
                Directory.CreateDirectory(mappath);
            }
            if (!Directory.Exists(mappath + "/testMainimgLocalizer/"))
            {
                Directory.CreateDirectory(mappath + "/testMainimgLocalizer/");
            }
            if (!Directory.Exists(mappath + "/testDetailimgLocalizer/"))
            {
                Directory.CreateDirectory(mappath + "/testDetailimgLocalizer/"); 
            }
            if (!Directory.Exists(mappath + "/scenicimg/"))
            {
                Directory.CreateDirectory(mappath + "/scenicimg/");
            }
            if (!Directory.Exists(mappath + "/scenicimg/mainimg/"))
            {
                Directory.CreateDirectory(mappath + "/scenicimg/mainimg/");
            }
            if (!Directory.Exists(mappath + "/scenicimg/detailimg/"))
            {
                Directory.CreateDirectory(mappath + "/scenicimg/detailimg/");
            }
            if (!Directory.Exists(mappath + "/scenicimg/small/"))
            {
                Directory.CreateDirectory(mappath + "/scenicimg/small/");
            }
            var bllscenic = new BLL.BLLScenic();
            var newslist = getSceniclist();

            //收集景区topic,及topicseo
            var temptp = string.Empty;
            var temptseo = string.Empty;
            foreach (var tstring in newslist)
            {
                temptp += tstring.topic + ",";
                temptseo += tstring.topicseo + ",";
            }
            var topicc1 = temptp.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            var topics1 = temptseo.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            var topicc2 = topicc1.Distinct().ToList<string>();
            var topics2 = topics1.Distinct().ToList<string>();
            //blltopic.SaveTopic(topicc2, topics2);

            var orgslist = bllscenic.GetScenic().ToList<Model.Scenic>();
            bllscenic.DeleteScenicimg();
            //循环景区
            foreach (Entity.ScenicEntity item in newslist)
            {
                if (string.IsNullOrWhiteSpace(item.name)) break;
                //组装scenic
                List<Model.Scenic> ss = orgslist.Where<Model.Scenic>(x => x.Name == item.name).ToList();
                Model.Scenic s;
                if (ss.Count == 1)//已经存在该景区
                {
                    s = ss.First();
                    s.Address = item.address;
                    s.Level = item.level;
                    s.SeoName = string.IsNullOrEmpty(s.SeoName) ? item.seoname : s.SeoName;
                    s.Area = bllarea.GetAreaByAreaname(item.areaid);
                    //处理topic字符串
                    var temptopic = item.topic.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                    // blltopic.SaveScenictopic(temptopic, s.Id);
                    s.Trafficintro = item.trafficintro;
                    s.BookNote = item.bookintro;
                    s.ScenicDetail = item.scenicdetail;
                    s.Desec = item.scenicintro;
                    s.Type = Model.EnterpriseType.景点;
                    //组装tickets
                    var newtlist = getTicketslist().Where(x => x.scenicname == s.Name).ToList<Entity.TicketEntity>();
                    var tickets = bllticket.GetTicketByscId(s.Id);
                    Model.Ticket t;
                    foreach (var te in newtlist)
                    {
                        var tmp = tickets.Where(x => x.Name == te.ticketname);
                        if (tmp.Count() == 1)//已经存在该票
                        {
                            t = tmp.First();
                            t.Name = te.ticketname;
                            t.Scenic = s;
                            t.IsMain = true;
                            var tpnormal = t.TicketPrice.Where(x => x.PriceType == Model.PriceType.Normal);
                            if (tpnormal.Any())
                                t.TicketPrice.First(x => x.PriceType == Model.PriceType.Normal).Price = decimal.Parse(te.orgprice);
                            var tpol = t.TicketPrice.Where(x => x.PriceType == Model.PriceType.PayOnline);
                            if (tpol.Any())
                                t.TicketPrice.First(x => x.PriceType == Model.PriceType.PayOnline).Price = decimal.Parse(te.olprice);
                            var tppre = t.TicketPrice.Where(x => x.PriceType == Model.PriceType.PreOrder);
                            if (tppre.Any())
                                t.TicketPrice.First(x => x.PriceType == Model.PriceType.PreOrder).Price = decimal.Parse(te.orgprice) * (decimal)0.95;
                        }
                        else//不存在该票
                        {
                            t = new Model.TicketNormal { Name = te.ticketname, Scenic = s, IsMain = true };
                            t.TicketPrice = new List<Model.TicketPrice>() { 
                            new Model.TicketPrice() { Price=decimal.Parse(te.orgprice),PriceType=Model.PriceType.Normal,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.olprice),PriceType=Model.PriceType.PayOnline,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.orgprice)*(decimal)0.95,PriceType=Model.PriceType.PreOrder,Ticket=t}};
                            tickets.Add(t);
                        }
                    }
                    s.Tickets = tickets;
                    s.Photo = item.mainpic;
                    bllscenic.UpdateScenicInfo(s);
                    var silist = CopyFile(s);
                    if (silist != null)
                    {
                        bllscenic.SaveScenicimg(silist);
                    }
                }
                else//不存在该景区
                {
                    s = new Model.Scenic();
                    s.Name = item.name;
                    s.Address = item.address;
                    s.Area = bllarea.GetAreaByAreaname(item.areaid);
                    s.BookNote = item.bookintro;
                    s.Level = item.level;
                    s.Type = Model.EnterpriseType.景点;
                    //处理topic字符串
                    var temptopic = item.topic.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                    s.ScenicDetail = item.scenicdetail;
                    s.SeoName = item.seoname;
                    s.Trafficintro = item.trafficintro;
                    s.Desec = item.scenicintro;
                    //组装tickets
                    List<Entity.TicketEntity> newtlist = getTicketslist().Where(x => x.scenicname == s.Name).ToList<Entity.TicketEntity>();
                    List<Model.Ticket> tickets = new List<Model.Ticket>();
                    Model.Ticket t;
                    foreach (var te in newtlist)
                    {
                        t = new Model.TicketNormal();
                        t.Name = te.ticketname;
                        t.Scenic = s;
                        t.IsMain = true;
                        t.TicketPrice = new List<Model.TicketPrice>() { 
                            new Model.TicketPrice() { Price=decimal.Parse(te.orgprice),PriceType=Model.PriceType.Normal,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.olprice),PriceType=Model.PriceType.PayOnline,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.orgprice)*(decimal)0.95,PriceType=Model.PriceType.PreOrder,Ticket=t}
                        };
                        tickets.Add(t);
                    }
                    s.Tickets = tickets;
                    s.Photo = item.mainpic;
                    bllscenic.UpdateScenicInfo(s);
                    //   blltopic.SaveScenictopic(temptopic, bllscenic.GetScenicBySeoName(item.seoname).Id);
                    List<Model.ScenicImg> silist = CopyFile(s);
                    if (silist != null)
                    {
                        bllscenic.SaveScenicimg(silist);
                    }
                }
            }
            //bllscenic.UpdateScenicInfo(orgslist);
        }

        /// <summary>
        /// 获取-景区表-内容
        /// </summary>
        /// <returns></returns>
        private List<Entity.ScenicEntity> getSceniclist()
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                //var conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= d:\景区表格式.xlsx;Extended Properties=""Excel 12.0;HDR=YES""";
                //const string sql = "select 名称,seoname,区域,景区主题,交通指南,订票说明,景区详情,等级,景区地址,topicseo,景区简介,主图 from [Sheet1$]";
                //var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                //var ad = new OleDbDataAdapter(cmd);
                //ad.Fill(dt);
                #endregion
                #region 03

                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mappath + "/浙江景区表格式.xls;Extended Properties=Excel 8.0";
                const string sql = "select 名称,seoname,区域,景区主题,交通指南,订票说明,景区详情,等级,景区地址,topicseo,景区简介,主图 from [Sheet1$]";
                var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                var ad = new OleDbDataAdapter(cmd);
                ad.Fill(dt);
                #endregion
                var slist = new List<Entity.ScenicEntity>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString())) continue;

                    //对景区详情处理
                    var srclist = GetPiclist(dt.Rows[i][0].ToString().Replace("\n", "").Trim()).Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                    var scdetail = dt.Rows[i][6].ToString().Replace("\n", "").Trim();
                    for (var j = 0; j < srclist.Length / 2; j++)
                    {
                        scdetail = scdetail.Replace(srclist[j], srclist[j + srclist.Length / 2]);
                    }

                    //如果excel中的行不为空,添加
                    slist.Add(new Entity.ScenicEntity()
                    {
                        name = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        seoname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        areaid = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        topic = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        trafficintro = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
                        bookintro = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
                        scenicdetail = scdetail,
                        level = dt.Rows[i][7].ToString().Replace("\n", "").Trim(),
                        address = dt.Rows[i][8].ToString().Replace("\n", "").Trim(),
                        topicseo = dt.Rows[i][9].ToString().Replace("\n", "").Trim(),
                        scenicintro = dt.Rows[i][10].ToString().Replace("\n", "").Trim(),
                        mainpic = dt.Rows[i][11].ToString().Replace("\n", "").Trim()
                    });
                }
                return slist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取-价格表-内容
        /// </summary>
        /// <returns></returns>
        private List<Entity.TicketEntity> getTicketslist()
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                #region 07
                //path即是excel文档的路径。
                //string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= "++"\衢州价格表格式.xlsx;Extended Properties=""Excel 12.0;HDR=YES""";
                //string sql = "select 景区名称,门票名称,原价,在线支付价 from [Sheet1$]";
                //OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                //OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                //ad.Fill(dt);
                #endregion
                #region 03
                if (dt.Rows.Count == 0)
                {
                    var conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mappath + "/浙江价格表格式.xls;Extended Properties=Excel 8.0";
                    const string sql = "select 景区名称,门票名称,原价,在线支付价 from [Sheet1$]";
                    var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                    var ad = new OleDbDataAdapter(cmd);
                    ad.Fill(dt);
                }
                #endregion
                var tlist = new List<Entity.TicketEntity>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    tlist.Add(new Entity.TicketEntity()
                    {
                        scenicname = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }
                return tlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 拷贝图片文件.
        /// </summary>
        /// <param name="scenic"></param>
        /// <returns></returns>
        private List<Model.ScenicImg> CopyFile(Model.Scenic scenic)
        {
            string sourcePath = mappath + "/testMainimgLocalizer/" + scenic.Name.Trim() + "/";
            if (!Directory.Exists(sourcePath)) return null;
            string destPath = mappath+"/scenicimg/mainimg/";
            var TheFolder = new DirectoryInfo(sourcePath);
            var silist = new List<Model.ScenicImg>();
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                string filename = NextFile.Name;
                string filepath = destPath + @"\" + filename;
                //创建两个文件流 一个是源文件相关，另一个是要写入的文件
                FileStream fs = new FileStream(NextFile.FullName, FileMode.Open);
                FileStream fs2 = new FileStream(filepath, FileMode.Create);
                byte[] data = new byte[1024];
                BufferedStream bs = new BufferedStream(fs);
                BufferedStream bs2 = new BufferedStream(fs2);
                while (fs.Read(data, 0, data.Length) > 0)
                {
                    fs2.Write(data, 0, data.Length);
                    fs2.Flush();
                }
                fs.Close();
                fs2.Close();
                //var img_index=filename.IndexOf(Math.Abs(scenic.Photo.GetHashCode()).ToString()) >= 0 ;
                var img_index = filename.IndexOf(scenic.Photo.Split(
                    new string[] { "/scenicimg/mainimg/" }, StringSplitOptions.RemoveEmptyEntries)[0].ToString()) >= 0;
                silist.Add(new Model.ScenicImg()
                {
                    Name = filename,
                    Scenic = scenic,
                    Title = NextFile.Name.Replace(NextFile.Extension, ""),
                    ImgType = img_index ? Model.ImgType.主图 : Model.ImgType.辅图 //firstone ? Model.ImgType.主图 : Model.ImgType.辅图
                });
            }
            return silist;
        }

        private string GetPiclist(string scenicname)
        {
            try
            {
                var result = string.Empty;
                string line;
                var file = new System.IO.StreamReader(mappath+"/scenicfile/"+scenicname+".txt");
                while ((line = file.ReadLine()) != null)
                {
                    result += line + "$";
                }
                file.Close();
                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
