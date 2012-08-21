using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CommonLibrary
{
    public class HTMLInfo
    {
        /// <summary>
        /// 从磁盘中获取到HTML代码
        /// </summary>
        /// <param name="scid">景区id</param>
        /// <param name="type">需要获取的景区内容类型</param>
        /// <returns>返回获取到的HTML</returns>
        public string GetHTMLInfo(string type, string scname, int scFuncType)
        {
            //需要提取的文件名名称
            string FileName = "";
            if (type != "景区")
                FileName = type;
            else
            {
                switch (scFuncType)
                {
                    case 1: FileName = scname + "_" + "订票说明"; break;
                    case 2: FileName = scname + "_" + "景区简介"; break;
                    case 3: FileName = scname + "_" + "交通指南"; break;
                }
            }
            string path = "D:\\HTMLInfo\\" + FileName + ".html";
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
    }
}
