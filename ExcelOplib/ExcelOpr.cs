using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace ExcelOplib
{
    /// <summary>
    /// Excel操作类 
    /// <!--说明程序约定3条-->
    /// 1.将excel放在d盘下, 文件名为"2012年浙江省A级旅游景区汇总统计表.xls"
    /// 2.在d盘下创建scenicimg文件夹, 并确保是空.
    /// 3.将各景区图片放在以景区命名的文件夹中, 并将此文件夹放到d盘的图片文件夹中.
    /// </summary>
    public class ExcelOpr
    {
        public void Run()
        {
            BLL.BLLScenic bllscenic = new BLL.BLLScenic();
            List<Entity.ExcelEntity> eelist = getEelist();
            List<Model.Scenic> slist = bllscenic.GetScenic().ToList<Model.Scenic>();
            bllscenic.DeleteScenicimg();
            foreach (Entity.ExcelEntity item in eelist)
            {
                if (string.IsNullOrWhiteSpace(item.name)) break;
                Model.Scenic s = slist.First<Model.Scenic>(x => x.Name == item.name);
                s.ActiveTime = item.opentime;
                s.Desec = item.descp;
                s.SeoName = item.seoname;
                List<Model.ScenicImg> silist = CopyFile(s);
                if (silist != null)
                {
                    bllscenic.SaveScenicimg(silist);
                }
            }
            bllscenic.UpdateScenicInfo(slist);
        }

        private DataTable getTable()
        {
            try
            {
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\test.xls;Extended Properties=Excel 8.0;";
                //Sheet1为excel中表的名字
                string sql = "select 市县区,序号,等级,名称,办公地点,区域,景区门票,价格说明,景区简介 from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<Entity.ExcelEntity> getEelist()
        {
            try
            {
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\2012年浙江省A级旅游景区汇总统计表.xls;Extended Properties=Excel 8.0;";
                //Sheet1为excel中表的名字
                string sql = "select 名称,办公地点,区域,景区门票,开园时间,价格说明,景区简介,seoname from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                List<Entity.ExcelEntity> eelist = new List<Entity.ExcelEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eelist.Add(new Entity.ExcelEntity()
                    {
                        name = dt.Rows[i][0].ToString(),
                        address = dt.Rows[i][1].ToString(),
                        areaid = dt.Rows[i][2].ToString(),
                        price = decimal.Parse(dt.Rows[i][3].ToString() == "" ? "0" : dt.Rows[i][3].ToString()),
                        opentime = dt.Rows[i][4].ToString(),
                        pricedesc = dt.Rows[i][5].ToString(),
                        descp = dt.Rows[i][6].ToString(),
                        seoname = dt.Rows[i][7].ToString()
                    });
                }
                return eelist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<Model.ScenicImg> CopyFile(Model.Scenic scenic)
        {
            string sourcePath = @"d:\图片\" + scenic.Name;
            if (!Directory.Exists(sourcePath)) return null;
            string destPath = @"d:\scenicimg";
            DirectoryInfo TheFolder = new DirectoryInfo(sourcePath);
            List<Model.ScenicImg> silist = new List<Model.ScenicImg>();
            bool firstone = true;
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                string guidname = Guid.NewGuid().ToString() + NextFile.Extension;
                string filepath = destPath + @"\" + guidname;
                //FileInfo myfile = new FileInfo(filepath);
                //myfile.Create();
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
                silist.Add(new Model.ScenicImg()
                {
                    Name = guidname,
                    Scenic = scenic,
                    Title=NextFile.Name.Replace(NextFile.Extension,""),
                    ImgType = firstone ? Model.ImgType.主图 : Model.ImgType.辅图
                });
                firstone = false;
            }
            return silist;
        }
    }
}
