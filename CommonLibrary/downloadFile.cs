using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web;

namespace CommonLibrary
{
    public class downloadFile
    {
        public void download(string filename,string filepath,Page page)
        {
            string filePath = page.Server.MapPath(filepath);//路径 //以字符流的形式下载文件 
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length]; fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            page.Response.ContentType = "application/octet-stream"; //通知浏览器下载文件而不是打开 
            page.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8)); 
            page.Response.BinaryWrite(bytes);
            page.Response.Flush();
            page.Response.End(); 
        }
    }
}
