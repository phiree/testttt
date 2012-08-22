using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace CommonLibrary
{
    public class HTMLInfo
    {
        /// <summary>
        /// 从磁盘中获取到HTML代码
        /// </summary>
        /// <param name="scid">景区id</param>
        /// <param name="type">需要获取的景区内容类型</param>
        /// <param name="scFuncType"></param>
        /// <returns>返回获取到的HTML</returns>
        public string GetHTMLInfo(string type, string scname, string scFuncType)
        {
            //需要提取的文件名名称
            string FileName = "";
            if (type != "景区")
                FileName = type;
            else
            {
                FileName = scname + "_" + scFuncType;
            }
            string path = ConfigurationManager.AppSettings["HTMLInfoPath"].ToString()+ FileName + ".html";
            //获取到的HTML
            string HTMLInfo = "";
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    while (sr.Peek() >= 0)
                    {
                        HTMLInfo += (char)sr.Read();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            return HTMLInfo;
        }
        /// <summary>
        /// 把HTML代码保存到磁盘中
        /// </summary>
        /// <param name="type">页面类型</param>
        /// <param name="scname">景区名称</param>
        /// <param name="scFuncType">景区功能</param>
        /// <param name="HTMLData">需要保存的HTML内容</param>
        public void WriteHTMLInfo(string type, string scname, string scFuncType,string HTMLData)
        {
            //需要保存的文件名名称
            string FileName = "";
            if (type != "景区")
                FileName = type;
            else
            {
                FileName = scname + "_" + scFuncType;
            }
            string path = ConfigurationManager.AppSettings["HTMLInfoPath"].ToString() + FileName + ".html";
            HTMLData=HTMLData.Replace("&lt;", "<");
            HTMLData=HTMLData.Replace("&gt;", ">");
            try
            {
                using (StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8))
                {
                    sw.Write(HTMLData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
